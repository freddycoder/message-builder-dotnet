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

		public ContextBinding(string conceptDomain, string realm, Ca.Infoway.Messagebuilder.Xml.CodingStrength codingStrength)
		{
			this.conceptDomain = conceptDomain;
			this.realm = realm;
			CodingStrength = codingStrength;
		}

		public ContextBinding(string conceptDomain, string realm, string codingStrength)
		{
			this.conceptDomain = conceptDomain;
			this.realm = realm;
			this.codingStrength = codingStrength;
		}

		public virtual string ConceptDomain
		{
			get
			{
				return this.conceptDomain;
			}
		}

		public virtual string Realm
		{
			get
			{
				return this.realm;
			}
			set
			{
				string realm = value;
				this.realm = realm;
			}
		}

		private Ca.Infoway.Messagebuilder.Xml.CodingStrength CodingStrength
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Xml.CodingStrength.ValueOf<Ca.Infoway.Messagebuilder.Xml.CodingStrength>(this.codingStrength
					);
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.CodingStrength codingStrength = value;
				this.codingStrength = codingStrength == null ? null : codingStrength.Name;
			}
		}
	}
}
