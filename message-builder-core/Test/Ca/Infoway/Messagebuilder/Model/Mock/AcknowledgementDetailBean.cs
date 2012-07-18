using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "MCCI_MT002300CA.AcknowledgementDetail" })]
	public class AcknowledgementDetailBean : MessagePartBean
	{
		private const long serialVersionUID = -6328334018535930961L;

		private readonly CD typeCode = new CDImpl();

		private readonly CD code = new CDImpl();

		private readonly ST text = new STImpl();

		private LIST<ST, string> location = new LISTImpl<ST, string>(typeof(STImpl));

		public AcknowledgementDetailBean()
		{
		}

		public AcknowledgementDetailBean(AcknowledgementDetailType typeCode, AcknowledgementDetailCode code, string text)
		{
			SetTypeCode(typeCode);
			SetCode(code);
			SetText(text);
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual AcknowledgementDetailCode GetCode()
		{
			return (AcknowledgementDetailCode)this.code.Value;
		}

		public virtual void SetCode(AcknowledgementDetailCode code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute("text")]
		public virtual string GetText()
		{
			return this.text.Value;
		}

		public virtual void SetText(string text)
		{
			this.text.Value = text;
		}

		[Hl7XmlMappingAttribute("location")]
		public virtual IList<string> GetLocation()
		{
			return this.location.RawList();
		}

		[Hl7XmlMappingAttribute("typeCode")]
		public virtual AcknowledgementDetailType GetTypeCode()
		{
			return (AcknowledgementDetailType)this.typeCode.Value;
		}

		public virtual void SetTypeCode(AcknowledgementDetailType typeCode)
		{
			this.typeCode.Value = typeCode;
		}
	}
}
