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


using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue.Basic;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
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
            ICollection<EntityNameUse> uses = CollUtils.SynchronizedSet(new LinkedSet<EntityNameUse>());
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
