using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler(new string[] { "SET" })]
	internal class SetElementParser : SetOrListElementParser
	{
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
			return new LinkedSet<BareANY>();
		}
	}
}
