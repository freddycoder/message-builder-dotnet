using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class ValueSet
	{
		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute]
		private string codeSystem;

		[ElementListAttribute(Required = false, Inline = true, Entry = "contextBinding")]
		private IList<ContextBinding> contextBindings = new List<ContextBinding>();

		public ValueSet()
		{
		}

		public ValueSet(string name, string codeSystem)
		{
			this.name = name;
			this.codeSystem = codeSystem;
		}

		public virtual string GetName()
		{
			return this.name;
		}

		public virtual string GetCodeSystem()
		{
			return this.codeSystem;
		}

		public virtual IList<ContextBinding> GetContextBindings()
		{
			return this.contextBindings;
		}
	}
}
