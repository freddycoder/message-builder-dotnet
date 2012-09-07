using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[RootAttribute]
	public class Vocabulary
	{
		[ElementListAttribute(Inline = true, Required = false, Entry = "valueSet")]
		private IList<ValueSet> valueSets = new List<ValueSet>();

		[ElementListAttribute(Inline = true, Required = false, Entry = "conceptDomain")]
		private IList<ConceptDomain> conceptDomains = new List<ConceptDomain>();

		public virtual IList<ValueSet> ValueSets
		{
			get
			{
				return this.valueSets;
			}
			set
			{
				IList<ValueSet> valueSets = value;
				this.valueSets = valueSets;
			}
		}

		public virtual IList<ConceptDomain> ConceptDomains
		{
			get
			{
				return this.conceptDomains;
			}
			set
			{
				IList<ConceptDomain> conceptDomains = value;
				this.conceptDomains = conceptDomains;
			}
		}
	}
}
