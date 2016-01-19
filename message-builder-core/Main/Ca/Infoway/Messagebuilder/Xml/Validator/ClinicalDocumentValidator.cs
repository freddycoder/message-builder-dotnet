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


using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml.Validator;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class ClinicalDocumentValidator
	{
		private readonly ClinicalDocumentTransformer documentTransformer;

		public ClinicalDocumentValidator()
		{
			this.documentTransformer = new ClinicalDocumentTransformer();
		}

		public ClinicalDocumentValidator(ClinicalDocumentTransformer documentTransformer)
		{
			this.documentTransformer = documentTransformer;
		}

		public virtual CdaValidatorResult Validate(XmlDocument xmlDocument, VersionNumber version)
		{
			return this.Validate(xmlDocument, version, null);
		}

		public virtual CdaValidatorResult Validate(XmlDocument xmlDocument, VersionNumber version, GenericCodeResolverRegistry codeResolverRegistryOverride
			)
		{
			XmlToCdaModelResult transformResults = this.documentTransformer.TransformFromDocument(version, xmlDocument, codeResolverRegistryOverride
				);
			return new CdaValidatorResult(transformResults.GetErrors());
		}
	}
}
