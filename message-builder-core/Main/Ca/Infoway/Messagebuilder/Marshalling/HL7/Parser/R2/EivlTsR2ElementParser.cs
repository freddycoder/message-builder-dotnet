using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>Parses an EIVL element into a String.</summary>
	/// <remarks>
	/// Parses an EIVL element into a String. (R2)
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// </remarks>
	[DataTypeHandler("EIVL<TS>")]
	internal class EivlTsR2ElementParser : AbstractSingleElementParser<EventRelatedPeriodicIntervalTime>
	{
		private CeR2ElementParser ceR2ElementParser = new CeR2ElementParser();

		private IvlPqR2ElementParser ivlPqR2ElementParser = new IvlPqR2ElementParser();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EventRelatedPeriodicIntervalTime ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult
			, Type expectedReturnType, XmlToModelResult result)
		{
			EventRelatedPeriodicIntervalTime @event = new EventRelatedPeriodicIntervalTime();
			HandleEvent(node, @event, context, result);
			HandleOffset(node, @event, context, result);
			if (@event.IsEmpty())
			{
				@event = null;
			}
			return @event;
		}

		private void HandleOffset(XmlNode node, EventRelatedPeriodicIntervalTime @event, ParseContext context, XmlToModelResult result
			)
		{
			XmlNode offsetNode = GetNamedChildNode(node, "offset");
			if (offsetNode != null)
			{
				ParseContext newContext = ParseContextImpl.Create("IVL<PQ>", context);
				BareANY parsedOffset = this.ivlPqR2ElementParser.Parse(newContext, offsetNode, result);
				if (parsedOffset != null)
				{
					@event.Offset = (Interval<PhysicalQuantity>)parsedOffset.BareValue;
				}
			}
		}

		private void HandleEvent(XmlNode node, EventRelatedPeriodicIntervalTime @event, ParseContext context, XmlToModelResult result
			)
		{
			XmlNode eventNode = GetNamedChildNode(node, "event");
			if (eventNode != null)
			{
				ParseContext newContext = ParseContextImpl.Create("CE", typeof(TimingEvent), context);
				BareANY parsedEvent = this.ceR2ElementParser.Parse(newContext, eventNode, result);
				if (parsedEvent != null)
				{
					CodedTypeR2<TimingEvent> codedTypeR2 = (CodedTypeR2<TimingEvent>)parsedEvent.BareValue;
					//Special cast for .NET
					@event.Event = codedTypeR2.Code;
				}
			}
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new EIVLImpl<EventRelatedPeriodicIntervalTime>();
		}
	}
}
