using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang.Util
{
	/// <summary>A utility for interval representations.</summary>
	/// <remarks>A utility for interval representations.</remarks>
	/// <author>Intelliware Development</author>
	public class RepresentationUtil
	{
		public static bool HasLow(Representation representation)
		{
			return representation == Representation.LOW || representation == Representation.LOW_CENTER || representation == Representation
				.LOW_WIDTH || representation == Representation.LOW_HIGH;
		}

		public static bool HasHigh(Representation representation)
		{
			return representation == Representation.HIGH || representation == Representation.LOW_HIGH || representation == Representation
				.WIDTH_HIGH || representation == Representation.CENTRE_HIGH;
		}

		public static bool HasCentre(Representation representation)
		{
			return representation == Representation.CENTRE || representation == Representation.LOW_CENTER || representation == Representation
				.CENTRE_HIGH || representation == Representation.CENTRE_WIDTH;
		}

		public static bool HasWidth(Representation representation)
		{
			return representation == Representation.WIDTH || representation == Representation.CENTRE_WIDTH || representation == Representation
				.LOW_WIDTH || representation == Representation.WIDTH_HIGH;
		}
	}
}
