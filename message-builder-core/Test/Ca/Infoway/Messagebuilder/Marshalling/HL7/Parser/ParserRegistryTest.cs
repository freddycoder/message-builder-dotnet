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
using System.IO;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class ParserRegistryTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldFindSimpleCase()
		{
			Assert.IsNotNull(ParserRegistry.GetInstance().Get("II"), "II");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldDefaultToUnqualifiedTypeIfNoSpecificParserExists()
		{
			Assert.IsNotNull(ParserRegistry.GetInstance().Get("II.TOKEN"), "II.TOKEN");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldFindCeParser()
		{
			Assert.IsTrue(ParserRegistry.GetInstance().Get("CE") is CvElementParser, "CE");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldFindSetParser()
		{
			ElementParser elementParser = ParserRegistry.GetInstance().Get("SET<RTO<PQ.DRUG,PQ.TIME>>");
			Assert.IsTrue(elementParser is SetElementParser, "SET");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldFindRtoParsers()
		{
			ElementParser elementParser = ParserRegistry.GetInstance().Get("RTO<PQ.DRUG,PQ.TIME>");
			Assert.IsNotNull(elementParser);
			Assert.IsTrue(elementParser is RtoPqPqElementParser, "RTO<PQ,PQ>");
			elementParser = ParserRegistry.GetInstance().Get("RTO<PQ.DRUG,PQ.DRUG>");
			Assert.IsNotNull(elementParser);
			Assert.IsTrue(elementParser is RtoPqPqElementParser, "RTO<PQ,PQ>");
			elementParser = ParserRegistry.GetInstance().Get("RTO<MO.CAD,PQ.BASIC>");
			Assert.IsNotNull(elementParser);
			Assert.IsTrue(elementParser is RtoMoPqElementParser, "RTO<MO,PQ>");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAllParsersAreRegistered()
		{
			IList<FileInfo> files = GetAllClasses();
			foreach (FileInfo file in files)
			{
				string className = ClassFileUtil.ConvertFileNameToClassName(SourceCodeLocationUtil.SOURCE_DIRECTORY, file);
				try
				{
					Type otherClassName = Ca.Infoway.Messagebuilder.Runtime.GetType(className);
					if (IsParser(otherClassName))
					{
						AssertParserIsRegistered((Type)otherClassName);
					}
				}
				catch (TypeLoadException)
				{
				}
			}
		}

		// this case shouldn't happen, but is useful when the code is 
		// translated
		/// <exception cref="System.Exception"></exception>
		private void AssertParserIsRegistered(Type classObj)
		{
			IList<string> keys = ParserRegistry.GetInstance().GetRegistrationKey(classObj);
			foreach (string @string in keys)
			{
				Assert.IsNotNull(ParserRegistry.GetInstance().Get(@string), "register " + classObj.FullName + " (" + @string + ")");
			}
		}

		private bool IsParser(Type classObj)
		{
			return typeof(ElementParser).IsAssignableFrom(classObj) && !ClassUtil.IsAbstract(classObj) && ClassUtils.GetPackageName(typeof(
				ParserRegistry)).Equals(ClassUtils.GetPackageName(classObj));
		}

		private IList<FileInfo> GetAllClasses()
		{
			return SourceCodeLocationUtil.GetAllSourceFiles(ClassUtils.GetPackageName(GetType()));
		}
	}
}
