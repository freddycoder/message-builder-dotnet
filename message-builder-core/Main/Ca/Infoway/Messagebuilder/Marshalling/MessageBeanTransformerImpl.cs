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
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Cdavalidator;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Platform.Xml.Sax;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class MessageBeanTransformerImpl
	{
		private readonly MessageDefinitionService service;

		private readonly RenderMode renderMode;

		private readonly TimeZoneInfo dateTimeZone;

		private readonly TimeZoneInfo dateTimeTimeZone;

		private readonly bool performAdditionalCdaValidationWhenUnmarshalling;

		public MessageBeanTransformerImpl() : this(new MessageDefinitionServiceFactory().Create(), RenderMode.PERMISSIVE)
		{
		}

		public MessageBeanTransformerImpl(RenderMode renderMode) : this(new MessageDefinitionServiceFactory().Create(), renderMode
			)
		{
		}

		public MessageBeanTransformerImpl(TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone) : this(new MessageDefinitionServiceFactory
			().Create(), RenderMode.PERMISSIVE, dateTimeZone, dateTimeTimeZone)
		{
		}

		public MessageBeanTransformerImpl(MessageDefinitionService service, RenderMode renderMode) : this(service, renderMode, null
			, null)
		{
		}

		public MessageBeanTransformerImpl(MessageDefinitionService service, RenderMode renderMode, TimeZoneInfo dateTimeZone, TimeZoneInfo
             dateTimeTimeZone) : this(service, renderMode, null, null, true)
		{
		}

		public MessageBeanTransformerImpl(MessageDefinitionService service, RenderMode renderMode, TimeZoneInfo dateTimeZone, TimeZoneInfo
			 dateTimeTimeZone, bool performAdditionalCdaValidationWhenUnmarshalling)
		{
			this.service = service;
			this.renderMode = renderMode;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.performAdditionalCdaValidationWhenUnmarshalling = performAdditionalCdaValidationWhenUnmarshalling;
			if (this.service != null)
			{
				this.service.Initialize();
			}
			MessageBeanRegistry.GetInstance();
		}

		// force the registry to initialize itself
		public virtual XmlToModelResult TransformFromHl7(VersionNumber version, XmlDocument hl7Message)
		{
			return TransformFromHl7(version, hl7Message, this.dateTimeZone, this.dateTimeTimeZone, null);
		}

		public virtual XmlToModelResult TransformFromHl7(VersionNumber version, XmlDocument hl7Message, GenericCodeResolverRegistry
			 codeResolverRegistryOverride)
		{
			return TransformFromHl7(version, hl7Message, this.dateTimeZone, this.dateTimeTimeZone, codeResolverRegistryOverride);
		}

		public virtual XmlToModelResult TransformFromHl7(VersionNumber version, XmlDocument hl7Message, TimeZoneInfo dateTimeZone
			, TimeZoneInfo dateTimeTimeZone, GenericCodeResolverRegistry codeResolverRegistryOverride)
		{
			CodeResolverRegistry.SetThreadLocalVersion(version);
			CodeResolverRegistry.SetThreadLocalCodeResolverRegistryOverride(codeResolverRegistryOverride);
			XmlToModelResult result = new Hl7SourceMapper().MapToTeal(new Hl7MessageSource(version, hl7Message, dateTimeZone, dateTimeTimeZone
				, this.service));
			if (this.performAdditionalCdaValidationWhenUnmarshalling)
			{
				PerformAdditionalCdaValidation(version, hl7Message, result);
			}
			CodeResolverRegistry.ClearThreadLocalVersion();
			CodeResolverRegistry.ClearThreadLocalCodeResolverRegistryOverride();
			return result;
		}

		[Obsolete]
		public virtual ModelToXmlResult TransformToHl7AndReturnResult(VersionNumber version, IInteraction messageBean)
		{
			return TransformToHl7(version, messageBean, this.dateTimeZone, this.dateTimeTimeZone, null);
		}

		[Obsolete]
		public virtual ModelToXmlResult TransformToHl7AndReturnResult(VersionNumber version, IInteraction messageBean, GenericCodeResolverRegistry
			 codeResolverRegistryOverride)
		{
			return TransformToHl7(version, messageBean, this.dateTimeZone, this.dateTimeTimeZone, codeResolverRegistryOverride);
		}

		[Obsolete]
		public virtual ModelToXmlResult TransformToHl7AndReturnResult(VersionNumber version, IInteraction messageBean, TimeZoneInfo
			 dateTimeZone, TimeZoneInfo dateTimeTimeZone, GenericCodeResolverRegistry codeResolverRegistryOverride)
		{
			return TransformToHl7(version, messageBean, dateTimeZone, dateTimeTimeZone, codeResolverRegistryOverride);
		}

		public virtual ModelToXmlResult TransformToHl7(VersionNumber version, IInteraction messageBean)
		{
			return TransformToHl7(version, messageBean, this.dateTimeZone, this.dateTimeTimeZone, null);
		}

		public virtual ModelToXmlResult TransformToHl7(VersionNumber version, IInteraction messageBean, GenericCodeResolverRegistry
			 codeResolverRegistryOverride)
		{
			return TransformToHl7(version, messageBean, this.dateTimeZone, this.dateTimeTimeZone, codeResolverRegistryOverride);
		}

		public virtual ModelToXmlResult TransformToHl7(VersionNumber version, IInteraction messageBean, TimeZoneInfo dateTimeZone
			, TimeZoneInfo dateTimeTimeZone, GenericCodeResolverRegistry codeResolverRegistryOverride)
		{
			CodeResolverRegistry.SetThreadLocalVersion(version);
			CodeResolverRegistry.SetThreadLocalCodeResolverRegistryOverride(codeResolverRegistryOverride);
			XmlRenderingVisitor visitor = new XmlRenderingVisitor(this.service.IsR2(version), this.service.IsCda(version), version);
			// TODO: Since the two boolean flags are derived from the version, we chould simplify this interface 
			new TealBeanRenderWalker(messageBean, version, dateTimeZone, dateTimeTimeZone, this.service).Accept(visitor);
			CodeResolverRegistry.ClearThreadLocalVersion();
			CodeResolverRegistry.ClearThreadLocalCodeResolverRegistryOverride();
			ModelToXmlResult result = visitor.ToXml();
			if (this.service.IsCda(version))
			{
				PerformAdditionalCdaValidation(version, result.GetXmlMessage(), result);
			}
			if (!result.IsValid() && IsStrict())
			{
				throw new InvalidRenderInputException(result.GetHl7Errors());
			}
			return result;
		}

		// this is likely to be moved to a "cda transformer" when the other renaming issue (MBG-184) is resolved
		public virtual void PerformAdditionalCdaValidation(VersionNumber version, string xml, Hl7Errors errorContainer)
		{
			try
			{
				XmlDocument document = new DocumentFactory().CreateFromString(xml);
				PerformAdditionalCdaValidation(version, document, errorContainer);
			}
			catch (SAXException e)
			{
				errorContainer.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, e.Message, (string)null));
			}
		}

		// this is likely to be moved to a "cda transformer" when the other renaming issue (MBG-184) is resolved
		public virtual void PerformAdditionalCdaValidation(VersionNumber version, XmlDocument xmlDocument, Hl7Errors errorContainer
			)
		{
			SchematronValidator schematronValidator = new SchematronValidator(this.service.GetAllSchematronContexts(version));
			schematronValidator.Validate(xmlDocument, errorContainer);
			ContainedTemplateValidator containedTemplateValidator = new ContainedTemplateValidator(this.service.GetAllPackageLocations
				(version));
			containedTemplateValidator.Validate(xmlDocument, errorContainer);
		}

		private bool IsStrict()
		{
			return this.renderMode == RenderMode.STRICT;
		}
	}
}
