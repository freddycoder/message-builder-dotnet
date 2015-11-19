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
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public abstract class MarshallingTestCase
	{
		protected static readonly string FULL_DATE_TIME = "yyyy-MM-dd'T'HH:mm:ss";

		protected static readonly string FULL_DATE = "yyyy-MM-dd";

		protected XmlToModelResult xmlResult;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
			this.xmlResult = new XmlToModelResult();
		}

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="Platform.Xml.Sax.SAXException"></exception>
		protected virtual XmlNode CreateNode(string @string)
		{
			return new DocumentFactory().CreateFromString(@string).DocumentElement;
		}

		protected virtual void AssertXml(string description, string expected, string actual)
		{
			AssertXml(description, expected, actual, true);
		}

		protected virtual void AssertXml(string description, string expected, string actual, bool skipFirstComment)
		{
			if (skipFirstComment && actual.Contains("<!--"))
			{
				string first = StringUtils.SubstringBefore(actual, "<!--");
				string rest = StringUtils.SubstringAfter(StringUtils.SubstringAfter(actual, "<!--"), "-->");
				actual = first + rest;
			}
			Assert.AreEqual(WhitespaceUtil.NormalizeWhitespace(expected, true), WhitespaceUtil.NormalizeWhitespace(actual, true), description
				);
		}

		protected virtual void AssertDateEquals(string description, string pattern, PlatformDate expected, PlatformDate actual)
		{
			Assert.IsNotNull(actual, description + " not null");
			DateFormat format = DateUtil.Instance(pattern);
			Assert.AreEqual(format.Format(expected), format.Format(actual), description);
		}
	}
}
