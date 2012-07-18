using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PRPA_MT101104CA.ObservationEvent" })]
	public class ObservationEventMatchBean : MessagePartBean
	{
		private const long serialVersionUID = -9105897749766362384L;

		private CD code = new CDImpl();

		private REAL value = new REALImpl();

		[Hl7XmlMappingAttribute("code")]
		public virtual Ca.Infoway.Messagebuilder.Domainvalue.ActCode GetCode()
		{
			return (Ca.Infoway.Messagebuilder.Domainvalue.ActCode)this.code.Value;
		}

		public virtual void SetCode(Ca.Infoway.Messagebuilder.Domainvalue.ActCode code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute("value")]
		public virtual BigDecimal GetValue()
		{
			return this.value.Value;
		}

		public virtual void SetValue(BigDecimal value)
		{
			this.value.Value = value;
		}
	}
}
