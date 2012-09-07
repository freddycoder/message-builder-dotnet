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
			this.Name = name;
			this.CodeSystem = codeSystem;
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

		public virtual string CodeSystem
		{
			get
			{
				return this.codeSystem;
			}
			set
			{
				string codeSystem = value;
				this.codeSystem = codeSystem;
			}
		}

		public virtual IList<ContextBinding> ContextBindings
		{
			get
			{
				return this.contextBindings;
			}
			set
			{
				IList<ContextBinding> contextBindings = value;
				this.contextBindings = contextBindings;
			}
		}
	}
}
