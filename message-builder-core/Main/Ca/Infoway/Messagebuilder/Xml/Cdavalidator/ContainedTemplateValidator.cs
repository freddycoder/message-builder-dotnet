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
using System.Xml.XPath;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.Xml.Sax;

namespace Ca.Infoway.Messagebuilder.Xml.Cdavalidator
{
	public class ContainedTemplateValidator
	{
		private static readonly string PREFIX = "cda";

		private static readonly string NAMESPACE = "urn:hl7-org:v3";

		private IDictionary<string, PackageLocation> packagesByOid;

		private XPathHelper xPathHelper = new XPathHelper();

		public ContainedTemplateValidator(ICollection<PackageLocation> locations)
		{
			packagesByOid = new Dictionary<string, PackageLocation>();
			foreach (PackageLocation packageLocation in locations)
			{
				if (packageLocation.TemplateOid != null)
				{
					packagesByOid[packageLocation.TemplateOid] = packageLocation;
				}
			}
		}

		public virtual void Validate(string xml, Hl7Errors validationResult)
		{
			try
			{
				XmlDocument document = new DocumentFactory().CreateFromString(xml);
				Validate(document, validationResult);
			}
			catch (SAXException e)
			{
				validationResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "Unable to validate contained templates: " + e.Message
					, "/"));
			}
		}

		public virtual void Validate(XmlDocument document, Hl7Errors validationResult)
		{
			Validate(document, "/cda:ClinicalDocument", "cda:component/cda:structuredBody/cda:component/cda:section/cda:templateId/@root"
				, validationResult);
			Validate(document, "//cda:section", "cda:entry/*/cda:templateId/@root", validationResult);
			Validate(document, "//cda:entry/*[cda:templateId]", "*//cda:templateId/@root", validationResult);
		}

		private void Validate(XmlNode xml, string baseNodeXPath, string containedNodeXPath, Hl7Errors validationResult)
		{
			try
			{
				XmlNodeList baseNodes = xPathHelper.GetNodes(xml, baseNodeXPath, "cda", NAMESPACE);
				for (int i = 0,  ilength = baseNodes.Count; i < ilength; i++)
				{
					ValidateSingleNode(baseNodes.Item(i), containedNodeXPath, validationResult);
				}
			}
			catch (XPathException e)
			{
				validationResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "Unable to validate contained templates: " + e.Message
					, baseNodeXPath));
			}
		}

		/// <exception cref="System.Xml.XPath.XPathException"></exception>
		private void ValidateSingleNode(XmlNode baseNode, string containedNodeXPath, Hl7Errors validationResult)
		{
			XmlNodeList baseTemplateIds = xPathHelper.GetNodes(baseNode, "cda:templateId/@root", PREFIX, NAMESPACE);
			for (int j = 0,  jlength = baseTemplateIds.Count; j < jlength; j++)
			{
				string templateId = baseTemplateIds.Item(j).Value;
				PackageLocation packageLocation = packagesByOid.SafeGet(templateId);
				if (packageLocation != null && packageLocation.ContainedTemplateConstraints != null && !packageLocation.ContainedTemplateConstraints
					.IsEmpty())
				{
					XmlNodeList containedTemplateIds = xPathHelper.GetNodes(baseNode, containedNodeXPath, PREFIX, NAMESPACE);
					Dictionary<string, Int32?> containedTemplateMap = PopulateContainedTemplateMap(containedTemplateIds);
					foreach (ContainedTemplate containedTemplate in packageLocation.ContainedTemplateConstraints)
					{
						Int32? count = containedTemplateMap.SafeGet(containedTemplate.TemplateOid);
						if (count == null)
						{
							count = 0;
						}
						if (!containedTemplate.Cardinality.Contains((int)count))
						{
							//Cast for .NET
							validationResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.CDA_CARDINALITY_CONSTRAINT, "Expected [" + containedTemplate.RawCardinality
								 + "] instances of template " + containedTemplate.TemplateOid + ", but found " + count, baseNode));
						}
					}
				}
			}
		}

		private Dictionary<string, Int32?> PopulateContainedTemplateMap(XmlNodeList containedTemplateIds)
		{
			Dictionary<string, Int32?> containedTemplateMap = new Dictionary<string, Int32?>();
			for (int k = 0,  klength = containedTemplateIds.Count; k < klength; k++)
			{
				string containedTemplateId = containedTemplateIds.Item(k).Value;
				PackageLocation containedPackageLocation = packagesByOid.SafeGet(containedTemplateId);
				while (containedTemplateId != null && containedPackageLocation != null)
				{
					int count = 1;
					if (containedTemplateMap.ContainsKey(containedTemplateId))
					{
						count += (int)containedTemplateMap.SafeGet(containedTemplateId);
					}
					//Cast for .NET
					containedTemplateMap[containedTemplateId] = count;
					containedTemplateId = containedPackageLocation.ImpliedTemplateOid;
					containedPackageLocation = packagesByOid.SafeGet(containedTemplateId);
				}
			}
			return containedTemplateMap;
		}
	}
}
