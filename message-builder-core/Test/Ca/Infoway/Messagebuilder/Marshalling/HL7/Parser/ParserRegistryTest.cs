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
			return typeof(ElementParser).IsAssignableFrom(classObj) && !ClassUtil.IsAbstract(classObj);
		}

		private IList<FileInfo> GetAllClasses()
		{
			return SourceCodeLocationUtil.GetAllSourceFiles(ClassUtils.GetPackageName(GetType()));
		}
	}
}
