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
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>A facade providing a CDA-friendly interface for transformation.</summary>
	/// <remarks>A facade providing a CDA-friendly interface for transformation.</remarks>
	/// <author>robertsj</author>
	public class ClinicalDocumentTransformer
	{
		private MessageBeanTransformerImpl delegate_;

		public ClinicalDocumentTransformer()
		{
			this.delegate_ = new MessageBeanTransformerImpl();
		}

		public ClinicalDocumentTransformer(RenderMode renderMode)
		{
			this.delegate_ = new MessageBeanTransformerImpl(renderMode);
		}

		public ClinicalDocumentTransformer(TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone)
		{
			this.delegate_ = new MessageBeanTransformerImpl(dateTimeZone, dateTimeTimeZone);
		}

		public ClinicalDocumentTransformer(MessageDefinitionService service, RenderMode renderMode)
		{
			this.delegate_ = new MessageBeanTransformerImpl(service, renderMode);
		}

		public ClinicalDocumentTransformer(MessageDefinitionService service, RenderMode renderMode, TimeZoneInfo dateTimeZone, TimeZoneInfo
			 dateTimeTimeZone)
		{
			this.delegate_ = new MessageBeanTransformerImpl(service, renderMode, dateTimeZone, dateTimeTimeZone);
		}

		public ClinicalDocumentTransformer(MessageDefinitionService service, RenderMode renderMode, TimeZoneInfo dateTimeZone, TimeZoneInfo
			 dateTimeTimeZone, bool performAdditionalCdaValidationWhenUnmarshalling)
		{
			this.delegate_ = new MessageBeanTransformerImpl(service, renderMode, dateTimeZone, dateTimeTimeZone, performAdditionalCdaValidationWhenUnmarshalling
				);
		}

		public virtual XmlToCdaModelResult TransformFromDocument(VersionNumber version, XmlDocument xmlDocument)
		{
			return new XmlToCdaModelResult(this.delegate_.TransformFromHl7(version, xmlDocument));
		}

		public virtual XmlToCdaModelResult TransformFromDocument(VersionNumber version, XmlDocument xmlDocument, GenericCodeResolverRegistry
			 codeResolverRegistryOverride)
		{
			return new XmlToCdaModelResult(this.delegate_.TransformFromHl7(version, xmlDocument, codeResolverRegistryOverride));
		}

		public virtual XmlToCdaModelResult TransformFromDocument(VersionNumber version, XmlDocument xmlDocument, TimeZoneInfo dateTimeZone
			, TimeZoneInfo dateTimeTimeZone, GenericCodeResolverRegistry codeResolverRegistryOverride)
		{
			return new XmlToCdaModelResult(this.delegate_.TransformFromHl7(version, xmlDocument, dateTimeZone, dateTimeTimeZone, codeResolverRegistryOverride
				));
		}

		public virtual CdaModelToXmlResult TransformToDocument(VersionNumber version, IClinicalDocument clinicalDocumentBean)
		{
			return new CdaModelToXmlResult(this.delegate_.TransformToHl7(version, clinicalDocumentBean));
		}

		public virtual CdaModelToXmlResult TransformToDocument(VersionNumber version, IClinicalDocument clinicalDocumentBean, GenericCodeResolverRegistry
			 codeResolverRegistryOverride)
		{
			return new CdaModelToXmlResult(this.delegate_.TransformToHl7(version, clinicalDocumentBean, codeResolverRegistryOverride)
				);
		}

		public virtual CdaModelToXmlResult TransformToDocument(VersionNumber version, IClinicalDocument clinicalDocumentBean, TimeZoneInfo
			 dateTimeZone, TimeZoneInfo dateTimeTimeZone, GenericCodeResolverRegistry codeResolverRegistryOverride)
		{
			return new CdaModelToXmlResult(this.delegate_.TransformToHl7(version, clinicalDocumentBean, dateTimeZone, dateTimeTimeZone
				, codeResolverRegistryOverride));
		}
	}
}
