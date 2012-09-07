using System.Collections.Generic;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class ConceptDomain
	{
		[XmlAttributeAttribute]
		private string name;

		[ElementListAttribute(Required = false, Inline = true, Entry = "specializes")]
		private IList<string> parentConceptDomains = new List<string>();

		public ConceptDomain()
		{
		}

		public ConceptDomain(string name, IList<string> parentConceptDomains)
		{
			this.name = name;
			if (parentConceptDomains != null)
			{
				this.parentConceptDomains.AddAll(parentConceptDomains);
			}
		}

		public virtual string GetName()
		{
			return this.name;
		}

		public virtual IList<string> GetParentConceptDomains()
		{
			return this.parentConceptDomains;
		}
	}
}
