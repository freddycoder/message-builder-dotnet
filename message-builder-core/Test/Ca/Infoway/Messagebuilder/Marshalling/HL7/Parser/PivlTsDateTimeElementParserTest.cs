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
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class PivlTsDateTimeElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<periodicInterval><frequency><numerator value=\"3\"/><denominator value=\"1\" unit=\"d\"/></frequency></periodicInterval>"
				);
			PeriodicIntervalTime pivl = (PeriodicIntervalTime)new PivlTsDateTimeElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNotNull(pivl, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pivl.Operator);
			Assert.IsNull(pivl.Period);
			Assert.IsNull(pivl.Phase);
			Assert.IsNull(pivl.Value);
			Assert.AreEqual(Representation.FREQUENCY, pivl.Representation);
			Assert.AreEqual(new BigDecimal("1"), pivl.Quantity.Quantity, "qty");
			Assert.AreEqual("d", pivl.Quantity.Unit.CodeValue, "units");
			Assert.AreEqual((Int32?)3, pivl.Repetitions, "reps");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsWithMissingElements()
		{
			XmlNode node = CreateNode("<periodicInterval><frequency></frequency></periodicInterval>");
			PeriodicIntervalTime pivl = (PeriodicIntervalTime)new PivlTsDateTimeElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNull(pivl, "null");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsWithEmptyElements()
		{
			XmlNode node = CreateNode("<periodicInterval><frequency><numerator/><denominator/></frequency></periodicInterval>");
			PeriodicIntervalTime pivl = (PeriodicIntervalTime)new PivlTsDateTimeElementParser().Parse(CreateContext(), node, this.xmlResult
				).BareValue;
			Assert.IsNotNull(pivl, "null");
			Assert.IsNull(pivl.Repetitions);
			Assert.IsNull(pivl.Quantity);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("PIVL<TS.DATETIME>", null, SpecificationVersion.R02_04_02, null, null, null, null, null);
		}
	}
}
