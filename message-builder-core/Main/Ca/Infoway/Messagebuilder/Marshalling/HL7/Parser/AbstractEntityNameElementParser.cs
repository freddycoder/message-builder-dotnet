using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal abstract class AbstractEntityNameElementParser : AbstractSingleElementParser<EntityName>, NameParser
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			EntityName result = ParseNode(node, xmlToModelResult);
			result.Uses.AddAll((GetNameUses(GetAttributeValue(node, "use"), (XmlElement)node, xmlToModelResult)));
			ValidateName(result, context, (XmlElement)node, xmlToModelResult);
			return result;
		}

		protected virtual void ValidateName(EntityName result, ParseContext context, XmlElement element, Hl7Errors errors)
		{
		}

		// leave this up to subclasses to decide if they want to do any validations
		protected virtual ICollection<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse> GetNameUses(string nameUseAttribute
			, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse> uses = new HashSet<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse
				>();
			if (nameUseAttribute != null)
			{
				StringTokenizer tokenizer = new StringTokenizer(nameUseAttribute);
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
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Name use '" + token + "' not recognized.", element
							));
					}
				}
			}
			return uses;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract EntityName ParseNode(XmlNode node, XmlToModelResult xmlToModelResult);

		public virtual bool IsParseable(XmlNode node, ParseContext parseContext)
		{
			bool result = false;
			try
			{
				Parse(parseContext, node, new XmlToModelResult());
				result = true;
			}
			catch (XmlToModelTransformationException)
			{
			}
			// expected, sort of
			return result;
		}
	}
}
