using System;
using System.Collections.Generic;
using System.IO;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class FormatterR2RegistryTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAllFormattersAreRegistered()
		{
			IList<FileInfo> files = GetAllClasses();
			foreach (FileInfo file in files)
			{
				string className = ClassFileUtil.ConvertFileNameToClassName(SourceCodeLocationUtil.SOURCE_DIRECTORY, file);
				try
				{
					Type classObj = Ca.Infoway.Messagebuilder.Runtime.GetType(className);
					if (IsFormatter(classObj))
					{
						AssertFormatterIsRegistered((Type)classObj);
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
		private void AssertFormatterIsRegistered(Type classObj)
		{
			IList<string> keys = FormatterR2Registry.GetInstance().GetRegistrationKey(classObj);
			foreach (string @string in keys)
			{
				Assert.IsNotNull(FormatterR2Registry.GetInstance().Get(@string), "register " + classObj.FullName + " (" + @string + ")");
			}
		}

		private bool IsFormatter(Type classObj)
		{
			return typeof(PropertyFormatter).IsAssignableFrom(classObj) && !ClassUtil.IsAbstract(classObj) && ClassUtils.GetPackageName
				(typeof(FormatterR2Registry)).Equals(ClassUtils.GetPackageName(classObj));
		}

		private IList<FileInfo> GetAllClasses()
		{
			return SourceCodeLocationUtil.GetAllSourceFiles(ClassUtils.GetPackageName(GetType()));
		}
		//    @Test
		//    public void testShouldFindListIiOidFormatter() throws Exception {
		//    	assertNotNull("formatter", FormatterR2Registry.getInstance().get("LIST<II.OID>"));
		//	}
	}
}
