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
			TypeCode = typeCode;
			Code = code;
			Text = text;
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual AcknowledgementDetailCode Code
		{
			get
			{
				return (AcknowledgementDetailCode)this.code.Value;
			}
			set
			{
				AcknowledgementDetailCode code = value;
				this.code.Value = code;
			}
		}

		[Hl7XmlMappingAttribute("text")]
		public virtual string Text
		{
			get
			{
				return this.text.Value;
			}
			set
			{
				string text = value;
				this.text.Value = text;
			}
		}

		[Hl7XmlMappingAttribute("location")]
		public virtual IList<string> Location
		{
			get
			{
				return this.location.RawList();
			}
		}

		[Hl7XmlMappingAttribute("typeCode")]
		public virtual AcknowledgementDetailType TypeCode
		{
			get
			{
				return (AcknowledgementDetailType)this.typeCode.Value;
			}
			set
			{
				AcknowledgementDetailType typeCode = value;
				this.typeCode.Value = typeCode;
			}
		}
	}
}
