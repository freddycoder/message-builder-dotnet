using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public class NullFlavorHelper
	{
		internal static readonly string NULL_FLAVOR_ATTRIBUTE_NAME = "nullFlavor";

		internal static readonly string NULL_FLAVOR_XSI_NIL_ATTRIBUTE_NAME = "xsi:nil";

		private readonly XmlNode node;

		private readonly XmlToModelResult xmlToModelResult;

		private readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel;

		private readonly bool isAssociation;

		public NullFlavorHelper(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, XmlNode node, XmlToModelResult xmlToModelResult
			, bool isAssociation)
		{
			this.conformanceLevel = conformanceLevel;
			this.node = node;
			this.xmlToModelResult = xmlToModelResult;
			this.isAssociation = isAssociation;
		}

		public virtual NullFlavor ParseNullNode()
		{
			string attributeValue = GetAttributeValue(node, NULL_FLAVOR_ATTRIBUTE_NAME);
			NullFlavor nullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.Lookup(attributeValue);
			if (this.conformanceLevel != null && this.conformanceLevel == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
			{
				xmlToModelResult.AddHl7Error(Hl7Error.CreateMandatoryAttributeIsNullError(NodeUtil.GetLocalOrTagName((XmlElement)node), GetAttributeValue
					(node, NULL_FLAVOR_ATTRIBUTE_NAME), (XmlElement)node));
			}
			else
			{
				if (this.conformanceLevel != null && this.conformanceLevel == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED)
				{
					xmlToModelResult.AddHl7Error(Hl7Error.CreateRequiredAttributeIsNullError(NodeUtil.GetLocalOrTagName((XmlElement)node), GetAttributeValue
						(node, NULL_FLAVOR_ATTRIBUTE_NAME), (XmlElement)node));
				}
				else
				{
					if (this.isAssociation && !StringUtils.Equals(GetAttributeValue(node, NULL_FLAVOR_XSI_NIL_ATTRIBUTE_NAME), "true"))
					{
						xmlToModelResult.AddHl7Error(Hl7Error.CreateNullFlavorMissingXsiNilError(NodeUtil.GetLocalOrTagName((XmlElement)node), (XmlElement
							)node));
					}
				}
			}
			return nullFlavor;
		}

		public virtual bool HasValidNullFlavorAttribute()
		{
			string attributeValue = GetAttributeValue(node, NULL_FLAVOR_ATTRIBUTE_NAME);
			if (attributeValue == null)
			{
				return false;
			}
			else
			{
				if (StringUtils.IsEmpty(attributeValue) || Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.Lookup(attributeValue
					) == null)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, System.String.Format("The nullFavor attribute value \"{0}\" is not valid ({1})"
						, attributeValue, XmlDescriber.DescribeSingleElement((XmlElement)node)), (XmlElement)node));
					return false;
				}
			}
			return true;
		}

		private string GetAttributeValue(XmlNode node, string attributeName)
		{
			return node != null && node is XmlElement ? GetAttributeValue((XmlElement)node, attributeName) : null;
		}

		protected virtual string GetAttributeValue(XmlElement node, string attributeName)
		{
			return node != null && node.HasAttribute(attributeName) ? node.GetAttribute(attributeName) : null;
		}
	}
}
