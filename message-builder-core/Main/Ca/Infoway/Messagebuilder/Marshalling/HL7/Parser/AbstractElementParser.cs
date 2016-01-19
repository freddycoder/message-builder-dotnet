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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Schema;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class AbstractElementParser : ElementParser
	{
		private static readonly string RTO_DATATYPE = "RTO";

		protected static readonly string SPECIALIZATION_TYPE = "specializationType";

		private static readonly string DATATYPE_CA_SUFFIX = ".CA";

		private static readonly int DATATYPE_CA_SUFFIX_LENGTH = DATATYPE_CA_SUFFIX.Length;

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public abstract BareANY Parse(ParseContext context, IList<XmlNode> node, XmlToModelResult xmlToModelResult);

		protected virtual string GetAttributeValue(XmlNode node, string attributeName)
		{
			return node != null && node is XmlElement ? GetAttributeValue((XmlElement)node, attributeName) : null;
		}

		protected virtual string GetSpecializationType(XmlNode node)
		{
			string specializationType = node != null && node is XmlElement ? GetAttributeValue((XmlElement)node, SPECIALIZATION_TYPE)
				 : null;
			return ConvertSpecializationType(specializationType);
		}

		public virtual string ConvertSpecializationType(string specializationType)
		{
			// specialization types defined as A<B.C> are not a problem.
			// specialization types defined as A_B.C (the way MB formats specializationType!) are not handled properly, so convert the value here
			if (specializationType != null)
			{
				specializationType = specializationType.ToUpper();
				specializationType = RemoveCaFromSpecializationType(specializationType);
				specializationType = HandleRtoInSpecializationType(specializationType);
				specializationType = HandleUnderscoresInSpecializationType(specializationType);
			}
			return specializationType;
		}

		private string HandleUnderscoresInSpecializationType(string specializationType)
		{
			// now convert the type to a format that MB recognizes (i.e. A<B.C>)
			int numUnderscores = StringUtils.Split(specializationType, "_").Length - 1;
			specializationType = System.Text.RegularExpressions.Regex.Replace(specializationType, "_", "<") + StringUtils.Repeat(">", 
				numUnderscores);
			return specializationType;
		}

		private string HandleRtoInSpecializationType(string specializationType)
		{
			// assumes the only datatype with multiple args is RTO (which is handled as a special case)
			bool isRto = specializationType.StartsWith(RTO_DATATYPE) || specializationType.Contains("_" + RTO_DATATYPE);
			if (isRto)
			{
				// special handling for RTO's multiple arguments the first "_" after "RTO_" should be changed to a comma
				int rtoIndex = specializationType.IndexOf(RTO_DATATYPE + "_");
				int underscoreToReplace = specializationType.IndexOf("_", rtoIndex + 4);
				if (rtoIndex > -1 && underscoreToReplace > -1)
				{
					specializationType = Ca.Infoway.Messagebuilder.StringUtils.Substring(specializationType, 0, underscoreToReplace) + "," + 
						Ca.Infoway.Messagebuilder.StringUtils.Substring(specializationType, underscoreToReplace + 1);
				}
			}
			return specializationType;
		}

		private string RemoveCaFromSpecializationType(string specializationType)
		{
			// 1) remove ending .CA and 2) replace .CA_ with _ (to handle any types named X.CAYYY, such as MO.CAD)
			// the above also leaves ANY.CA.IZ alone, which is what we want!
			if (specializationType.Contains(DATATYPE_CA_SUFFIX))
			{
				if (specializationType.EndsWith(DATATYPE_CA_SUFFIX))
				{
					specializationType = Ca.Infoway.Messagebuilder.StringUtils.Substring(specializationType, 0, specializationType.Length - DATATYPE_CA_SUFFIX_LENGTH
						);
				}
				specializationType = System.Text.RegularExpressions.Regex.Replace(specializationType, DATATYPE_CA_SUFFIX + "_", "_");
			}
			return specializationType;
		}

		protected virtual string GetAttributeValue(XmlElement node, string attributeName)
		{
			return node != null && node.HasAttribute(attributeName) ? node.GetAttribute(attributeName) : null;
		}

		protected virtual string GetXsiType(XmlNode node)
		{
			return node != null && node is XmlElement ? GetXsiType((XmlElement)node) : null;
		}

		protected virtual string GetXsiType(XmlElement element)
		{
			return element.GetAttribute("type", XmlSchemas.SCHEMA_INSTANCE);
		}

		protected virtual Type GetReturnType(ParseContext context)
		{
			return context == null ? null : context.GetExpectedReturnType();
		}

		protected virtual IList<XmlElement> GetNamedElements(string name, XmlElement parentElement)
		{
			IList<XmlElement> elements = new List<XmlElement>();
			XmlNodeList nodes = parentElement.GetElementsByTagName(name);
			for (int i = 0; i < nodes.Count; i++)
			{
				XmlElement foundElement = (XmlElement)nodes.Item(i);
				if (foundElement.ParentNode.Equals(parentElement))
				{
					elements.Add(foundElement);
				}
			}
			return elements;
		}
	}
}
