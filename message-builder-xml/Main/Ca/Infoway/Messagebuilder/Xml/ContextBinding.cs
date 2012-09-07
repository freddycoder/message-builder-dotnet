using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class ContextBinding
	{
		[XmlAttributeAttribute]
		private string conceptDomain;

		[XmlAttributeAttribute]
		private string realm;

		[XmlAttributeAttribute]
		private string codingStrength;

		public ContextBinding()
		{
		}

		public ContextBinding(string conceptDomain, string realm, CodingStrength codingStrength)
		{
			this.conceptDomain = conceptDomain;
			this.realm = realm;
			SetCodingStrength(codingStrength);
		}

		public ContextBinding(string conceptDomain, string realm, string codingStrength)
		{
			this.conceptDomain = conceptDomain;
			this.realm = realm;
			this.codingStrength = codingStrength;
		}

		public virtual string GetConceptDomain()
		{
			return this.conceptDomain;
		}

		public virtual string GetRealm()
		{
			return this.realm;
		}

		public virtual void SetRealm(string realm)
		{
			this.realm = realm;
		}

		public virtual CodingStrength GetCodingStrength()
		{
			return EnumPattern.ValueOf<CodingStrength>(this.codingStrength);
		}

		private void SetCodingStrength(CodingStrength codingStrength)
		{
			this.codingStrength = codingStrength == null ? null : codingStrength.Name;
		}
	}
}
