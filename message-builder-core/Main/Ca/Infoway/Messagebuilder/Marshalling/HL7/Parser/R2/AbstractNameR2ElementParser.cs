using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>Abstract parser class for all name parsers.</summary>
	/// <remarks>Abstract parser class for all name parsers.</remarks>
	/// <TBD></TBD>
	internal abstract class AbstractNameR2ElementParser<V> : AbstractSingleElementParser<V> where V : EntityName
	{
		private static readonly string USE_ATTRIBUTE = "use";

		private static readonly string VALID_TIME_ELEMENT = "validTime";

		private static readonly string ORGANIZATION_NAME_TYPE = "ON";

		private static readonly string QUALIFIER_ATTRIBUTE = "qualifier";

		private static readonly string NULLFLAVOR_ATTRIBUTE = "nullFlavor";

		private readonly IvlTsR2ElementParser ivlTsParser = new IvlTsR2ElementParser();

		protected abstract V CreateEntityName();

		protected override V ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			// parse parts (including qualifier)
			IList<EntityNamePart> parts = ParseNameParts(context, node.ChildNodes, xmlToModelResult);
			// parse uses
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse> nameUses = ParseNameUses(GetAttributeValue(node, AbstractNameR2ElementParser
				<V>.USE_ATTRIBUTE), (XmlElement)node, xmlToModelResult);
			// parser valid time
			Interval<PlatformDate> validTime = ParseValidTime((XmlElement)node, context, xmlToModelResult);
			V entityName = CreateEntityName();
			entityName.Parts.AddAll(parts);
			entityName.Uses.AddAll(nameUses);
			entityName.ValidTime = validTime;
			return entityName;
		}

		private IList<EntityNamePart> ParseNameParts(ParseContext context, XmlNodeList childNodes, XmlToModelResult xmlToModelResult
			)
		{
			IList<EntityNamePart> parts = new List<EntityNamePart>();
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				if (childNode is XmlElement)
				{
					XmlElement element = (XmlElement)childNode;
					string name = NodeUtil.GetLocalOrTagName(element);
					if (!StringUtils.Equals(AbstractNameR2ElementParser<V>.VALID_TIME_ELEMENT, name))
					{
						if (StringUtils.Equals("TN", context.Type))
						{
							RecordError("TN fields only support text and a single (optional) validTime element. Found element: " + name, element, xmlToModelResult
								);
						}
						else
						{
							NullFlavor nullFlavor = GetNullFlavor(element, xmlToModelResult);
							string value = GetTextValue(element, xmlToModelResult);
							EntityNamePartQualifier qualifier = GetQualifier(context, element, xmlToModelResult);
							if (StringUtils.IsNotBlank(value) || nullFlavor != null)
							{
								NamePartType namePartType = GetNamePartType(name, context.Type, element, xmlToModelResult);
								if (namePartType != null)
								{
									parts.Add(new EntityNamePart(value, namePartType, qualifier, nullFlavor));
								}
							}
						}
					}
				}
				else
				{
					if (IsNonBlankTextNode(childNode))
					{
						parts.Add(new EntityNamePart(childNode.Value.Trim(), null));
					}
				}
			}
			return parts;
		}

		private NullFlavor GetNullFlavor(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			NullFlavor result = null;
			if (element.HasAttribute(AbstractNameR2ElementParser<V>.NULLFLAVOR_ATTRIBUTE))
			{
				string nullFlavorString = GetAttributeValue(element, AbstractNameR2ElementParser<V>.NULLFLAVOR_ATTRIBUTE);
				if (StringUtils.IsNotBlank(nullFlavorString))
				{
					NullFlavor nullFlavor = CodeResolverRegistry.Lookup<NullFlavor>(nullFlavorString);
					if (nullFlavor == null)
					{
						RecordError("Invalid nullFlavor detected in name part: " + nullFlavorString, element, xmlToModelResult);
					}
					result = nullFlavor;
				}
				else
				{
					RecordError("NullFlavor may not be blank.", element, xmlToModelResult);
				}
			}
			return result;
		}

		private EntityNamePartQualifier GetQualifier(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			EntityNamePartQualifier result = null;
			if (element.HasAttribute(AbstractNameR2ElementParser<V>.QUALIFIER_ATTRIBUTE))
			{
				string qualifierString = GetAttributeValue(element, AbstractNameR2ElementParser<V>.QUALIFIER_ATTRIBUTE);
				if (StringUtils.IsNotBlank(qualifierString))
				{
					EntityNamePartQualifier qualifier = CodeResolverRegistry.Lookup<EntityNamePartQualifier>(qualifierString);
					if (qualifier == null)
					{
						RecordError("Invalid qualifier detected in name part: " + qualifierString, element, xmlToModelResult);
					}
					result = qualifier;
					if (StringUtils.Equals("PN", context.Type) && StringUtils.Equals(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
						.LEGALSTATUS.CodeValue, qualifierString))
					{
						RecordError("Invalid qualifier for PN name part: " + qualifierString, element, xmlToModelResult);
					}
				}
				else
				{
					RecordError("Qualifier may not be blank.", element, xmlToModelResult);
				}
			}
			return result;
		}

		private bool IsNonBlankTextNode(XmlNode childNode)
		{
			return childNode.Value != null && childNode.NodeType == System.Xml.XmlNodeType.Text && !StringUtils.IsBlank(childNode.Value
				);
		}

		private string GetTextValue(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			string result = NodeUtil.GetTextValue(element, true);
			if (StringUtils.IsBlank(result))
			{
				result = null;
				if (!element.HasAttribute(AbstractNameR2ElementParser<V>.NULLFLAVOR_ATTRIBUTE))
				{
					RecordError("Expected PN child node \"" + element.Name + "\" to have a text node", element, xmlToModelResult);
				}
			}
			return result;
		}

		private NamePartType GetNamePartType(string value, string type, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			NamePartType partType = null;
			try
			{
				if (StringUtils.Equals(AbstractNameR2ElementParser<V>.ORGANIZATION_NAME_TYPE, type))
				{
					partType = GetNamePartType<OrganizationNamePartType>(value);
				}
				else
				{
					partType = GetNamePartType<PersonNamePartType>(value);
				}
			}
			catch (XmlToModelTransformationException e)
			{
				RecordError(e.Message, element, xmlToModelResult);
			}
			return partType;
		}

		private ICollection<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse> ParseNameUses(string usesString, XmlElement
			 element, XmlToModelResult xmlToModelResult)
		{
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse> uses = new System.Collections.Generic.SortedSet<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse
				>();
			if (StringUtils.IsNotBlank(usesString))
			{
				StringTokenizer tokenizer = new StringTokenizer(usesString);
				while (tokenizer.HasMoreElements())
				{
					string token = tokenizer.NextToken();
					Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse nameUse = CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse
						>(token);
					if (nameUse != null)
					{
						uses.Add(nameUse);
					}
					else
					{
						RecordError("Name use '" + token + "' not recognized.", element, xmlToModelResult);
					}
				}
			}
			return uses;
		}

		private Interval<PlatformDate> ParseValidTime(XmlElement node, ParseContext context, XmlToModelResult xmlToModelResult)
		{
			Interval<PlatformDate> validTime = null;
			bool foundValidTime = false;
			bool loggedValidTimeError = false;
			XmlNodeList childNodes = node.ChildNodes;
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				string childElementName = NodeUtil.GetLocalOrTagName(childNode);
				bool isValidTime = AbstractNameR2ElementParser<V>.VALID_TIME_ELEMENT.Equals(childElementName);
				if (!loggedValidTimeError && foundValidTime)
				{
					loggedValidTimeError = true;
					RecordError("Only one validTime is allowed, and it must come after all name parts", (XmlElement)node, xmlToModelResult);
				}
				if (childNode is XmlElement)
				{
					if (isValidTime)
					{
						foundValidTime = true;
						ParseContext newContext = ParseContextImpl.Create("IVL<TS>", context);
						BareANY ivlTsAny = this.ivlTsParser.Parse(newContext, Arrays.AsList(childNode), xmlToModelResult);
						if (ivlTsAny != null && ivlTsAny.BareValue != null)
						{
							DateInterval dateInterval = (DateInterval)ivlTsAny.BareValue;
							validTime = dateInterval == null ? null : dateInterval.Interval;
						}
					}
				}
			}
			return validTime;
		}

		private void RecordError(string message, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message + " (" + XmlDescriber.DescribeSingleElement
				(element) + ")", element));
		}
	}
}
