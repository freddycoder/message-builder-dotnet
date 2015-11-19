/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.Polymorphism;
using Ca.Infoway.Messagebuilder.Schema;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class SetOrListElementParser : AbstractElementParser
	{
		private readonly Registry<ElementParser> parserRegistry;

		private readonly bool isR2;

		public SetOrListElementParser(Registry<ElementParser> parserRegistry, bool isR2)
		{
			this.parserRegistry = parserRegistry;
			this.isR2 = isR2;
		}

		private IiCollectionConstraintHandler constraintHandler = new IiCollectionConstraintHandler();

		private PolymorphismHandler polymorphismHandler = new PolymorphismHandler();

		// only checking II constraints for now
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			string subType = GetSubType(context);
			ICollection<BareANY> list = GetCollectionType(context);
			ValidateCardinality(context, nodes, xmlToModelResult);
			foreach (XmlNode node in nodes)
			{
				string actualType = DetermineActualType(node, subType, context.IsCda(), xmlToModelResult);
				ElementParser parser = this.parserRegistry.Get(actualType);
				if (parser != null)
				{
					BareANY result = parser.Parse(ParseContextImpl.Create(actualType, GetSubTypeAsModelType(context), context), ToList(node), 
						xmlToModelResult);
					// constraints are *not* passed down with collections
					if (result != null)
					{
						if (!StringUtils.Equals(subType, actualType))
						{
							result.DataType = StandardDataType.GetByTypeName(actualType);
						}
						if (list.Contains(result))
						{
							ResultAlreadyExistsInCollection(result, (XmlElement)node, xmlToModelResult);
						}
						list.Add(result);
					}
				}
				else
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "No parser type found for " + actualType, (XmlElement
						)node));
				}
			}
			HandleConstraints(subType, list, context.GetConstraints(), nodes, xmlToModelResult);
			BareANY wrapResult = null;
			try
			{
				wrapResult = WrapWithHl7DataType(context.Type, subType, list, context);
			}
			catch (MarshallingException e)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, e.Message, (string)null));
			}
			return wrapResult;
		}

		private string DetermineActualType(XmlNode node, string subType, bool isCda, Hl7Errors errors)
		{
			string newType = ((XmlElement)node).GetAttribute("type", XmlSchemas.SCHEMA_INSTANCE);
			return this.polymorphismHandler.DetermineActualDataTypeFromXsiType(subType, newType, isCda, !this.isR2, CreateErrorLogger
				((XmlElement)node, errors));
		}

		private ErrorLogger CreateErrorLogger(XmlElement element, Hl7Errors errors)
		{
			return new _ErrorLogger_117(errors, element);
		}

		private sealed class _ErrorLogger_117 : ErrorLogger
		{
			public _ErrorLogger_117(Hl7Errors errors, XmlElement element)
			{
				this.errors = errors;
				this.element = element;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, (XmlNode)element));
			}

			private readonly Hl7Errors errors;

			private readonly XmlElement element;
		}

		private void HandleConstraints(string type, ICollection<BareANY> parsedItems, ConstrainedDatatype constraints, IList<XmlNode
			> nodes, XmlToModelResult xmlToModelResult)
		{
			IiCollectionConstraintHandler.ConstraintResult constraintResult = this.constraintHandler.CheckConstraints(type, constraints
				, parsedItems);
			if (constraintResult != null)
			{
				bool isTemplateId = constraintResult.IsTemplateId();
				if (constraintResult.IsFoundMatch())
				{
					if (isTemplateId)
					{
						string msg = System.String.Format("Found match for templateId fixed constraint: {0}", constraintResult.GetIdentifer());
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MATCH, ErrorLevel.INFO, msg, nodes
							.Count > 0 ? nodes[0] : null));
					}
				}
				else
				{
					Hl7ErrorCode errorCode = (isTemplateId ? Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING : Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING
						);
					string msg = "Expected to find an identifier with: " + constraintResult.GetIdentifer();
					xmlToModelResult.AddHl7Error(new Hl7Error(errorCode, ErrorLevel.WARNING, msg, nodes.Count > 0 ? nodes[0] : null));
				}
			}
		}

		protected virtual void ResultAlreadyExistsInCollection(BareANY result, XmlElement node, XmlToModelResult xmlToModelResult
			)
		{
		}

		// do nothing; allow subclasses to override if necessary
		private void ValidateCardinality(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			int size = nodes.Count;
			int min = (int)context.GetCardinality().Min;
			int max = (int)context.GetCardinality().Max;
			if (size < min)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Number of elements (" + size + ") is less than the specified minimum ("
					 + min + ")", GetFirst(nodes)));
			}
			if (size > max)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Number of elements (" + size + ") is more than the specified maximum ("
					 + max + ")", GetFirst(nodes)));
			}
		}

		private XmlElement GetFirst(IList<XmlNode> nodes)
		{
			return (XmlElement)(nodes == null || nodes.IsEmpty() ? null : nodes[0]);
		}

		protected virtual void UnableToAddResultToCollection(BareANY result, XmlElement node, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "Could not add parsed value to collection", (XmlElement
				)node));
		}

		protected abstract BareANY WrapWithHl7DataType(string type, string subType, ICollection<BareANY> collection, ParseContext
			 context);

		protected abstract ICollection<BareANY> GetCollectionType(ParseContext context);

		private Type GetSubTypeAsModelType(ParseContext context)
		{
			Type returnType = GetReturnType(context);
			try
			{
				return Generics.GetParameterType(returnType);
			}
			catch (ArgumentException)
			{
				return returnType;
			}
		}

		private IList<XmlNode> ToList(XmlNode node)
		{
			return Arrays.AsList(node);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private string GetSubType(ParseContext context)
		{
			string subType = Hl7DataTypeName.GetParameterizedType(context.Type);
			if (StringUtils.IsNotBlank(subType))
			{
				return subType;
			}
			else
			{
				throw new XmlToModelTransformationException("Cannot find the sub type for " + context.Type);
			}
		}
	}
}
