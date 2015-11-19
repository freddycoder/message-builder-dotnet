using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.Polymorphism;
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

		private static readonly string NULL_FLAVOR_FORMAT_FOR_ASSOCIATIONS_NO_XSI_NIL = "nullFlavor=\"{0}\"";

		private static readonly string NULL_FLAVOR_FORMAT_FOR_ASSOCIATIONS = NULL_FLAVOR_FORMAT_FOR_ASSOCIATIONS_NO_XSI_NIL + " xsi:nil=\"true\"";

		internal class Buffer
		{
			private readonly string name;

			private readonly StringBuilder structuralBuilder = new StringBuilder();

			private readonly StringBuilder childBuilder = new StringBuilder();

			private readonly int indent;

			private IList<string> warnings = new List<string>();

			private IList<string> infos = new List<string>();

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
				if (!this.infos.IsEmpty())
				{
					foreach (string warning in this.infos)
					{
						builder.Append(this.xmlWarningRenderer.CreateLog("INFO", this.indent, warning));
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

			public virtual void AddInfo(string info)
			{
				this.infos.Add(info);
			}

			private readonly XmlRenderingVisitor _enclosing;
		}

		private PolymorphismHandler polymorphismHandler = new PolymorphismHandler();

		private readonly Stack<string> propertyPathNames = new Stack<string>();

		private readonly Stack<XmlRenderingVisitor.Buffer> buffers = new Stack<XmlRenderingVisitor.Buffer>();

		private Interaction interaction;

		private readonly DataTypeValueAdapterProvider adapterProvider = new DataTypeValueAdapterProvider();

		private readonly ModelToXmlResult result = new ModelToXmlResult();

		private readonly XmlWarningRenderer xmlWarningRenderer = new XmlWarningRenderer();

		private readonly Registry<PropertyFormatter> formatterRegistry;

		private readonly bool isR2;

		private readonly bool isCda;

		public XmlRenderingVisitor() : this(false, false)
		{
		}

		public XmlRenderingVisitor(bool isR2, bool isCda)
		{
			this.isR2 = isR2;
			this.isCda = isCda;
			if (isR2)
			{
				this.formatterRegistry = FormatterR2Registry.GetInstance();
			}
			else
			{
				this.formatterRegistry = FormatterRegistry.GetInstance();
			}
		}

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
			return !tealBean.IsEmpty() || ConformanceLevelUtil.IsMandatory(relationship) || ConformanceLevelUtil.IsPopulated(relationship
				) || tealBean.HasNullFlavor();
		}

		public virtual void VisitAssociationStart(PartBridge part, Relationship relationship)
		{
			if (IsSomethingToRender(part, relationship))
			{
				bool validationWarning = false;
				string warningMessage = null;
				PushPropertyPathName(DeterminePropertyName(part.GetPropertyName(), relationship), part.IsCollapsed());
				string propertyPath = BuildPropertyPath();
				string xmlElementName = DetermineXmlName(part, relationship);
				if (StringUtils.IsNotBlank(relationship.Namespaze))
				{
					xmlElementName = relationship.Namespaze + ":" + xmlElementName;
				}
				this.buffers.Push(new XmlRenderingVisitor.Buffer(this, xmlElementName, this.buffers.Count));
				AddChoiceAnnotation(part, relationship);
				if (part.IsEmpty() && (ConformanceLevelUtil.IsPopulated(relationship) || part.HasNullFlavor()))
				{
					// MBR-319 - some clients want xsi:nil suppressed
					string nf = Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(Runtime.GetProperty(NullFlavorHelper.MB_SUPPRESS_XSI_NIL_ON_NULLFLAVOR
						)) ? NULL_FLAVOR_FORMAT_FOR_ASSOCIATIONS_NO_XSI_NIL : NULL_FLAVOR_FORMAT_FOR_ASSOCIATIONS;
					CurrentBuffer().GetStructuralBuilder().Append(System.String.Format(nf, GetNullFlavor(part).CodeValue));
				}
				else
				{
					if (part.IsEmpty() && ConformanceLevelUtil.IsMandatory(relationship) && !IsTrivial(part))
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
						if (ConformanceLevelUtil.IsIgnored(relationship))
						{
							validationWarning = true;
							warningMessage = System.String.Format(ConformanceLevelUtil.IsIgnoredNotAllowed() ? ConformanceLevelUtil.ASSOCIATION_IS_IGNORED_AND_CAN_NOT_BE_USED
								 : ConformanceLevelUtil.ASSOCIATION_IS_IGNORED_AND_WILL_NOT_BE_USED, relationship.Name);
						}
						else
						{
							if (ConformanceLevelUtil.IsNotAllowed(relationship))
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

		private void AddChoiceAnnotation(PartBridge part, Relationship relationship)
		{
			NamedAndTyped choiceOptionRelationship = null;
			string choiceType = relationship.Type;
			if (relationship.Choice)
			{
				choiceOptionRelationship = BeanBridgeChoiceRelationshipResolver.ResolveChoice(part, relationship);
			}
			else
			{
				if (relationship.TemplateRelationship)
				{
					Argument argument = this.interaction.GetArgumentByTemplateParameterName(relationship.TemplateParameterName);
					if (argument != null && argument.Choice)
					{
						Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship> predicate = ChoiceSupport.ChoiceOptionTypePredicate(new string[] { 
							part.GetTypeName() });
						choiceOptionRelationship = argument.FindChoiceOption(predicate);
						choiceType = argument.Name;
					}
				}
			}
			if (choiceOptionRelationship != null)
			{
				CurrentBuffer().AddInfo("Selected option " + choiceOptionRelationship.Type + " (" + choiceOptionRelationship.Name + ") from choice "
					 + choiceType);
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
				Relationship r = relationship.GetRelationship();
				if (relationship.GetRelationship().Association || !r.HasFixedValue())
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
						if (relationship.Cardinality.Multiple)
						{
							return relationship.Name;
						}
						Relationship option = BeanBridgeChoiceRelationshipResolver.ResolveChoice(tealBean, relationship);
						if (option == null)
						{
							// log an error instead?
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

		public virtual void VisitAttribute(AttributeBridge tealBean, Relationship relationship, ConstrainedDatatype constraints, 
			VersionNumber version, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone)
		{
			PushPropertyPathName(DeterminePropertyName(tealBean.GetPropertyName(), relationship), false);
			if (relationship.Structural)
			{
				string propertyPath = BuildPropertyPath();
				HandleNotAllowedAndIgnored(relationship, propertyPath);
				// TODO - CDA - TM - may need to handle constraints for structural attributes
				new VisitorStructuralAttributeRenderer(relationship, tealBean.GetValue()).Render(CurrentBuffer().GetStructuralBuilder(), 
					propertyPath, this.result);
				AddNewErrorsToList(CurrentBuffer().GetWarnings());
			}
			else
			{
				bool hasProperty = !StringUtils.IsEmpty(tealBean.GetPropertyName());
				if (hasProperty)
				{
					RenderNonStructuralAttribute(tealBean, relationship, constraints, version, dateTimeZone, dateTimeTimeZone);
				}
				else
				{
					if (ConformanceLevelUtil.IsMandatoryOrPopulated(relationship))
					{
						IDictionary<string, string> attributes = null;
						if (ConformanceLevelUtil.IsPopulated(relationship))
						{
							attributes = new Dictionary<string, string>();
							attributes["nullFlavor"] = "NI";
						}
						string placeholderXml = XmlRenderingUtils.CreateStartElement(relationship.Name, attributes, GetIndent(), true, true);
						CurrentBuffer().GetChildBuilder().Append(placeholderXml);
					}
				}
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

		private void RenderNonStructuralAttribute(AttributeBridge tealBean, Relationship relationship, ConstrainedDatatype constraints
			, VersionNumber version, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone)
		{
			string propertyPath = BuildPropertyPath();
			BareANY hl7Value = tealBean.GetHl7Value();
			string type = DetermineActualType(relationship, hl7Value, this.result, propertyPath);
			PropertyFormatter formatter = this.formatterRegistry.Get(type);
			if (formatter == null)
			{
				throw new RenderingException("Cannot support properties of type " + type);
			}
			else
			{
				string xmlFragment = string.Empty;
				try
				{
					BareANY any = null;
					bool isMandatoryOrPopulated = ConformanceLevelUtil.IsMandatory(relationship) || ConformanceLevelUtil.IsPopulated(relationship
						);
					if (relationship.HasFixedValue())
					{
						// suppress rendering fixed values for optional or required
						if (isMandatoryOrPopulated)
						{
							any = (BareANY)DataTypeFactory.CreateDataType(relationship.Type, this.isCda && this.isR2);
							object fixedValue = NonStructuralHl7AttributeRenderer.GetFixedValue(relationship, version, this.isR2, this.result, propertyPath
								);
							((BareANYImpl)any).BareValue = fixedValue;
						}
					}
					else
					{
						any = hl7Value;
						any = this.adapterProvider.GetAdapter(any != null ? any.GetType() : null, type).Adapt(type, any);
					}
					// TODO - CDA - TM - implement default value handling
					//					boolean valueNotProvided = (any.getBareValue() == null && !any.hasNullFlavor());
					//					if (valueNotProvided && relationship.hasDefaultValue() && isMandatoryOrPopulated) {
					//						// FIXME - CDA - TM - this doesn't work - will have a class cast exception (put Object convert(Object/String?) on ANY, implement trivial in ANYImpl, implement where necessary?)
					//						
					//						any.setBareValue(relationship.getDefaultValue());
					//					}
					HandleNotAllowedAndIgnored(relationship, propertyPath);
					FormatContext context = Ca.Infoway.Messagebuilder.Marshalling.FormatContextImpl.Create(this.result, propertyPath, relationship
						, version, dateTimeZone, dateTimeTimeZone, constraints, this.isCda);
					if (!StringUtils.Equals(type, relationship.Type))
					{
						context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(type, true, context);
					}
					xmlFragment += formatter.Format(context, any, GetIndent());
					// if relationship specifies a namespace, need to add it to xml
					if (StringUtils.IsNotBlank(xmlFragment) & StringUtils.IsNotBlank(relationship.Namespaze))
					{
						xmlFragment = System.Text.RegularExpressions.Regex.Replace(xmlFragment, "<" + relationship.Name + " ", "<" + relationship
							.Namespaze + ":" + relationship.Name + " ");
						xmlFragment = System.Text.RegularExpressions.Regex.Replace(xmlFragment, "<" + relationship.Name + ">", "<" + relationship
							.Namespaze + ":" + relationship.Name + ">");
						xmlFragment = System.Text.RegularExpressions.Regex.Replace(xmlFragment, "</" + relationship.Name + ">", "</" + relationship
							.Namespaze + ":" + relationship.Name + ">");
					}
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

		private string DetermineActualType(Relationship relationship, BareANY hl7Value, Hl7Errors errors, string propertyPath)
		{
			StandardDataType newTypeEnum = (hl7Value == null ? null : hl7Value.DataType);
			return this.polymorphismHandler.DetermineActualDataType(relationship.Type, newTypeEnum, this.isCda, !this.isR2, CreateErrorLogger
				(propertyPath, errors));
		}

		private ErrorLogger CreateErrorLogger(string propertyPath, Hl7Errors errors)
		{
			return new _ErrorLogger_476(errors, propertyPath);
		}

		private sealed class _ErrorLogger_476 : ErrorLogger
		{
			public _ErrorLogger_476(Hl7Errors errors, string propertyPath)
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

		private void HandleNotAllowedAndIgnored(Relationship relationship, string propertyPath)
		{
			string warningForIncorrectUseOfIgnore = null;
			if (ConformanceLevelUtil.IsIgnored(relationship))
			{
				warningForIncorrectUseOfIgnore = System.String.Format(ConformanceLevelUtil.IsIgnoredNotAllowed() ? ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_CAN_NOT_BE_USED
					 : ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_WILL_NOT_BE_USED, relationship.Name);
			}
			else
			{
				if (ConformanceLevelUtil.IsNotAllowed(relationship))
				{
					warningForIncorrectUseOfIgnore = System.String.Format(ConformanceLevelUtil.ATTRIBUTE_IS_NOT_ALLOWED, relationship.Name);
				}
			}
			if (warningForIncorrectUseOfIgnore != null)
			{
				this.result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, warningForIncorrectUseOfIgnore, propertyPath));
			}
		}

		private void RenderNewErrorsToXml(StringBuilder stringBuilder)
		{
			foreach (Hl7Error hl7Error in this.result.GetHl7Errors())
			{
				if (!hl7Error.IsRenderedToXml())
				{
					stringBuilder.Append(this.xmlWarningRenderer.CreateWarning(GetIndent(), hl7Error.ToString(), string.Empty));
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
			this.buffers.Push(new XmlRenderingVisitor.Buffer(this, this.isCda ? "ClinicalDocument" : interaction.Name, 0));
			CurrentBuffer().GetStructuralBuilder().Append(" xmlns=\"urn:hl7-org:v3\" ");
			CurrentBuffer().GetStructuralBuilder().Append("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
			if (this.isCda)
			{
				CurrentBuffer().GetStructuralBuilder().Append("xmlns:sdtc=\"urn:hl7-org:sdtc\" xmlns:cda=\"urn:hl7-org:v3\"");
			}
			else
			{
				CurrentBuffer().GetStructuralBuilder().Append("ITSVersion=\"XML_1.0\"");
			}
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

		public virtual void LogError(Hl7Error error)
		{
			this.result.AddHl7Error(error);
		}

		public virtual string GetCurrentPropertyPath()
		{
			return BuildPropertyPath();
		}
	}
}
