using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler(new string[] { "BAG" })]
	internal class BagElementParser : SetOrListElementParser
	{
		public BagElementParser(ParserRegistry parserRegistry) : base(parserRegistry, false)
		{
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Data type \"" + context.Type + "\" is not part of the pan-Canadian standard"
				, CollUtils.IsEmpty(nodes) ? null : (XmlElement)nodes[0]));
			return base.Parse(context, nodes, xmlToModelResult);
		}

		protected override BareANY WrapWithHl7DataType(string type, string subType, ICollection<BareANY> collection, ParseContext
			 context)
		{
			CollectionHelper result = CreateCollectionHelper(type);
			foreach (BareANY bareANY in collection)
			{
				result.Add(bareANY);
			}
			return (BareANY)result;
		}

		private CollectionHelper CreateCollectionHelper(string dataType)
		{
			Hl7DataTypeName type = Hl7DataTypeName.Create(dataType);
			string typeName = StringUtils.DeleteWhitespace(type.GetUnqualifiedVersion().ToString());
			if ("BAG<AD>".Equals(typeName))
			{
				return new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
			}
			else
			{
				if ("BAG<GTS>".Equals(typeName))
				{
					return new LISTImpl<GTS, GeneralTimingSpecification>(typeof(GTSImpl));
				}
				else
				{
					if ("BAG<II>".Equals(typeName))
					{
						return new LISTImpl<II, Identifier>(typeof(IIImpl));
					}
					else
					{
						if ("BAG<PN>".Equals(typeName))
						{
							return new LISTImpl<PN, PersonName>(typeof(PNImpl));
						}
						else
						{
							if ("BAG<ST>".Equals(typeName))
							{
								return new LISTImpl<ST, string>(typeof(STImpl));
							}
							else
							{
								if ("BAG<TEL>".Equals(typeName))
								{
									return new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
								}
								else
								{
									throw new MarshallingException("Cannot create a data type construct for data type " + dataType);
								}
							}
						}
					}
				}
			}
		}

		protected override ICollection<BareANY> GetCollectionType(ParseContext context)
		{
			return new List<BareANY>();
		}
	}
}
