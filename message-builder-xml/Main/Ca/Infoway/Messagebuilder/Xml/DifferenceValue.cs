using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[RootAttribute]
	[NamespaceAttribute(Prefix = "regen", Reference = "regen_ns")]
	public class DifferenceValue
	{
		[XmlAttributeAttribute]
		private string version;

		[XmlAttributeAttribute]
		private string value;

		public DifferenceValue()
		{
		}

		public DifferenceValue(string version, string value)
		{
			this.version = version;
			this.value = value;
		}

		/// <summary>The messageset version this difference applies to .</summary>
		/// <remarks>The messageset version this difference applies to .</remarks>
		/// <returns>the version</returns>
		public virtual string Version
		{
			get
			{
				return this.version;
			}
			set
			{
				string version = value;
				this.version = version;
			}
		}

		/// <summary>The value that is different.</summary>
		/// <remarks>The value that is different.</remarks>
		/// <returns>the value</returns>
		public virtual string Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}
	}
}
