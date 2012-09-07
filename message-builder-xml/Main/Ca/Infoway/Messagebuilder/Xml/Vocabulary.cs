using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class Vocabulary
	{
		[ElementListAttribute(Inline = true, Required = false, Entry = "valueSet")]
		private IList<ValueSet> valueSets = new List<ValueSet>();

		[ElementListAttribute(Inline = true, Required = false, Entry = "conceptDomain")]
		private IList<ConceptDomain> conceptDomains = new List<ConceptDomain>();

		public virtual IList<ValueSet> GetValueSets()
		{
			return this.valueSets;
		}

		public virtual IList<ConceptDomain> GetConceptDomains()
		{
			return this.conceptDomains;
		}
	}
}
