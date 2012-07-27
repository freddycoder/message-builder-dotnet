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
		private static readonly string NULL_FLAVOR_FORMAT_FOR_ASSOCIATIONS = "nullFlavor=\"{0}\" xsi:nil=\"true\"";

		internal class Buffer
		{
			private readonly string name;

			private readonly StringBuilder structuralBuilder = new StringBuilder();

			private readonly StringBuilder childBuilder = new StringBuilder();

			private readonly int indent;

			private string warning;

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
				if (StringUtils.IsNotBlank(this.warning))
				{
					builder.Append(new XmlWarningRenderer().CreateWarning(this.indent, this.warning));
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

			public virtual string GetWarning()
			{
				return this.warning;
			}

			public virtual void SetWarning(string warning)
			{
				this.warning = warning;
			}

			private readonly XmlRenderingVisitor _enclosing;
		}

		private readonly Stack<string> propertyPathNames = new Stack<string>();

		private readonly Stack<XmlRenderingVisitor.Buffer> buffers = new Stack<XmlRenderingVisitor.Buffer>();

		private Interaction interaction;

		private readonly DataTypeValueAdapterProvider adapterProvider = new DataTypeValueAdapterProvider();

		private readonly ModelToXmlResult result = new ModelToXmlResult();

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
				this.propertyPathNames.Push(part.GetPropertyName());
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
						CurrentBuffer().SetWarning("Mandatory association has no data. (" + relationship.Name + ")");
					}
					else
					{
						if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED)
						{
							CurrentBuffer().SetWarning(System.String.Format(ConformanceLevelUtil.IsIgnoredNotAllowed() ? ConformanceLevelUtil.ASSOCIATION_IS_IGNORED_AND_CAN_NOT_BE_USED
								 : ConformanceLevelUtil.ASSOCIATION_IS_IGNORED_AND_WILL_NOT_BE_USED, relationship.Name));
						}
						else
						{
							if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
							{
								CurrentBuffer().SetWarning(System.String.Format(ConformanceLevelUtil.ASSOCIATION_IS_NOT_ALLOWED, relationship.Name));
							}
						}
					}
				}
			}
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
			this.propertyPathNames.Push(tealBean.GetPropertyName());
			if (relationship.Structural)
			{
				if (StringUtils.IsBlank(CurrentBuffer().GetWarning()) && relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
					.IGNORED)
				{
					CurrentBuffer().SetWarning(System.String.Format(ConformanceLevelUtil.IsIgnoredNotAllowed() ? ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_CAN_NOT_BE_USED
						 : ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_WILL_NOT_BE_USED, relationship.Name));
				}
				else
				{
					if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
					{
						CurrentBuffer().SetWarning(System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_NOT_ALLOWED, relationship.Name));
					}
				}
				new VisitorStructuralAttributeRenderer(relationship, tealBean.GetValue()).Render(CurrentBuffer().GetStructuralBuilder());
			}
			else
			{
				RenderNonStructuralAttribute(tealBean, relationship, version, dateTimeZone, dateTimeTimeZone);
			}
			this.propertyPathNames.Pop();
		}

		// remove(this.propertyPathNames.size() - 1);
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
				try
				{
					BareANY any;
					if (relationship.Fixed)
					{
						any = (BareANY)DataTypeFactory.CreateDataType(relationship.Type);
						((BareANYImpl)any).BareValue = NonStructuralHl7AttributeRenderer.GetFixedValue(relationship);
					}
					else
					{
						any = tealBean.GetHl7Value();
						any = this.adapterProvider.GetAdapter(any != null ? any.GetType() : null, type).Adapt(any);
					}
					//				boolean isSpecializationType = (tealBean.getHl7Value().getDataType() != tealBean.getRelationship().getType());
					// FIXME - SPECIALIZATION_TYPE - need to allow for specialization type to be set here
					string xmlFragment = string.Empty;
					if (StringUtils.IsBlank(CurrentBuffer().GetWarning()) && relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
						.IGNORED)
					{
						if (ConformanceLevelUtil.IsIgnoredNotAllowed())
						{
							xmlFragment += new XmlWarningRenderer().CreateWarning(0, System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_CAN_NOT_BE_USED
								, relationship.Name));
						}
						else
						{
							xmlFragment += new XmlWarningRenderer().CreateWarning(0, System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_WILL_NOT_BE_USED
								, relationship.Name));
						}
					}
					else
					{
						if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
						{
							xmlFragment += new XmlWarningRenderer().CreateWarning(0, System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_NOT_ALLOWED
								, relationship.Name));
						}
					}
					xmlFragment += formatter.Format(FormatContextImpl.Create(relationship, version, dateTimeZone, dateTimeTimeZone), any, GetIndent
						());
					CurrentBuffer().GetChildBuilder().Append(xmlFragment);
				}
				catch (ModelToXmlTransformationException e)
				{
					string propertyPath = StringUtils.Join(this.propertyPathNames, ".");
					Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, e.Message, propertyPath);
					this.result.AddHl7Error(hl7Error);
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
			this.propertyPathNames.Push(tealBean.GetPropertyName());
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
			return result;
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
