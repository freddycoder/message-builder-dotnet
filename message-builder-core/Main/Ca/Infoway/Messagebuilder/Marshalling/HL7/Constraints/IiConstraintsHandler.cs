using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	public class IiConstraintsHandler
	{
		private static readonly ConstraintsHandler constraintsHandler = new ConstraintsHandler();

		public IiConstraintsHandler()
		{
		}

		public virtual void HandleConstraints(ConstrainedDatatype constraints, Identifier identifier, ErrorLogger logger, bool isSingleCardinality
			)
		{
			if (identifier == null || constraints == null)
			{
				return;
			}
			bool isTemplateId = (constraints.Name == null ? false : constraints.Name.EndsWith(".templateId"));
			string newRoot = constraintsHandler.ValidateConstraint("root", identifier.Root, constraints, logger, isSingleCardinality 
				&& isTemplateId);
			string newExtension = constraintsHandler.ValidateConstraint("extension", identifier.Extension, constraints, logger);
			identifier.Root = newRoot;
			identifier.Extension = newExtension;
		}
	}
}
