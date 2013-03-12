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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Terminology.Configurator;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
			this.result.ClearErrors();
		}

		protected ModelToXmlResult result = new ModelToXmlResult();

		protected virtual void AssertXml(string description, string expected, string actual)
		{
			if (actual.Contains("<!--"))
			{
				string first = StringUtils.SubstringBefore(actual, "<!--");
				string rest = StringUtils.SubstringAfter(StringUtils.SubstringAfter(actual, "<!--"), "-->");
				actual = first + rest;
			}
			Assert.AreEqual(WhitespaceUtil.NormalizeWhitespace(expected), WhitespaceUtil.NormalizeWhitespace(actual), description);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		protected virtual PlatformDate ParseDate(string date)
		{
			return DateUtils.ParseDate(date, new string[] { "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss" });
		}

		protected virtual FormatContext GetContext(string name)
		{
			return GetContext(name, null);
		}

		protected virtual FormatContext GetContext(string name, string type)
		{
			return GetContext(name, type, SpecificationVersion.R02_04_03);
		}

		protected virtual FormatContext GetContext(string name, string type, VersionNumber version)
		{
			return new FormatContextImpl(this.result, null, name, type, null, false, version, null, null, null);
		}

		protected ICollection<Code> MakeSet(params Code[] codes)
		{
			return new System.Collections.Generic.SortedSet<Code>(Arrays.AsList(codes));
		}

		protected ICollection<string> MakeSet(params string[] strings)
		{
			return new System.Collections.Generic.SortedSet<string>(Arrays.AsList(strings));
		}

		protected ICollection<TelecommunicationAddress> MakeTelecommunicationAddressSet(params string[] strings)
		{
			ICollection<TelecommunicationAddress> result = new HashSet<TelecommunicationAddress>();
			foreach (string s in strings)
			{
				TelecommunicationAddress address = new TelecommunicationAddress();
				address.Address = s;
				address.UrlScheme = CeRxDomainTestValues.MAILTO;
				result.Add(address);
			}
			return result;
		}

		protected virtual string AddLineSeparator(string value)
		{
			return value + SystemUtils.LINE_SEPARATOR;
		}

		protected virtual string RemoveErrorComments(string result)
		{
			return System.Text.RegularExpressions.Regex.Replace(result, "<!--(.*?)-->" + SystemUtils.LINE_SEPARATOR, string.Empty);
		}
	}
}
