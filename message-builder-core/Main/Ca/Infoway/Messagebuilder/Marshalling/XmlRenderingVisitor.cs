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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Text;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Util;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class XmlRenderingVisitor : Visitor
	{
		private static readonly string INLINED_PROPERTY_SUFFIX = "_INLINED";

		private static readonly string NULL_FLAVOR_FORMAT_FOR_ASSOCIATIONS = "nullFlavor=\"{0}\" xsi:nil=\"true\"";

		internal class Buffer
		{
			private readonly string name;

			private readonly StringBuilder structuralBuilder = new StringBuilder();

			private readonly StringBuilder childBuilder = new StringBuilder();

			private readonly int indent;

			private IList<string> warnings = new List<string>();

			private XmlWarningRenderer xmlWarningRenderer = new XmlWarningRenderer();

			public Buffer(XmlRenderingVisitor _enclosing, string name, int indent)
			{
				this._enclosing = _enclosing;
				this.name = name;
				this.indent = indent;
			}

			public virtual int GetIndent()
			{
				return this.indent;
			}

			public virtual string GetName()
			{
				return this.name;
			}

			public virtual StringBuilder GetStructuralBuilder()
			{
				return this.structuralBuilder;
			}

			public virtual StringBuilder GetChildBuilder()
			{
				return this.childBuilder;
			}

			public virtual string ToXml()
			{
				StringBuilder builder = new StringBuilder();
				if (!this.warnings.IsEmpty())
				{
					foreach (string warning in this.warnings)
					{
						builder.Append(this.xmlWarningRenderer.CreateWarning(this.indent, warning));
					}
				}
				Indenter.IndentBuilder(builder, this.indent);
				builder.Append("<").Append(this.name);
				if (this.structuralBuilder.Length > 0)
				{
					builder.Append(" ").Append(this.structuralBuilder.ToString().Trim());
				}
				if (StringUtils.IsNotBlank(this.childBuilder.ToString()))
				{
					builder.Append(">").Append(SystemUtils.LINE_SEPARATOR).Append(this.childBuilder.ToString());
					Indenter.IndentBuilder(builder, this.indent);
					builder.Append("</").Append(this.name).Append(">");
				}
				else
				{
					builder.Append("/>");
				}
				if (this.indent > 0)
				{
					builder.Append(SystemUtils.LINE_SEPARATOR);
				}
				return builder.ToString();
			}

			public override string ToString()
			{
				return "Buffer: " + this.name;
			}

			public virtual IList<string> GetWarnings()
			{
				return this.warnings;
			}

			public virtual void AddWarning(string warning)
			{
				this.warnings.Add(warning);
			}

			private readonly XmlRenderingVisitor _enclosing;
		}

		private readonly Stack<string> propertyPathNames = new Stack<string>();

		private readonly Stack<XmlRenderingVisitor.Buffer> buffers = new Stack<XmlRenderingVisitor.Buffer>();

		private Interaction interaction;

		private readonly DataTypeValueAdapterProvider adapterProvider = new DataTypeValueAdapterProvider();

		private readonly ModelToXmlResult result = new ModelToXmlResult();

		private readonly XmlWarningRenderer xmlWarningRenderer = new XmlWarningRenderer();

		private XmlRenderingVisitor.Buffer CurrentBuffer()
		{
			return this.buffers.Peek();
		}

		public virtual void VisitAssociationEnd(PartBridge tealBean, Relationship relationship)
		{
			if (IsSomethingToRender(tealBean, relationship))
			{
				PopBuffer();
				this.propertyPathNames.Pop();
			}
		}

		private bool IsSomethingToRender(PartBridge tealBean, Relationship relationship)
		{
			return !tealBean.IsEmpty() || relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY || relationship
				.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED;
		}

		public virtual void VisitAssociationStart(PartBridge part, Relationship relationship)
		{
			if (IsSomethingToRender(part, relationship))
			{
				bool validationWarning = false;
				string warningMessage = null;
				PushPropertyPathName(DeterminePropertyName(part.GetPropertyName(), relationship), part.IsCollapsed());
				string propertyPath = BuildPropertyPath();
				this.buffers.Push(new XmlRenderingVisitor.Buffer(this, DetermineXmlName(part, relationship), this.buffers.Count));
				if (part.IsEmpty() && relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED)
				{
					CurrentBuffer().GetStructuralBuilder().Append(System.String.Format(NULL_FLAVOR_FORMAT_FOR_ASSOCIATIONS, GetNullFlavor(part
						).CodeValue));
				}
				else
				{
					if (part.IsEmpty() && relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY && !IsTrivial(
						part))
					{
						// some errors are due to "null" parts MB has inserted to create structural XML; don't log errors on these
						validationWarning = !part.IsNullPart() && !part.IsCollapsed();
						warningMessage = "Mandatory association has no data.";
						if (!validationWarning)
						{
							CurrentBuffer().AddWarning(warningMessage + " (" + propertyPath + ")");
						}
					}
					else
					{
						if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED)
						{
							validationWarning = true;
							warningMessage = System.String.Format(ConformanceLevelUtil.IsIgnoredNotAllowed() ? ConformanceLevelUtil.ASSOCIATION_IS_IGNORED_AND_CAN_NOT_BE_USED
								 : ConformanceLevelUtil.ASSOCIATION_IS_IGNORED_AND_WILL_NOT_BE_USED, relationship.Name);
						}
						else
						{
							if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
							{
								validationWarning = true;
								warningMessage = System.String.Format(ConformanceLevelUtil.ASSOCIATION_IS_NOT_ALLOWED, relationship.Name);
							}
						}
					}
				}
				if (validationWarning)
				{
					// store error within error collection
					this.result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, warningMessage, propertyPath));
				}
				AddNewErrorsToList(CurrentBuffer().GetWarnings());
			}
		}

		private void PushPropertyPathName(string propertyName, bool isCollapsed)
		{
			string nameToPush = propertyName + (isCollapsed ? INLINED_PROPERTY_SUFFIX : string.Empty);
			this.propertyPathNames.Push(nameToPush);
		}

		private string DeterminePropertyName(string propertyName, Named nameFallBack)
		{
			string backupName = (nameFallBack == null ? null : nameFallBack.Name);
			return (StringUtils.IsNotBlank(propertyName) && !FixedValueAttributeBeanBridge.FIXED.Equals(propertyName)) ? propertyName
				 : (backupName == null ? string.Empty : backupName);
		}

		/// <summary>Very rarely, there's a mandatory association that has no data.</summary>
		/// <remarks>Very rarely, there's a mandatory association that has no data.</remarks>
		/// <param name="part"></param>
		/// <returns></returns>
		private bool IsTrivial(PartBridge part)
		{
			bool trivial = true;
			foreach (BaseRelationshipBridge relationship in part.GetRelationshipBridges())
			{
				if (relationship.GetRelationship().Association || !relationship.GetRelationship().Fixed)
				{
					trivial = false;
					break;
				}
			}
			return trivial;
		}

		private NullFlavor GetNullFlavor(PartBridge tealBean)
		{
			NullFlavor nullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
			if (tealBean.HasNullFlavor())
			{
				nullFlavor = tealBean.GetNullFlavor();
			}
			return nullFlavor;
		}

		private string DetermineXmlName(PartBridge tealBean, Relationship relationship)
		{
			if (!relationship.Choice && !relationship.TemplateRelationship)
			{
				return relationship.Name;
			}
			else
			{
				if (relationship.TemplateRelationship)
				{
					Argument argument = this.interaction.GetArgumentByTemplateParameterName(relationship.TemplateParameterName);
					if (argument == null)
					{
						throw new RenderingException("Cannot determine the template/choice parameter type : " + relationship.Name);
					}
					else
					{
						if (argument.Choice)
						{
							Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship> predicate = ChoiceSupport.ChoiceOptionTypePredicate(new string[] { 
								tealBean.GetTypeName() });
							Relationship option = argument.FindChoiceOption(predicate);
							if (option == null)
							{
								throw new RenderingException("Cannot determine the choice type of template argument : " + argument.Name);
							}
							else
							{
								return option.Name;
							}
						}
						else
						{
							return argument.TraversalName;
						}
					}
				}
				else
				{
					if (tealBean.IsEmpty())
					{
						return relationship.Choices[0].Name;
					}
					else
					{
						Relationship option = BeanBridgeChoiceRelationshipResolver.ResolveChoice(tealBean, relationship);
						if (option == null)
						{
							throw new RenderingException("Cannot determine the choice type of relationship : " + relationship.Name);
						}
						else
						{
							return option.Name;
						}
					}
				}
			}
		}

		public virtual void VisitAttribute(AttributeBridge tealBean, Relationship relationship, VersionNumber version, TimeZone dateTimeZone
			, TimeZone dateTimeTimeZone)
		{
			PushPropertyPathName(DeterminePropertyName(tealBean.GetPropertyName(), relationship), false);
			if (relationship.Structural)
			{
				string propertyPath = BuildPropertyPath();
				string warningForIncorrectUseOfIgnore = null;
				if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED)
				{
					warningForIncorrectUseOfIgnore = System.String.Format(ConformanceLevelUtil.IsIgnoredNotAllowed() ? ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_CAN_NOT_BE_USED
						 : ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_WILL_NOT_BE_USED, relationship.Name);
				}
				else
				{
					if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
					{
						warningForIncorrectUseOfIgnore = System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_NOT_ALLOWED, relationship.Name);
					}
				}
				if (warningForIncorrectUseOfIgnore != null)
				{
					this.result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, warningForIncorrectUseOfIgnore, propertyPath));
				}
				new VisitorStructuralAttributeRenderer(relationship, tealBean.GetValue()).Render(CurrentBuffer().GetStructuralBuilder(), 
					propertyPath, this.result);
				AddNewErrorsToList(CurrentBuffer().GetWarnings());
			}
			else
			{
				RenderNonStructuralAttribute(tealBean, relationship, version, dateTimeZone, dateTimeTimeZone);
			}
			this.propertyPathNames.Pop();
		}

		private string BuildPropertyPath()
		{
			StringBuilder result = new StringBuilder();
			string previousPathName = null;
			foreach (string currentPathName in this.propertyPathNames)
			{
				if (IsInlined(previousPathName))
				{
					if (IsInlined(currentPathName))
					{
						if (!StringUtils.Equals(previousPathName, currentPathName))
						{
							result.Append('.').Append(RemoveInlinedSuffix(currentPathName));
						}
					}
					else
					{
						string convertedPreviousPathName = RemoveInlinedSuffix(previousPathName);
						if (!StringUtils.Equals(convertedPreviousPathName, currentPathName))
						{
							result.Append('.').Append(currentPathName);
						}
					}
				}
				else
				{
					result.Append('.').Append(RemoveInlinedSuffix(currentPathName));
				}
				previousPathName = currentPathName;
			}
			return Ca.Infoway.Messagebuilder.StringUtils.Substring(result.ToString(), 1);
		}

		private bool IsInlined(string propertyName)
		{
			return propertyName != null && propertyName.EndsWith(INLINED_PROPERTY_SUFFIX);
		}

		private string RemoveInlinedSuffix(string propertyName)
		{
			return IsInlined(propertyName) ? Ca.Infoway.Messagebuilder.StringUtils.Substring(propertyName, 0, propertyName.Length - INLINED_PROPERTY_SUFFIX
				.Length) : propertyName;
		}

		private void RenderNonStructuralAttribute(AttributeBridge tealBean, Relationship relationship, VersionNumber version, TimeZone
			 dateTimeZone, TimeZone dateTimeTimeZone)
		{
			string type = relationship.Type;
			PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(type);
			if (formatter == null)
			{
				throw new RenderingException("Cannot support properties of type " + type);
			}
			else
			{
				string propertyPath = BuildPropertyPath();
				string xmlFragment = string.Empty;
				try
				{
					BareANY any;
					if (relationship.Fixed)
					{
						any = (BareANY)DataTypeFactory.CreateDataType(relationship.Type);
						((BareANYImpl)any).BareValue = NonStructuralHl7AttributeRenderer.GetFixedValue(relationship, version);
					}
					else
					{
						any = tealBean.GetHl7Value();
						any = this.adapterProvider.GetAdapter(any != null ? any.GetType() : null, type).Adapt(any);
					}
					string warningForIncorrectUseOfIgnore = null;
					if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED)
					{
						if (ConformanceLevelUtil.IsIgnoredNotAllowed())
						{
							warningForIncorrectUseOfIgnore = System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_CAN_NOT_BE_USED, relationship
								.Name);
						}
						else
						{
							warningForIncorrectUseOfIgnore = System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_WILL_NOT_BE_USED, relationship
								.Name);
						}
					}
					else
					{
						if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
						{
							warningForIncorrectUseOfIgnore = System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_NOT_ALLOWED, relationship.Name);
						}
					}
					if (warningForIncorrectUseOfIgnore != null)
					{
						Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, warningForIncorrectUseOfIgnore, propertyPath);
						this.result.AddHl7Error(hl7Error);
					}
					// boolean isSpecializationType = (tealBean.getHl7Value().getDataType() != tealBean.getRelationship().getType());
					// FIXME - VALIDATION - TM - SPECIALIZATION_TYPE - need to allow for specialization type to be set here???
					xmlFragment += formatter.Format(FormatContextImpl.Create(this.result, propertyPath, relationship, version, dateTimeZone, 
						dateTimeTimeZone, relationship.CodingStrength), any, GetIndent());
				}
				catch (ModelToXmlTransformationException e)
				{
					Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, e.Message, propertyPath);
					this.result.AddHl7Error(hl7Error);
				}
				RenderNewErrorsToXml(CurrentBuffer().GetChildBuilder());
				CurrentBuffer().GetChildBuilder().Append(xmlFragment);
			}
		}

		private void RenderNewErrorsToXml(StringBuilder stringBuilder)
		{
			foreach (Hl7Error hl7Error in this.result.GetHl7Errors())
			{
				if (!hl7Error.IsRenderedToXml())
				{
					stringBuilder.Append(this.xmlWarningRenderer.CreateWarning(GetIndent(), hl7Error.ToString()));
					hl7Error.MarkAsRenderedToXml();
				}
			}
		}

		private void AddNewErrorsToList(IList<string> errors)
		{
			foreach (Hl7Error hl7Error in this.result.GetHl7Errors())
			{
				if (!hl7Error.IsRenderedToXml())
				{
					errors.Add(hl7Error.ToString());
					hl7Error.MarkAsRenderedToXml();
				}
			}
		}

		private int GetIndent()
		{
			return this.buffers.Count;
		}

		public virtual void VisitRootEnd(PartBridge tealBean, Interaction interaction)
		{
			this.propertyPathNames.Pop();
		}

		public virtual void VisitRootStart(PartBridge tealBean, Interaction interaction)
		{
			this.propertyPathNames.Push(DeterminePropertyName(tealBean.GetPropertyName(), interaction));
			this.interaction = interaction;
			this.buffers.Clear();
			this.buffers.Push(new XmlRenderingVisitor.Buffer(this, interaction.Name, 0));
			CurrentBuffer().GetStructuralBuilder().Append(" xmlns=\"urn:hl7-org:v3\" ").Append("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\""
				);
		}

		public virtual ModelToXmlResult ToXml()
		{
			while (this.buffers.Count > 1)
			{
				PopBuffer();
			}
			string xml = CurrentBuffer().ToXml();
			this.result.SetXmlMessage(xml);
			return this.result;
		}

		private void PopBuffer()
		{
			XmlRenderingVisitor.Buffer buffer = this.buffers.Pop();
			if (this.buffers.Count != 0)
			{
				CurrentBuffer().GetChildBuilder().Append(buffer.ToXml());
			}
		}
	}
}
