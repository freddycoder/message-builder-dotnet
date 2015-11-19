using System;
using System.Collections.Generic;
using System.IO;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class ParserR2RegistryTest
	{
		//	@Test
		//	public void testShouldFindSimpleCase() throws Exception {
		//		assertNotNull("II", ParserR2Registry.getInstance().get("II"));
		//	}
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldFindSimpleCaseSt()
		{
			Assert.IsNotNull(ParserR2Registry.GetInstance().Get("ST"), "ST");
		}

		//	@Test
		//	public void testShouldDefaultToUnqualifiedTypeIfNoSpecificParserExists() throws Exception {
		//		assertNotNull("II.TOKEN", ParserR2Registry.getInstance().get("II.TOKEN"));
		//	}
		//	@Test
		//	public void testShouldFindCeParser() throws Exception {
		//		assertTrue("CE", ParserR2Registry.getInstance().get("CE") instanceof CvElementParser);
		//	}
		//	@Test
		//	public void testShouldFindSetParser() throws Exception {
		//		ElementParser elementParser = ParserR2Registry.getInstance().get("SET<RTO<PQ.DRUG,PQ.TIME>>");
		//		assertTrue("SET", elementParser instanceof SetElementParser);
		//	}
		//	@Test
		//	public void testShouldFindRtoParsers() throws Exception {
		//		ElementParser elementParser = ParserR2Registry.getInstance().get("RTO<PQ.DRUG,PQ.TIME>");
		//		assertNotNull(elementParser);
		//		assertTrue("RTO<PQ,PQ>", elementParser instanceof RtoPqPqElementParser);
		//		
		//		elementParser = ParserR2Registry.getInstance().get("RTO<PQ.DRUG,PQ.DRUG>");
		//		assertNotNull(elementParser);
		//		assertTrue("RTO<PQ,PQ>", elementParser instanceof RtoPqPqElementParser);
		//
		//		elementParser = ParserR2Registry.getInstance().get("RTO<MO.CAD,PQ.BASIC>");
		//		assertNotNull(elementParser);
		//		assertTrue("RTO<MO,PQ>", elementParser instanceof RtoMoPqElementParser);
		//	}
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
			IList<string> keys = ParserR2Registry.GetInstance().GetRegistrationKey(classObj);
			foreach (string @string in keys)
			{
				Assert.IsNotNull(ParserR2Registry.GetInstance().Get(@string), "register " + classObj.FullName + " (" + @string + ")");
			}
		}

		private bool IsParser(Type classObj)
		{
			return typeof(ElementParser).IsAssignableFrom(classObj) && !ClassUtil.IsAbstract(classObj) && ClassUtils.GetPackageName(typeof(
				ParserR2Registry)).Equals(ClassUtils.GetPackageName(classObj));
		}

		private IList<FileInfo> GetAllClasses()
		{
			return SourceCodeLocationUtil.GetAllSourceFiles(ClassUtils.GetPackageName(GetType()));
		}
	}
}