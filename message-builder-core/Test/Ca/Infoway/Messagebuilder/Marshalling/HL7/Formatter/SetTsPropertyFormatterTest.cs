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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;
using NUnit.Framework;
using System;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetTsPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
            string result = new SetPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "blah", "SET<TS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), new SETImpl<TS, PlatformDate>(typeof(TSImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION
				));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			PlatformDate calendar1 = DateUtil.GetDate(1999, 0, 1, 12, 29, 59, 0);
			PlatformDate calendar2 = DateUtil.GetDate(2001, 1, 3, 13, 30, 00, 0);
			SETImpl<TS, PlatformDate> set = new SETImpl<TS, PlatformDate>(typeof(TSImpl));
			set.RawSet().AddAll(MakeSet(calendar1, calendar2));
            string result = new SetPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "blah", "SET<TS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), set);
            DateTimeOffset expectedDate1 = TimeZoneInfo.ConvertTime(calendar1, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            String timeZoneString = expectedDate1.Offset.ToString().Split(":")[0];
            String currentTimeZone = timeZoneString;
            while (currentTimeZone.Length <= 4)
            {
                currentTimeZone += "0";
            }
            string expectedValue1 = "19990101122959.0000" +currentTimeZone;
            string expectedValue2 = "20010203133000.0000" +currentTimeZone;
			AssertXml("non null", "<blah value=\"" + expectedValue1 + "\"/><blah value=\"" + expectedValue2 + "\"/>", result);
		}

		private ICollection<PlatformDate> MakeSet(params PlatformDate[] dates)
		{
			return new LinkedSet<PlatformDate>(Arrays.AsList(dates));
		}
	}
}
