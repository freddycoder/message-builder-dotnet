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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IvlTsFullDateTimePropertyFormatterTest : FormatterTestCase
	{
		[System.Serializable]
		public class CustomUnit : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
		{
			static CustomUnit()
			{
			}

			private const long serialVersionUID = -8455773998578575019L;

			public static readonly IvlTsFullDateTimePropertyFormatterTest.CustomUnit SANDWICH = new IvlTsFullDateTimePropertyFormatterTest.CustomUnit
				("SANDWICH");

			public static readonly IvlTsFullDateTimePropertyFormatterTest.CustomUnit COFFEE = new IvlTsFullDateTimePropertyFormatterTest.CustomUnit
				("COFFEE");

			public static readonly IvlTsFullDateTimePropertyFormatterTest.CustomUnit NEWSPAPER = new IvlTsFullDateTimePropertyFormatterTest.CustomUnit
				("NEWSPAPER");

			private CustomUnit(string name) : base(name)
			{
			}

			public virtual string CodeSystem
			{
				get
				{
					return null;
				}
			}

			public virtual string CodeValue
			{
				get
				{
					return Name;
				}
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestCustomUnit()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(new DateDiff(1, IvlTsFullDateTimePropertyFormatterTest.CustomUnit
				.SANDWICH));
			string result = new IvlTsPropertyFormatter().Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate
				>>(interval));
			AssertXml("result", "<name><width unit=\"SANDWICH\" value=\"1\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullable()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(new DateDiff(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.OTHER));
			string result = new IvlTsPropertyFormatter().Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate
				>>(interval));
			AssertXml("result", "<name><width nullFlavor=\"OTH\"/></name>", result);
		}

		// incorrect ST (IVL<TS.FULLDATETIME> will be used)
		protected override FormatContext GetContext(string name)
		{
			return new FormatContextImpl(new ModelToXmlResult(), null, name, "IVL<TS.FULLDATETIME>", null);
		}
	}
}
