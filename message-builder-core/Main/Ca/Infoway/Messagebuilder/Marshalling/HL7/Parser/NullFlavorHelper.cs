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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Util;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public class NullFlavorHelper
	{
		public static readonly string MB_SUPPRESS_XSI_NIL_ON_NULLFLAVOR = "messagebuilder.suppress.xsi.nil.on.nullflavor";

		public static readonly string NULL_FLAVOR_ATTRIBUTE_NAME = "nullFlavor";

		private static readonly string NULL_FLAVOR_XSI_NIL_ATTRIBUTE_NAME = "xsi:nil";

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
			NullFlavor nullFlavor = CodeResolverRegistry.Lookup<NullFlavor>(attributeValue);
			if (ConformanceLevelUtil.IsMandatory(this.conformanceLevel, null))
			{
				xmlToModelResult.AddHl7Error(Hl7Error.CreateMandatoryAttributeIsNullError(NodeUtil.GetLocalOrTagName((XmlElement)node), GetAttributeValue
					(node, NULL_FLAVOR_ATTRIBUTE_NAME), (XmlElement)node));
			}
			else
			{
				//      RM #15431 - strictly speaking, nullFlavors are not allowed for REQUIRED fields. However, jurisdictions often ignore this restriction.
				//      FIXME:  TM (see RM18424) - once MB has error levels implemented, this can be reinstated as a warning
				//		} else if (this.conformanceLevel != null && this.conformanceLevel == ConformanceLevel.REQUIRED) {
				//			xmlToModelResult.addHl7Error(Hl7Error.createRequiredAttributeIsNullError(
				//					NodeUtil.getLocalOrTagName((Element) node), 
				//					getAttributeValue(node, NULL_FLAVOR_ATTRIBUTE_NAME),
				//					(Element) node));
				if (this.isAssociation && !StringUtils.Equals(GetAttributeValue(node, NULL_FLAVOR_XSI_NIL_ATTRIBUTE_NAME), "true"))
				{
					if (!Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(Runtime.GetProperty(Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.NullFlavorHelper
						.MB_SUPPRESS_XSI_NIL_ON_NULLFLAVOR)))
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
				if (StringUtils.IsEmpty(attributeValue) || CodeResolverRegistry.Lookup<NullFlavor>(attributeValue) == null)
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
