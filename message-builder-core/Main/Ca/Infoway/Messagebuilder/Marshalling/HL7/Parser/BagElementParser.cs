using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler(new string[] { "BAG" })]
	internal class BagElementParser : SetOrListElementParser
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Data type \"" + context.Type + "\" is not part of the pan-Canadian standard"
				, CollUtils.IsEmpty(nodes) ? null : (XmlElement)nodes[0]));
			return base.Parse(context, nodes, xmlToModelResult);
		}

		protected override BareANY WrapWithHl7DataType(string type, string subType, ICollection<BareANY> collection)
		{
			try
			{
				CollectionHelper result = (CollectionHelper)GenericDataTypeFactory.Create(type);
				foreach (BareANY bareANY in collection)
				{
					result.Add(bareANY);
				}
				return (BareANY)result;
			}
			catch (MarshallingException)
			{
				return null;
			}
		}

		protected override ICollection<BareANY> GetCollectionType(ParseContext context)
		{
			return new List<BareANY>();
		}
	}
}
