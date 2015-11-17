/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
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
