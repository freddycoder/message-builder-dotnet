using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal abstract class StructuralAttributeRenderer
	{
		private readonly ILog log = log4net.LogManager.GetLogger(typeof(Ca.Infoway.Messagebuilder.Marshalling.StructuralAttributeRenderer
			));

		protected readonly Relationship relationship;

		public StructuralAttributeRenderer(Relationship relationship)
		{
			this.relationship = relationship;
		}

		public virtual void Render(StringBuilder builder)
		{
			if (this.relationship.Fixed)
			{
				FormatFixedValue(builder, relationship);
			}
			else
			{
				object value = GetValue();
				if (value != null)
				{
					FormatValue(builder, relationship, value);
				}
				else
				{
					if (this.relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
					{
						this.log.Info("Relationship " + this.relationship.Name + " is mandatory, but no value is specified");
					}
				}
			}
		}

		protected abstract object GetValue();

		private void FormatValue(StringBuilder builder, Relationship relationship, object value)
		{
			builder.Append(" ").Append(relationship.Name).Append("=\"").Append(XmlStringEscape.Escape(ValueAsString(value, relationship
				))).Append("\"");
		}

		private string ValueAsString(object value, Relationship relationship)
		{
			string type = relationship.Type;
			if (type == null)
			{
				throw new MarshallingException("Relationship " + relationship.Name + " has no type information");
			}
			else
			{
				if ("CS".Equals(type))
				{
					return ((Code)value).CodeValue;
				}
				else
				{
					if ("BL".Equals(type))
					{
						return true.Equals(value) ? "true" : "false";
					}
					else
					{
						throw new MarshallingException("Cannot handle structural attribute string of type " + type + " (" + relationship.Name + ")"
							);
					}
				}
			}
		}

		private void FormatFixedValue(StringBuilder builder, Relationship relationship)
		{
			builder.Append(" ").Append(relationship.Name).Append("=\"").Append(XmlStringEscape.Escape(relationship.FixedValue)).Append
				("\"");
		}
	}
}
