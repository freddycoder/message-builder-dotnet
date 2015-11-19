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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	[TestFixture]
	public class IntervalFactoryTest
	{
		[Test]
		public virtual void TestNullParameters()
		{
			IntervalFactory.CreateCentre((PlatformDate)null);
			IntervalFactory.CreateCentre((PlatformDate)null, (NullFlavor)null);
			IntervalFactory.CreateCentreHigh((PlatformDate)null, (PlatformDate)null);
			IntervalFactory.CreateCentreHigh((PlatformDate)null, (PlatformDate)null, (NullFlavor)null, (NullFlavor)null);
			IntervalFactory.CreateCentreWidth((PlatformDate)null, (Diff<PlatformDate>)null);
			IntervalFactory.CreateCentreWidth((PlatformDate)null, (Diff<PlatformDate>)null, (NullFlavor)null);
			IntervalFactory.CreateHigh((PlatformDate)null);
			IntervalFactory.CreateHigh((PlatformDate)null, (NullFlavor)null);
			IntervalFactory.CreateLow((PlatformDate)null);
			IntervalFactory.CreateLow((PlatformDate)null, (NullFlavor)null);
			IntervalFactory.CreateLowCentre((PlatformDate)null, (PlatformDate)null);
			IntervalFactory.CreateLowCentre((PlatformDate)null, (PlatformDate)null, (NullFlavor)null, (NullFlavor)null);
			IntervalFactory.CreateLowHigh((PlatformDate)null, (PlatformDate)null);
			IntervalFactory.CreateLowHigh((PlatformDate)null, (PlatformDate)null, (NullFlavor)null, (NullFlavor)null);
			IntervalFactory.CreateLowWidth((PlatformDate)null, (Diff<PlatformDate>)null);
			IntervalFactory.CreateLowWidth((PlatformDate)null, (Diff<PlatformDate>)null, (NullFlavor)null);
			IntervalFactory.CreateSimple((PlatformDate)null);
			IntervalFactory.CreateWidth((Diff<PlatformDate>)null);
			IntervalFactory.CreateWidthHigh((Diff<PlatformDate>)null, (PlatformDate)null);
			IntervalFactory.CreateWidthHigh((Diff<PlatformDate>)null, (PlatformDate)null, (NullFlavor)null);
		}
	}
}
