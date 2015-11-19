using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	[TestFixture]
	public class TrivialCodeResolverTest
	{
		private static readonly Type MOCK_CHARACTERS_TYPE = typeof(MockCharacters);

		private static readonly string CODESYSTEM = "CODESYSTEM";

		private static readonly string CODE = "CODE";

		//Not inlined for .NET translation purposes
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestResolveCodeWithCodeAndCodeSystem()
		{
			MockCharacters result = new TrivialCodeResolver().Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, CODE, CODESYSTEM);
			Assert.AreEqual(CODE, ((Code)result).CodeValue, "result");
			Assert.AreEqual(CODESYSTEM, ((Code)result).CodeSystem, "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestResolveCodeWithCodeAndCodeSystemCaseIgnore()
		{
			MockCharacters result = new TrivialCodeResolver().Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, CODE, CODESYSTEM, true);
			Assert.AreEqual(CODE, ((Code)result).CodeValue, "result");
			Assert.AreEqual(CODESYSTEM, ((Code)result).CodeSystem, "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCode()
		{
			TrivialCodeResolver trivialCodeResolver = new TrivialCodeResolver();
			trivialCodeResolver.AddDomainValue(null, typeof(MockCharacters));
			Assert.IsNull(trivialCodeResolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "foo"), "null");
			trivialCodeResolver.AddDomainValue(CreateMockCharactersCode("foo"), typeof(MockCharacters));
			Assert.IsNotNull(trivialCodeResolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "foo"), "not null");
		}

		private Code CreateMockCharactersCode(string code)
		{
			return new _MockCharacters_63(code);
		}

		private sealed class _MockCharacters_63 : MockCharacters
		{
			public _MockCharacters_63(string code)
			{
				this.code = code;
			}

			public string CodeValue
			{
				get
				{
					return code;
				}
			}

			public string CodeSystem
			{
				get
				{
					return null;
				}
			}

			public string CodeSystemName
			{
				get
				{
					return null;
				}
			}

			private readonly string code;
		}
	}
}
