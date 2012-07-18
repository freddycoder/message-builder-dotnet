using System;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// EN - EntityName
	/// Represents an EN object as an element:
	/// &lt;element-name&gt;This is a trivial name&lt;/element-name&gt;
	/// This class makes a decision on which formatter to use based on the actual type of the object.
	/// </summary>
	/// <remarks>
	/// EN - EntityName
	/// Represents an EN object as an element:
	/// &lt;element-name&gt;This is a trivial name&lt;/element-name&gt;
	/// This class makes a decision on which formatter to use based on the actual type of the object.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-EN
	/// </remarks>
	[DataTypeHandler("EN")]
	internal class EnPropertyFormatter : AbstractNullFlavorPropertyFormatter<EntityName>
	{
		private readonly OnPropertyFormatter onPropertyFormatter = new OnPropertyFormatter();

		private readonly PnPropertyFormatter pnPropertyFormatter = new PnPropertyFormatter();

		private readonly TnPropertyFormatter tnPropertyFormatter = new TnPropertyFormatter();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, EntityName value, int indentLevel)
		{
			ValidateContext(context);
			if (value == null || value.GetType().IsAssignableFrom(typeof(TrivialName)))
			{
				return this.tnPropertyFormatter.Format(context, new TNImpl((TrivialName)value), indentLevel);
			}
			else
			{
				if (value.GetType().IsAssignableFrom(typeof(PersonName)))
				{
					return this.pnPropertyFormatter.Format(context, new PNImpl((PersonName)value), indentLevel);
				}
				else
				{
					if (value.GetType().IsAssignableFrom(typeof(OrganizationName)))
					{
						return this.onPropertyFormatter.Format(context, new ONImpl((OrganizationName)value), indentLevel);
					}
					else
					{
						throw new ArgumentException("Can not handle values of type " + value.GetType());
					}
				}
			}
		}
	}
}
