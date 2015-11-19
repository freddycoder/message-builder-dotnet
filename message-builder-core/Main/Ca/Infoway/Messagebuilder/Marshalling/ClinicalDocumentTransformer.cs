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
