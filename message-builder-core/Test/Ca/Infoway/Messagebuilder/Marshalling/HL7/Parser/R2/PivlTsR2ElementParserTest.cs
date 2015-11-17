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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class PivlTsR2ElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFull()
		{
			PlatformDate lowDate = DateUtil.GetDate(1999, 0, 23);
			PlatformDate highDate = DateUtil.GetDate(2013, 4, 7);
			XmlNode node = CreateNode("<periodicInterval alignment=\"D\" institutionSpecified=\"true\"><phase><low value=\"19990123\"/><high value=\"20130507\"/></phase><period unit=\"d\" value=\"11\"/></periodicInterval>"
				);
			PeriodicIntervalTimeR2 pivl = (PeriodicIntervalTimeR2)new PivlTsR2ElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNotNull(pivl, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(CalendarCycle.DAY_OF_THE_MONTH, pivl.Alignment);
			Assert.IsTrue((bool)pivl.InstitutionSpecified);
			//Cast for .NET translation
			Assert.AreEqual(lowDate, pivl.Phase.Low);
			Assert.AreEqual(highDate, pivl.Phase.High);
			Assert.AreEqual(new BigDecimal(11), pivl.Period.Quantity);
			Assert.AreEqual("d", pivl.Period.Unit.CodeValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmpty()
		{
			XmlNode node = CreateNode("<periodicInterval/>");
			PeriodicIntervalTimeR2 pivl = (PeriodicIntervalTimeR2)new PivlTsR2ElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNotNull(pivl, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pivl.Alignment);
			Assert.IsFalse((bool)pivl.InstitutionSpecified);
			//Cast for .NET translation
			Assert.IsNull(pivl.Phase);
			Assert.IsNull(pivl.Period);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullFlavor()
		{
			XmlNode node = CreateNode("<periodicInterval nullFlavor=\"NAV\"/>");
			BareANY pivlTsAny = new PivlTsR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			PeriodicIntervalTimeR2 pivl = (PeriodicIntervalTimeR2)pivlTsAny.BareValue;
			Assert.IsNull(pivl);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.TEMPORARILY_UNAVAILABLE, pivlTsAny.NullFlavor
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsInvalidAlignment()
		{
			XmlNode node = CreateNode("<periodicInterval alignment=\"INVALIDVALUE\"/>");
			PeriodicIntervalTimeR2 pivl = (PeriodicIntervalTimeR2)new PivlTsR2ElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNotNull(pivl, "null");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().Contains("CalendarCycle"));
			Assert.IsNull(pivl.Alignment);
			Assert.IsFalse((bool)pivl.InstitutionSpecified);
			//Cast for .NET translation
			Assert.IsNull(pivl.Phase);
			Assert.IsNull(pivl.Period);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsInvalidInstitutionSpecified()
		{
			XmlNode node = CreateNode("<periodicInterval institutionSpecified=\"NOTABOOLEAN\"/>");
			PeriodicIntervalTimeR2 pivl = (PeriodicIntervalTimeR2)new PivlTsR2ElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNotNull(pivl, "null");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().Contains("institutionSpecified"));
			Assert.IsNull(pivl.Alignment);
			Assert.IsFalse((bool)pivl.InstitutionSpecified);
			//Cast for .NET translation
			Assert.IsNull(pivl.Phase);
			Assert.IsNull(pivl.Period);
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("PIVL<TS>", null, SpecificationVersion.R02_04_02, null, null, null, null, null, null, null
				, false);
		}
	}
}
