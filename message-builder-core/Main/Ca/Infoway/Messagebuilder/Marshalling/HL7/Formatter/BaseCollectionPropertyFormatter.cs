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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.Polymorphism;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Iterator;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class BaseCollectionPropertyFormatter : AbstractNullFlavorPropertyFormatter<ICollection<BareANY>>
	{
		private readonly Registry<PropertyFormatter> formatterRegistry;

		private readonly bool isR2;

		public BaseCollectionPropertyFormatter(Registry<PropertyFormatter> formatterRegistry, bool isR2)
		{
			this.formatterRegistry = formatterRegistry;
			this.isR2 = isR2;
		}

		private IiCollectionConstraintHandler constraintHandler = new IiCollectionConstraintHandler();

		private PolymorphismHandler polymorphismHandler = new PolymorphismHandler();

		// only checking II constraints for now
		protected virtual FormatContext CreateSubContext(FormatContext context)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(context.GetModelToXmlResult(), context.GetPropertyPath
				(), context.GetElementName(), GetSubType(context), context.GetDomainType(), context.GetConformanceLevel(), context.GetCardinality
				(), context.IsSpecializationType(), context.GetVersion(), context.GetDateTimeZone(), context.GetDateTimeTimeZone(), null
				, null, context.IsCda());
		}

		// constraints are not passed down from collection attributes
		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			if (hl7Value == null)
			{
				return string.Empty;
			}
			ICollection<BareANY> bareAnyCollection = GenericClassUtil.ConvertToBareANYCollection(hl7Value);
			HandleConstraints(GetSubType(context), context.GetConstraints(), hl7Value, bareAnyCollection, context);
			return base.Format(context, hl7Value, indentLevel);
		}

		protected override ICollection<BareANY> ExtractBareValue(BareANY hl7Value)
		{
			BareCollection collection = (BareCollection)hl7Value;
			return collection.GetBareCollectionValue();
		}

		protected virtual string FormatAllElements(FormatContext originalContext, FormatContext subContext, ICollection<BareANY> 
			collection, int indentLevel)
		{
			StringBuilder builder = new StringBuilder();
			ValidateCardinality(originalContext, collection);
			PropertyFormatter formatter = this.formatterRegistry.Get(subContext.Type);
			if (collection.IsEmpty())
			{
				builder.Append(formatter.Format(subContext, null, indentLevel));
			}
			else
			{
				foreach (BareANY hl7Value in EmptyIterable<object>.NullSafeIterable<BareANY>(collection))
				{
					string type = DetermineActualType(subContext.Type, hl7Value, originalContext.GetModelToXmlResult(), originalContext.GetPropertyPath
						(), originalContext.IsCda());
					if (!StringUtils.Equals(type, subContext.Type))
					{
						subContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(type, true, subContext);
						formatter = this.formatterRegistry.Get(type);
					}
					builder.Append(formatter.Format(subContext, hl7Value, indentLevel));
				}
			}
			return builder.ToString();
		}

		private string DetermineActualType(string type, BareANY hl7Value, Hl7Errors errors, string propertyPath, bool isCda)
		{
			StandardDataType newTypeEnum = (hl7Value == null ? null : hl7Value.DataType);
			return this.polymorphismHandler.DetermineActualDataType(type, newTypeEnum, isCda, !this.isR2, CreateErrorLogger(propertyPath
				, errors));
		}

		private ErrorLogger CreateErrorLogger(string propertyPath, Hl7Errors errors)
		{
			return new _ErrorLogger_128(errors, propertyPath);
		}

		private sealed class _ErrorLogger_128 : ErrorLogger
		{
			public _ErrorLogger_128(Hl7Errors errors, string propertyPath)
			{
				this.errors = errors;
				this.propertyPath = propertyPath;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, propertyPath));
			}

			private readonly Hl7Errors errors;

			private readonly string propertyPath;
		}

		private void HandleConstraints(string type, ConstrainedDatatype constraints, BareANY hl7Value, ICollection<BareANY> bareAnyCollection
			, FormatContext context)
		{
			IiCollectionConstraintHandler.ConstraintResult constraintResult = this.constraintHandler.CheckConstraints(type, constraints
				, bareAnyCollection);
			if (constraintResult != null && !constraintResult.IsFoundMatch())
			{
				// there should be a match, but if not we need to create an II with the appropriate values and add to collection
				Identifier identifier = constraintResult.GetIdentifer();
				//In Java these are really the same collection due to type erasure. In .NET we need two different collections.
				ICollection<II> iiCollection = (ICollection<II>)hl7Value.BareValue;
				iiCollection.Add(new IIImpl(identifier));
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_PROVIDED, ErrorLevel.INFO, "A fixed constraint was added for compliance: "
					 + identifier, context.GetPropertyPath()));
			}
		}

		private void ValidateCardinality(FormatContext context, ICollection<BareANY> collection)
		{
			int size = collection.Count;
			int min = (int)context.GetCardinality().Min;
			int max = (int)context.GetCardinality().Max;
			if (size < min)
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Number of elements (" + size + ") is less than the specified minimum ("
					 + min + ")", context.GetPropertyPath()));
			}
			if (size > max)
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Number of elements (" + size + ") is more than the specified maximum ("
					 + max + ")", context.GetPropertyPath()));
			}
		}

		/// <summary>
		/// We expect the type to look something like this:
		/// 
		/// SET&lt;II&gt;
		/// 
		/// and we want to return "II"
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		/// <exception cref="ModelToXmlTransformationException"></exception>
		private string GetSubType(FormatContext context)
		{
			string subType = Hl7DataTypeName.GetParameterizedType(context.Type);
			if (StringUtils.IsNotBlank(subType))
			{
				return subType;
			}
			else
			{
				throw new ModelToXmlTransformationException("Cannot find the sub type for " + context.Type);
			}
		}
	}
}
