using System.Text;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Error
{
	public class Hl7Error
	{
		private readonly Hl7ErrorCode hl7ErrorCode;

		private readonly ErrorLevel hl7ErrorLevel;

		private readonly string message;

		private readonly string path;

		private string beanPath;

		[System.NonSerialized]
		private bool renderedToXml = false;

		public Hl7Error(Hl7ErrorCode hl7ErrorCode, ErrorLevel hl7ErrorLevel, string message, string beanPath)
		{
			// must be set explicitly - later - when passing in an xpath
			this.hl7ErrorCode = hl7ErrorCode;
			this.hl7ErrorLevel = hl7ErrorLevel;
			this.message = message;
			this.path = null;
			this.beanPath = beanPath;
		}

		public Hl7Error(Hl7ErrorCode hl7ErrorCode, string message, string beanPath) : this(hl7ErrorCode, ErrorLevel.ERROR, message
			, beanPath)
		{
		}

		public Hl7Error(Hl7ErrorCode hl7ErrorCode, string message, XmlElement element) : this(hl7ErrorCode, ErrorLevel.ERROR, message
			, (XmlNode)element)
		{
		}

		public Hl7Error(Hl7ErrorCode hl7ErrorCode, ErrorLevel hl7ErrorLevel, string message, XmlElement element) : this(hl7ErrorCode
			, hl7ErrorLevel, message, (XmlNode)element)
		{
		}

		public Hl7Error(Hl7ErrorCode hl7ErrorCode, string message, XmlAttribute attr) : this(hl7ErrorCode, ErrorLevel.ERROR, message
			, (XmlNode)attr)
		{
		}

		public Hl7Error(Hl7ErrorCode hl7ErrorCode, ErrorLevel hl7ErrorLevel, string message, XmlAttribute attr) : this(hl7ErrorCode
			, hl7ErrorLevel, message, (XmlNode)attr)
		{
		}

		public Hl7Error(Hl7ErrorCode hl7ErrorCode, string message, XmlNode node) : this(hl7ErrorCode, ErrorLevel.ERROR, message, 
			node)
		{
		}

		public Hl7Error(Hl7ErrorCode hl7ErrorCode, ErrorLevel hl7ErrorLevel, string message, XmlNode node)
		{
			this.hl7ErrorCode = hl7ErrorCode;
			this.hl7ErrorLevel = hl7ErrorLevel;
			this.message = message;
			this.path = XmlDescriber.DescribePath(node);
		}

		public virtual Hl7ErrorCode GetHl7ErrorCode()
		{
			return hl7ErrorCode;
		}

		public virtual ErrorLevel GetHl7ErrorLevel()
		{
			return hl7ErrorLevel;
		}

		public virtual string GetMessage()
		{
			return message;
		}

		public virtual string GetPath()
		{
			return this.path;
		}

		public virtual string GetBeanPath()
		{
			return this.beanPath;
		}

		public virtual void SetBeanPath(string beanPath)
		{
			this.beanPath = beanPath;
		}

		public virtual bool IsRenderedToXml()
		{
			return renderedToXml;
		}

		public virtual void MarkAsRenderedToXml()
		{
			this.renderedToXml = true;
		}

		public virtual int GetErrorDepth()
		{
			if (StringUtils.IsNotBlank(this.path))
			{
				return this.path.Split("/").Length - 1;
			}
			else
			{
				if (StringUtils.IsNotBlank(this.beanPath))
				{
					return this.path.Split("\\.").Length;
				}
			}
			return 0;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else
			{
				if (GetType() != obj.GetType())
				{
					return false;
				}
				else
				{
					Ca.Infoway.Messagebuilder.Error.Hl7Error that = (Ca.Infoway.Messagebuilder.Error.Hl7Error)obj;
					return new EqualsBuilder().Append(this.hl7ErrorCode, that.hl7ErrorCode).Append(this.hl7ErrorLevel, that.hl7ErrorLevel).Append
						(this.message, that.message).Append(this.path, that.path).IsEquals();
				}
			}
		}

		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.hl7ErrorCode).Append(this.hl7ErrorLevel).Append(this.message).Append(this.path).
				ToHashCode();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(this.hl7ErrorLevel);
			sb.Append(" - ");
			sb.Append(this.hl7ErrorCode);
			sb.Append(" : ");
			sb.Append(this.message);
			if (StringUtils.IsNotBlank(this.path))
			{
				sb.Append(" (");
				sb.Append(this.path);
				sb.Append(")");
			}
			if (StringUtils.IsNotBlank(this.beanPath))
			{
				sb.Append(" (");
				sb.Append(this.beanPath);
				sb.Append(")");
			}
			return sb.ToString();
		}

		/// <summary>
		/// This error message is used when a mandatory attribute is missing from an
		/// XML element.
		/// </summary>
		/// <remarks>
		/// This error message is used when a mandatory attribute is missing from an
		/// XML element.
		/// </remarks>
		/// <param name="name">- the name of the mandatory attribute</param>
		/// <param name="base">- the element that should provide the attribute, but does not.</param>
		/// <returns>an HL7 error object</returns>
		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateMissingMandatoryAttributeError(string name, XmlElement @base
			)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, System.String.Format("Expected mandatory attribute \"{0}\" for element ({1})"
				, name, XmlDescriber.DescribeSingleElement(@base)), @base);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateMissingPopulatedAttributeError(string name, XmlElement @base
			)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, System.String.Format("Expected populated attribute \"{0}\" for element ({1})"
				, name, XmlDescriber.DescribeSingleElement(@base)), @base);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateInvalidFixedValueAttributeError(XmlAttribute attr, string fixedValue
			)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, System.String.Format("Fixed attribute \"{0}\" should have a value of \"{1}\" but was \"{2}\""
				, attr.Name, fixedValue, attr.Value), attr);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateInvalidBooleanValueError(XmlElement element, XmlAttribute attr
			)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Expected BL type to have value of either \"true\" or \"false\" ({0})"
				, XmlDescriber.DescribeSingleElement(element)), ChooseNonNullCase(element, attr));
		}

		private static XmlNode ChooseNonNullCase(XmlElement element, XmlAttribute attr)
		{
			return attr == null ? (XmlNode)element : (XmlNode)attr;
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateIncorrectCapitalizationBooleanValueError(string unparsedBoolean
			, XmlElement element, XmlAttribute attr)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("BL type is case sensitive.  Please use \"{0}\" instead of \"{1}\" ({2})"
				, unparsedBoolean.ToLower(), unparsedBoolean, XmlDescriber.DescribeSingleElement(element)), ChooseNonNullCase(element, attr
				));
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateMandatoryBooleanValueError(XmlElement element, XmlAttribute 
			attr)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("BL value is mandatory, and must be either \"true\" or \"false\" ({0})"
				, XmlDescriber.DescribeSingleElement(element)), ChooseNonNullCase(element, attr));
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateUnknownStructuralTypeError(string type, string name, XmlElement
			 @base, XmlAttribute attr)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Cannot handle structural attribute \"{0}\" of type \"{1}\" ({2})"
				, XmlDescriber.DescribeSingleElement(@base)), attr);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateInvalidTypeError(string specializationType, string parentType
			, XmlElement element)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Cannot support properties of type \"{0}\" for \"{1}\""
				, specializationType, parentType), element);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateEmptyCodeValueError(XmlElement @base, XmlAttribute attr)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("CS code must be provided ({0})"
				, XmlDescriber.DescribeSingleElement(@base)), ChooseNonNullCase(@base, attr));
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateUnknownStructuralAttributeError(XmlElement @base, XmlAttribute
			 attr)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Unknown structural attribute \"{0}\".  Attribute cannot be mapped to any relationship in the message. ({1})"
				, attr.Name, XmlDescriber.DescribeSingleElement(@base)), attr);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateMissingMandatoryAssociationError(string xmlName, XmlElement 
			@base)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, System.String.Format("Expected mandatory association \"{0}\" for element ({1})"
				, xmlName, XmlDescriber.DescribeSingleElement(@base)), @base);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateMissingPopulatedAssociationError(string xmlName, XmlElement 
			@base)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, System.String.Format("Expected populated association \"{0}\" for element ({1})"
				, xmlName, XmlDescriber.DescribeSingleElement(@base)), @base);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateWrongNumberOfAssociationsError(string xmlName, XmlElement @base
			, int size, Cardinality cardinality)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.NUMBER_OF_ASSOCIATIONS_INCORRECT_FOR_CARDINALITY, System.String.Format
				("Association \"{0}\" has a cardinality of \"{1}\", but {2} occurrences were found ({3}). For cases where the association only supports a single value, only the first occurence will have been retained."
				, xmlName, cardinality, size, XmlDescriber.DescribeSingleElement(@base)), @base);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateMissingNamespace(string xmlNamespace, XmlElement documentElement
			)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, System.String.Format("Message should define namespace \"\" ({0}) "
				, XmlDescriber.DescribeSingleElement(documentElement)), documentElement);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateUnknownChildElementError(XmlElement element)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, System.String.Format("Unknown child element \"{0}\" will be ignored."
				, NodeUtil.GetLocalOrTagName(element)), element);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateUnknownInteractionError(string interactionId, XmlElement element
			)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.UNSUPPORTED_INTERACTION, System.String.Format("Unknown interaction \"{0}\"."
				, interactionId), element);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateMandatoryAttributeIsNullError(string elementName, string nullFlavor
			, XmlElement element)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, System.String.Format("Attribute \"{0}\" is mandatory, but is specified as nullFlavor=\"{1}\"."
				, elementName, nullFlavor), element);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateRequiredAttributeIsNullError(string elementName, string nullFlavor
			, XmlElement element)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, System.String.Format("Attribute \"{0}\" is required, but is specified as nullFlavor=\"{1}\"."
				, elementName, nullFlavor), element);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateNullFlavorMissingXsiNilError(string elementName, XmlElement 
			element)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, ErrorLevel.WARNING, System.String.Format
				("Association \"{0}\" has a nullFlavor, but does not specify xsi:nil=\"true\".", elementName), element);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateIgnoredAsNotAllowedConformanceLevelRelationshipError(string 
			xmlName, XmlElement @base)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.IGNORED_CONFORMANCE_NOT_ALLOWED_IS_SET, System.String.Format
				("Ignored Conformance Level for relationship \"{0}\" for element ({1}) is not permitted", xmlName, XmlDescriber.DescribeSingleElement
				(@base)), @base);
		}

		public static Ca.Infoway.Messagebuilder.Error.Hl7Error CreateNotAllowedConformanceLevelRelationshipError(string xmlName, 
			XmlElement @base)
		{
			return new Ca.Infoway.Messagebuilder.Error.Hl7Error(Hl7ErrorCode.NOT_ALLOWED_CONFORMANCE_IS_SET, System.String.Format("Not Allowed Conformance Level for relationship \"{0}\" for element ({1}) is not permitted"
				, xmlName, XmlDescriber.DescribeSingleElement(@base)), @base);
		}
	}
}
