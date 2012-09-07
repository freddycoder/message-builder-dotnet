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
			this.Name = name;
			if (parentConceptDomains != null)
			{
				this.ParentConceptDomains.AddAll(parentConceptDomains);
			}
		}

		public virtual string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				string name = value;
				this.name = name;
			}
		}

		public virtual IList<string> ParentConceptDomains
		{
			get
			{
				return this.parentConceptDomains;
			}
			set
			{
				IList<string> parentConceptDomains = value;
				this.parentConceptDomains = parentConceptDomains;
			}
		}
	}
}
