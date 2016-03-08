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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class AbstractAttributePropertyFormatterTest : FormatterTestCase
	{
		private class TestableAttributePropertyFormatter : AbstractAttributePropertyFormatter<string>
		{
			private readonly IDictionary<string, string> nameValuePairs = new Dictionary<string, string>();

			protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, string @string, BareANY 
				bareANY)
			{
				return this.nameValuePairs;
			}

			public virtual void AddNameValuePair(string name, string value)
			{
				this.nameValuePairs[name] = value;
			}

			internal TestableAttributePropertyFormatter(AbstractAttributePropertyFormatterTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbstractAttributePropertyFormatterTest _enclosing;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			// no name-value pairs
			AbstractAttributePropertyFormatterTest.TestableAttributePropertyFormatter formatter = new AbstractAttributePropertyFormatterTest.TestableAttributePropertyFormatter
				(this);
			string result = formatter.Format(GetContext("name"), new STImpl("something"));
			Assert.AreEqual(AddLineSeparator("<name/>"), result, "named null format");
			// one name-value pair
			formatter.AddNameValuePair("name1", "value1");
			result = formatter.Format(GetContext("name"), new STImpl("something"));
			Assert.AreEqual(AddLineSeparator("<name name1=\"value1\"/>"), result, "named null format");
			// two name-value pairs
			formatter.AddNameValuePair("name2", "value2");
			result = formatter.Format(GetContext("name"), new STImpl("something"));
			Assert.AreEqual(AddLineSeparator("<name name1=\"value1\" name2=\"value2\"/>"), result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueIndent()
		{
			AbstractAttributePropertyFormatterTest.TestableAttributePropertyFormatter formatter = new AbstractAttributePropertyFormatterTest.TestableAttributePropertyFormatter
				(this);
			string result = formatter.Format(GetContext("name"), new STImpl(), 0);
			Assert.AreEqual(AddLineSeparator("<name nullFlavor=\"NI\"/>"), result, "named null format");
			result = formatter.Format(GetContext("name"), new STImpl(), 1);
			Assert.AreEqual(AddLineSeparator("  <name nullFlavor=\"NI\"/>"), result, "named null format");
			result = formatter.Format(GetContext("name"), new STImpl(), 2);
			Assert.AreEqual(AddLineSeparator("    <name nullFlavor=\"NI\"/>"), result, "named null format");
		}
	}
}
