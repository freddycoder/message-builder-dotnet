using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// II - Installer Identifier
	/// Parses an II element into a II object.
	/// </summary>
	/// <remarks>
	/// II - Installer Identifier
	/// Parses an II element into a II object. The element looks like this:
	/// 
	/// CeRx standards claim that both attributes are required, although extension
	/// is sometimes unused.
	/// The HL7 standard defines the assigningAuthorityName attribute, but that
	/// has been left out of the CeRx implementation.
	/// According to CeRx: Root has a limit of 100 characters, extension of 20
	/// characters. These limits are not currently enforced by this class.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-II
	/// </remarks>
	[DataTypeHandler("II")]
	internal class IiElementParser : AbstractSingleElementParser<Identifier>
	{
		private static readonly string II = "II";

		private static readonly string II_TOKEN = "II.TOKEN";

		private static readonly string II_BUS = "II.BUS";

		private static readonly string II_PUBLIC = "II.PUBLIC";

		private static readonly string II_OID = "II.OID";

		private static readonly string II_VER = "II.VER";

		private static readonly string II_BUS_AND_VER = "II.BUS_AND_VER";

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new IIImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Identifier ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type returnType, XmlToModelResult
			 xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			string root = GetMandatoryAttributeValue(element, "root", xmlToModelResult);
			string extension = GetAttributeValue(element, "extension");
			string type = GetType(context, element, xmlToModelResult);
			// type might have resolved to something different if this II.x is abstract (II, II_BUS_AND_VER), so set it again
			SetDataType(type, result);
			if (StringUtils.IsBlank(root))
			{
			}
			else
			{
				// skip it... already handled
				if (II_TOKEN.Equals(type))
				{
					ValidateRootAsUuid(element, root, xmlToModelResult);
					ValidateUnallowedAttributes(type, element, xmlToModelResult, "extension");
					ValidateUnallowedAttributes(type, element, xmlToModelResult, "use");
					ValidateUnallowedAttributes(type, element, xmlToModelResult, "displayable");
				}
				else
				{
					if (II_BUS.Equals(type))
					{
						if (!IsUuid(root))
						{
							ValidateRootAsOid(root, element, xmlToModelResult);
						}
						else
						{
							ValidateRootAsUuid(element, root, xmlToModelResult);
							ValidateUnallowedAttributes(type, element, xmlToModelResult, "extension");
						}
						ValidateUnallowedAttributes(type, element, xmlToModelResult, "displayable");
						ValidateAttributeEquals(type, element, xmlToModelResult, "use", "BUS");
					}
					else
					{
						if (II_OID.Equals(type))
						{
							ValidateRootAsOid(root, element, xmlToModelResult);
							ValidateUnallowedAttributes(type, element, xmlToModelResult, "extension");
							ValidateUnallowedAttributes(type, element, xmlToModelResult, "use");
							ValidateUnallowedAttributes(type, element, xmlToModelResult, "displayable");
						}
						else
						{
							if (II_PUBLIC.Equals(type))
							{
								ValidateRootAsOid(root, element, xmlToModelResult);
								ValidateAttributeEquals(type, element, xmlToModelResult, "displayable", "true");
								// Redmine 11293 - TM - must have use=BUS, but not for MR2007 (use is not permitted in this case)
								if (IsMR2009(context.GetVersion()))
								{
									ValidateAttributeEquals(type, element, xmlToModelResult, "use", "BUS");
								}
								else
								{
									ValidateUnallowedAttributes(type, element, xmlToModelResult, "use");
								}
							}
							else
							{
								if (II_VER.Equals(type))
								{
									ValidateRootAsUuid(element, root, xmlToModelResult);
									ValidateUnallowedAttributes(type, element, xmlToModelResult, "extension");
									ValidateUnallowedAttributes(type, element, xmlToModelResult, "displayable");
									ValidateAttributeEquals(type, element, xmlToModelResult, "use", "VER");
								}
							}
						}
					}
				}
			}
			ValidateUnallowedAttributes(type, element, xmlToModelResult, "assigningAuthorityName");
			return new Identifier(root, extension);
		}

		private bool IsMR2009(VersionNumber version)
		{
			return SpecificationVersion.IsVersion(SpecificationVersion.R02_04_02, version) || SpecificationVersion.IsVersion(SpecificationVersion
				.R02_04_03, version);
		}

		private string GetType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			string type = context.Type;
			if (IsSpecializationTypeAllowed(context, type))
			{
				if (II_BUS_AND_VER.Equals(type) || II.Equals(type))
				{
					//   || II.equals(type)   ???? if plain II, then probably CeRx... (don't do extra validations)
					string specializationType = GetAttributeValue(element, AbstractElementParser.SPECIALIZATION_TYPE);
					if (specializationType == null)
					{
						xmlToModelResult.AddHl7Error(Hl7Error.CreateMissingMandatoryAttributeError(AbstractElementParser.SPECIALIZATION_TYPE, element
							));
					}
					else
					{
						if (II_BUS_AND_VER.Equals(type) && !II_BUS.Equals(specializationType) && !II_VER.Equals(specializationType))
						{
							xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Specialization type must be II.BUS or II.VER. Invalid specialization type "
								 + specializationType + " (" + XmlDescriber.DescribeSingleElement(element) + ")", element));
						}
						else
						{
							type = specializationType;
						}
					}
				}
			}
			return type;
		}

		private bool IsSpecializationTypeAllowed(ParseContext context, string type)
		{
			return !SpecificationVersion.IsVersion(SpecificationVersion.V01R04_3, context.GetVersion()) && !(SpecificationVersion.IsVersion
				(SpecificationVersion.V02R02_AB, context.GetVersion()) && II.Equals(type));
		}

		private void ValidateAttributeEquals(string type, XmlElement element, XmlToModelResult xmlToModelResult, string attributeName
			, string attributeValue)
		{
			if (!element.HasAttribute(attributeName))
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Data type " + type + " requires the attribute {0}=\"{1}\" ({2})"
					, attributeName, XmlStringEscape.Escape(attributeValue), XmlDescriber.DescribeSingleElement(element)), element));
			}
			else
			{
				if (!StringUtils.Equals(element.GetAttribute(attributeName), attributeValue))
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Data type " + type + " expected the attribute {0}=\"{1}\" ({2})"
						, attributeName, XmlStringEscape.Escape(attributeValue), XmlDescriber.DescribeSingleElement(element)), element));
				}
			}
		}

		private void ValidateRootAsUuid(XmlElement element, string root, XmlToModelResult xmlToModelResult)
		{
			if (!IsUuid(root))
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "root '" + root + "' should be a UUID. (" + XmlDescriber
					.DescribeSingleElement(element) + ")", element));
			}
		}

		private bool IsUuid(string root)
		{
			try
			{
				UUID.FromString(root);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private void ValidateRootAsOid(string root, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			if (!IsOid(root))
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The oid, \"" + root + "\" does not appear to be a valid oid"
					, element));
			}
		}

		internal virtual bool IsOid(string root)
		{
			if (StringUtils.IsBlank(root) || !root.Contains("."))
			{
				return false;
			}
			else
			{
				bool oid = true;
				while (root.Contains("."))
				{
					string prefix = StringUtils.SubstringBefore(root, ".");
					oid &= (StringUtils.IsNotBlank(prefix) && StringUtils.IsNumeric(prefix));
					root = StringUtils.SubstringAfter(root, ".");
				}
				if (StringUtils.IsBlank(root))
				{
					oid = false;
				}
				else
				{
					oid &= StringUtils.IsNumeric(root);
				}
				return oid;
			}
		}
	}
}
