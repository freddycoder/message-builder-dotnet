using System;
using System.Collections.Generic;
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
	}
}
