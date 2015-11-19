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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetTsPropertyFormatterTest : FormatterTestCase
	{
		private FormatterRegistry formatterRegistry = FormatterRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new SetPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "SET<TS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, false)
				, new SETImpl<TS, PlatformDate>(typeof(TSImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION
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
			string result = new SetPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "SET<TS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.
				Create("1-4"), false), set);
			string currentTimeZone1 = DateFormatUtil.Format(calendar1, "Z");
			string currentTimeZone2 = DateFormatUtil.Format(calendar2, "Z");
			string expectedValue1 = "19990101122959.0000" + currentTimeZone1;
			string expectedValue2 = "20010203133000.0000" + currentTimeZone2;
			AssertXml("non null", "<blah value=\"" + expectedValue1 + "\"/><blah value=\"" + expectedValue2 + "\"/>", result);
		}

		private ICollection<PlatformDate> MakeSet(params PlatformDate[] dates)
		{
			return new LinkedSet<PlatformDate>(Arrays.AsList(dates));
		}
	}
}
