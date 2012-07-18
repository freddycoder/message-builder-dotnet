using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal abstract class AbstractEntityNameElementParser : AbstractSingleElementParser<EntityName>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			EntityName result = ParseNode(node, xmlToModelResult);
			result.Uses = GetNameUses(GetAttributeValue(node, "use"));
			return result;
		}

		protected virtual ICollection<EntityNameUse> GetNameUses(string nameUseAttribute)
		{
			ICollection<EntityNameUse> uses = new HashSet<EntityNameUse>();
			if (nameUseAttribute != null)
			{
				StringTokenizer tokenizer = new StringTokenizer(nameUseAttribute);
				while (tokenizer.HasMoreElements())
				{
					string token = tokenizer.NextToken();
					EntityNameUse nameUse = CodeResolverRegistry.Lookup<EntityNameUse>(token);
					if (nameUse != null)
					{
						uses.Add(nameUse);
					}
				}
			}
			return uses;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract EntityName ParseNode(XmlNode node, XmlToModelResult xmlToModelResult);

		public virtual bool IsParseable(XmlNode node)
		{
			bool result = false;
			try
			{
				Parse(null, node, new XmlToModelResult());
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
