using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class VisitorStructuralAttributeRenderer : StructuralAttributeRenderer
	{
		private readonly object value;

		public VisitorStructuralAttributeRenderer(Relationship relationship, object value) : base(relationship)
		{
			this.value = value;
		}

		protected override object GetValue()
		{
			return this.value;
		}
	}
}
