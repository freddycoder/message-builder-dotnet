using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Iterator;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class BaseCollectionPropertyFormatter : AbstractNullFlavorPropertyFormatter<ICollection<BareANY>>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual FormatContext CreateSubContext(FormatContext context)
		{
			return new FormatContextImpl(context.GetElementName(), GetSubType(context), context.GetConformanceLevel(), context.IsSpecializationType
				(), context.GetVersion(), context.GetDateTimeZone(), context.GetDateTimeTimeZone());
		}

		protected override ICollection<BareANY> ExtractBareValue(BareANY hl7Value)
		{
			BareCollection collection = (BareCollection)hl7Value;
			return collection.GetBareCollectionValue();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual string FormatAllElements(FormatContext subContext, ICollection<BareANY> collection, int indentLevel)
		{
			StringBuilder builder = new StringBuilder();
			PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(subContext.Type);
			if (collection.IsEmpty())
			{
				builder.Append(formatter.Format(subContext, null, indentLevel));
			}
			else
			{
				foreach (BareANY element in EmptyIterable<object>.NullSafeIterable<BareANY>(collection))
				{
					builder.Append(formatter.Format(subContext, (BareANY)element, indentLevel));
				}
			}
			return builder.ToString();
		}

		/// <summary>
		/// We expect the type to look something like this:
		/// 
		/// SET&lt;II&gt;
		/// 
		/// and we want to return "II"
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		/// <exception cref="ModelToXmlTransformationException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private string GetSubType(FormatContext context)
		{
			string subType = Hl7DataTypeName.GetParameterizedType(context.Type);
			if (StringUtils.IsNotBlank(subType))
			{
				return subType;
			}
			else
			{
				throw new ModelToXmlTransformationException("Cannot find the sub type for " + context.Type);
			}
		}
	}
}
