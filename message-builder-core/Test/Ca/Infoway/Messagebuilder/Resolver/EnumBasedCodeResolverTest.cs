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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	[TestFixture]
	public class EnumBasedCodeResolverTest
	{
		private static readonly Type MOCK_ENUM_TYPE = typeof(MockEnum);

		private static readonly Type MOCK_CHARACTERS_TYPE = typeof(MockCharacters);

		//Not inlined for .NET translation
		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnumResolver()
		{
			CodeResolverRegistry.RegisterResolver(typeof(MockEnum), new EnumBasedCodeResolver(typeof(MockEnum)));
			MockEnum fred = CodeResolverRegistry.Lookup<MockEnum>(MOCK_ENUM_TYPE, "FRED");
			Assert.IsNotNull(fred, "fred");
			Assert.AreEqual(MockEnum.FRED, fred, "fred");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAllValues()
		{
			ICollection<MockEnum> results = new EnumBasedCodeResolver(typeof(MockEnum)).Lookup<MockEnum>(MOCK_ENUM_TYPE);
			Assert.IsNotNull(results, "results");
			Assert.AreEqual(5, results.Count, "size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnumResolverUsingInterface()
		{
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
			MockCharacters fred = CodeResolverRegistry.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "FRED");
			Assert.IsNotNull(fred, "fred");
			Assert.AreEqual(MockEnum.FRED, fred, "fred");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnumResolverUsingInterfaceWithIncorrectCodeSystem()
		{
			EnumBasedCodeResolver resolver = new EnumBasedCodeResolver(typeof(MockStarTrek));
			MockCharacters spock = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "SPOCK", "to.boldly.go.wrong.code.system");
			Assert.IsNull(spock, "spock");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnumResolverUsingInterfaceWithCorrectCodeSystem()
		{
			EnumBasedCodeResolver resolver = new EnumBasedCodeResolver(typeof(MockStarTrek));
			MockCharacters spock = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "SPOCK", "to.boldly.go");
			Assert.IsNotNull(spock, "spock");
			Assert.AreEqual(MockStarTrek.SPOCK, spock, "spock");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnumResolverUsingInterfaceWithCorrectCodeSystemIgnoringCase()
		{
			EnumBasedCodeResolver resolver = new EnumBasedCodeResolver(typeof(MockStarTrek));
			MockCharacters spock = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "Spock", "to.boldly.go", true);
			Assert.IsNotNull(spock, "spock");
			Assert.AreEqual(MockStarTrek.SPOCK, spock, "spock");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnumResolverUsingInterfaceWithCorrectCodeSystemNotIgnoringCase()
		{
			EnumBasedCodeResolver resolver = new EnumBasedCodeResolver(typeof(MockStarTrek));
			MockCharacters spock = resolver.Lookup<MockCharacters>(MOCK_CHARACTERS_TYPE, "Spock", "to.boldly.go", false);
			Assert.IsNull(spock, "spock");
		}
	}
}
