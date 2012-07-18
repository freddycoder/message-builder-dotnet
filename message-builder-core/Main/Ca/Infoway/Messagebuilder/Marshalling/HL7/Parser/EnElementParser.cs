using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// EN - EntityName
	/// Parses an EN element into a EntityName.
	/// </summary>
	/// <remarks>
	/// EN - EntityName
	/// Parses an EN element into a EntityName. The element looks like this:
	/// This is a trivial name
	/// This class makes a decision on which parser to use based on the format of the
	/// XML.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-EN
	/// </remarks>
	[DataTypeHandler("EN")]
	internal class EnElementParser : AbstractSingleElementParser<EntityName>
	{
		private readonly AbstractEntityNameElementParser onElementParser = new OnElementParser();

		private readonly PnElementParser pnElementParser = new PnElementParser();

		private readonly TnElementParser tnElementParser = new TnElementParser();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			EntityName result;
			if (tnElementParser.IsParseable(node))
			{
				result = (EntityName)tnElementParser.Parse(null, node, xmlToModelResult).BareValue;
			}
			else
			{
				if (onElementParser.IsParseable(node))
				{
					result = (EntityName)onElementParser.Parse(null, node, xmlToModelResult).BareValue;
				}
				else
				{
					if (pnElementParser.IsParseable(node))
					{
						result = (EntityName)pnElementParser.Parse(null, node, xmlToModelResult).BareValue;
					}
					else
					{
						throw new XmlToModelTransformationException("Cannot figure out how to parse node " + node.ToString());
					}
				}
			}
			return result;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ENImpl<EntityName>();
		}
	}
}
