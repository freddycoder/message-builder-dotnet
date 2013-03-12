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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class IvlIntElementParserTest : CeRxDomainValueTestCase
	{
		private XmlToModelResult result;

		private ElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.result = new XmlToModelResult();
			this.parser = new IvlIntElementParser();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Interval<Int32?> Parse(XmlNode node)
		{
			BareANY ivl = this.parser.Parse(ParserContextImpl.Create("IVL<INT>", typeof(Interval<object>), SpecificationVersion.V02R02
				, null, null, null), Arrays.AsList(node), this.result);
			return (Interval<Int32?>)(ivl.BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHigh()
		{
			XmlNode node = CreateNode("<range><low value=\"123\" /><high value=\"567\" /></range>");
			Interval<Int32?> interval = Parse(node);
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(123, interval.Low, "low");
			Assert.AreEqual(567, interval.High, "high");
			Assert.AreEqual(345, interval.Centre, "centre");
			Assert.AreEqual(567 - 123, interval.Width.Value, "width");
			Assert.AreEqual(Representation.LOW_HIGH, interval.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCentreWidth()
		{
			XmlNode node = CreateNode("<range><center value=\"15\" /><width value=\"10\" /></range>");
			Interval<Int32?> interval = Parse(node);
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(10, interval.Low, "low");
			Assert.AreEqual(20, interval.High, "high");
			Assert.AreEqual(15, interval.Centre, "centre");
			Assert.AreEqual(10, interval.Width.Value, "width");
			Assert.AreEqual(Representation.CENTRE_WIDTH, interval.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCentreWidthWithRounding()
		{
			XmlNode node = CreateNode("<range><center value=\"15\" /><width value=\"9\" /></range>");
			Interval<Int32?> interval = Parse(node);
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(11, interval.Low, "low");
			Assert.AreEqual(20, interval.High, "high");
			Assert.AreEqual(15, interval.Centre, "centre");
			Assert.AreEqual(9, interval.Width.Value, "width");
			Assert.AreEqual(Representation.CENTRE_WIDTH, interval.Representation, "representation");
		}
	}
}
