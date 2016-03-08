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


using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Terminology.Domainvalue;
using Ca.Infoway.Messagebuilder.Terminology.Proxy;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	[TestFixture]
	public class CdaCodeResolverTest
	{
		private static readonly Type TYPE = typeof(BasicConfidentialityKind);

		private CdaCodeResolver fixture;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			fixture = new CdaCodeResolver(new TypedCodeFactory(), Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource(typeof(
				CdaCodeResolverTest), "/voc.xml"), Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource(typeof(CdaCodeResolverTest
				), "/vocabNameMap.xml"));
		}

		[Test]
		public virtual void ShouldFindAllCodesByType()
		{
			ICollection<BasicConfidentialityKind> collection = fixture.Lookup<BasicConfidentialityKind>(TYPE);
			Assert.AreEqual(3, collection.Count);
			ICollection<string> expectedCodes = new HashSet<string>(Arrays.AsList("N", "R", "V"));
			foreach (BasicConfidentialityKind code in collection)
			{
				Assert.IsTrue(expectedCodes.Contains(code.CodeValue), "one copy of " + code.CodeValue);
				expectedCodes.Remove(code.CodeValue);
			}
		}

		[Test]
		public virtual void ShouldFindCodeByCodeAndType()
		{
			BasicConfidentialityKind code = fixture.Lookup<BasicConfidentialityKind>(TYPE, "N");
			Assert.IsNotNull(code);
			Assert.AreEqual("N", code.CodeValue);
			Assert.AreEqual("2.16.840.1.113883.5.25", code.CodeSystem);
			Assert.AreEqual("ConfidentialityCode", code.CodeSystemName);
			Assert.IsTrue(typeof(Displayable).IsAssignableFrom(code.GetType()));
			Displayable displayable = (Displayable)code;
			Assert.AreEqual("normal", displayable.GetDisplayText("en"));
		}

		[Test]
		public virtual void ShouldFindCodeByCodeAndTypeIgnoringCase()
		{
			BasicConfidentialityKind code = fixture.Lookup<BasicConfidentialityKind>(TYPE, "n", true);
			Assert.IsNotNull(code);
			Assert.AreEqual("N", code.CodeValue);
			Assert.AreEqual("2.16.840.1.113883.5.25", code.CodeSystem);
			Assert.AreEqual("ConfidentialityCode", code.CodeSystemName);
			Assert.IsTrue(typeof(Displayable).IsAssignableFrom(code.GetType()));
			Displayable displayable = (Displayable)code;
			Assert.AreEqual("normal", displayable.GetDisplayText("en"));
		}

		[Test]
		public virtual void ShouldNotFindCodeWhenCaseMatters()
		{
			BasicConfidentialityKind code = fixture.Lookup<BasicConfidentialityKind>(TYPE, "n", false);
			Assert.IsNull(code);
		}

		[Test]
		public virtual void ShouldFindCodeByCodeAndOid()
		{
			BasicConfidentialityKind code = fixture.Lookup<BasicConfidentialityKind>(TYPE, "N", "2.16.840.1.113883.5.25");
			Assert.IsNotNull(code);
			code = fixture.Lookup<BasicConfidentialityKind>(TYPE, "N", "some.bogus.oid");
			Assert.IsNull(code);
		}

		[Test]
		public virtual void ShouldFindCodeByCodeAndOidWhenCaseMatters()
		{
			BasicConfidentialityKind code = fixture.Lookup<BasicConfidentialityKind>(TYPE, "n", "2.16.840.1.113883.5.25", true);
			Assert.IsNotNull(code);
			code = fixture.Lookup<BasicConfidentialityKind>(TYPE, "n", "2.16.840.1.113883.5.25", false);
			Assert.IsNull(code);
		}

		[Test]
		public virtual void ShouldReturnNullForUnsupportedVocabInStrictMode()
		{
			// unsupported value set
			ActClass actClassCode = fixture.Lookup<ActClass>(typeof(ActClass), "OBS", "2.16.840.1.113883.5.6");
			Assert.IsNull(actClassCode);
			// unsupported code in known value set
			BasicConfidentialityKind confidentialityCode = fixture.Lookup<BasicConfidentialityKind>(TYPE, "XXX", "2.16.840.1.113883.5.25"
				);
			Assert.IsNull(confidentialityCode);
		}

		[Test]
		public virtual void ShouldReturnProxyForUnsupportedVocabInLenientMode()
		{
			CdaCodeResolver lenientFixture = new CdaCodeResolver(new TypedCodeFactory(), Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource
				(typeof(CdaCodeResolverTest), "/voc.xml"), Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource(typeof(CdaCodeResolverTest
				), "/vocabNameMap.xml"), CdaCodeResolver.MODE_LENIENT);
			// unsupported code in known value set still returns null
			BasicConfidentialityKind confidentialityCode = lenientFixture.Lookup<BasicConfidentialityKind>(TYPE, "XXX", "2.16.840.1.113883.5.25"
				);
			Assert.IsNull(confidentialityCode);
			// unsupported value set delegates to proxy strategy
			ActClass actClassCode = lenientFixture.Lookup<ActClass>(typeof(ActClass), "OBS", "2.16.840.1.113883.5.6");
			Assert.IsNotNull(actClassCode);
			Assert.AreEqual("OBS", actClassCode.CodeValue);
			Assert.AreEqual("2.16.840.1.113883.5.6", actClassCode.CodeSystem);
		}
	}
}
