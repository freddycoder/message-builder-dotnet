using System;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "POIZ_MT030050CA.InFulfillmentOf", "POIZ_MT030060CA.InFulfillmentOf", "POIZ_MT060150CA.InFulfillmentOf"
		 })]
	public class InFulfillmentOfBean : MessagePartBean
	{
		private const long serialVersionUID = 20100603L;

		private INT doseNumber = new INTImpl();

		private BL immunizationPlan = new BLImpl(false);

		[Hl7XmlMappingAttribute(new string[] { "sequenceNumber" })]
		public virtual Int32? DoseNumber
		{
			get
			{
				return this.doseNumber.Value;
			}
			set
			{
				Int32? doseNumber = value;
				this.doseNumber.Value = doseNumber;
			}
		}

		[Hl7XmlMappingAttribute(new string[] { "immunizationPlan" })]
		public virtual Boolean? ImmunizationPlan
		{
			get
			{
				return this.immunizationPlan.Value;
			}
			set
			{
				Boolean? immunizationPlan = value;
				this.immunizationPlan.Value = immunizationPlan;
			}
		}
	}
}
