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
