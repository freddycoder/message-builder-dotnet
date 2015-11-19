using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	public class EdConstraintsHandler
	{
		private readonly ConstraintsHandler constraintsHandler = new ConstraintsHandler();

		public EdConstraintsHandler()
		{
		}

		public virtual void HandleConstraints(ConstrainedDatatype constraints, EncapsulatedData ed, ErrorLogger logger)
		{
			if (ed == null || constraints == null)
			{
				return;
			}
			TelecommunicationAddress reference = ed.ReferenceObj;
			// ignoring any fixed value returned from reference constraints checking
			this.constraintsHandler.ValidateConstraint("reference", reference == null ? null : "reference", constraints, logger);
			// just checks if reference provided
			if (reference != null)
			{
				// only check this constraint if a reference has been provided (whether the reference was mandatory or not)
				string referenceValue = reference.ToString();
				this.constraintsHandler.ValidateConstraint("reference.value", referenceValue, constraints, logger);
			}
			// checks for actual value
			string mediaType = ed.MediaType == null ? null : ed.MediaType.CodeValue;
			string newMediaType = this.constraintsHandler.ValidateConstraint("mediaType", mediaType, constraints, logger);
			if (!StringUtils.Equals(mediaType, newMediaType))
			{
				x_DocumentMediaType newMediaTypeEnum = Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.Get(newMediaType);
				if (newMediaTypeEnum != null)
				{
					ed.MediaType = newMediaTypeEnum;
				}
			}
		}
	}
}
