using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	[TestFixture]
	public class CompositeCodeResolverTest
	{
		private static readonly Type MOCK_CHARACTERS_TYPE = typeof(MockCharacters);

		//Skip inline for .NET translation
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldCompositeCollections()
		{
			CompositeCodeResolver resolver = new CompositeCodeResolver(new EnumBasedCodeResolver(typeof(MockEnum)), new EnumBasedCodeResolver
				(typeof(MockStarTrek)));
			ICollection<MockCharacters> c = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE);
			Assert.AreEqual(11, c.Count, "size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldResolveCode()
		{
			CompositeCodeResolver resolver = new CompositeCodeResolver(new EnumBasedCodeResolver(typeof(MockEnum)), new EnumBasedCodeResolver
				(typeof(MockStarTrek)));
			MockCharacters result = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "SPOCK", null);
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(MockStarTrek.SPOCK, result, "spock");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldResolveCodeIgnoringCase()
		{
			CompositeCodeResolver resolver = new CompositeCodeResolver(new EnumBasedCodeResolver(typeof(MockEnum)), new EnumBasedCodeResolver
				(typeof(MockStarTrek)));
			MockCharacters result = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "Spock", null, true);
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(MockStarTrek.SPOCK, result, "spock");
			result = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "Spock", true);
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(MockStarTrek.SPOCK, result, "spock");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldNotResolveCodeWhenIncorrectCase()
		{
			CompositeCodeResolver resolver = new CompositeCodeResolver(new EnumBasedCodeResolver(typeof(MockEnum)), new EnumBasedCodeResolver
				(typeof(MockStarTrek)));
			MockCharacters result = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "Spock", null, false);
			Assert.IsNull(result, "result");
			result = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "Spock", null, true);
			Assert.IsNotNull(result, "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldResolveCodeAndCodeSystem()
		{
			CompositeCodeResolver resolver = new CompositeCodeResolver(new EnumBasedCodeResolver(typeof(MockEnum)), new EnumBasedCodeResolver
				(typeof(MockStarTrek)));
			MockCharacters result = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "SPOCK", "to.boldly.go");
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(MockStarTrek.SPOCK, result, "spock");
		}
	}
}
