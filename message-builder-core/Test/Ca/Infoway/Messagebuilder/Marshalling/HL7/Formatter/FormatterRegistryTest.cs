using System;
using System.Collections.Generic;
using System.IO;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class FormatterRegistryTest
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
			IList<string> keys = FormatterRegistry.GetInstance().GetRegistrationKey(classObj);
			foreach (string @string in keys)
			{
				Assert.IsNotNull(FormatterRegistry.GetInstance().Get(@string), "register " + classObj.FullName + " (" + @string + ")");
			}
		}

		private bool IsFormatter(Type classObj)
		{
			return typeof(PropertyFormatter).IsAssignableFrom(classObj) && !ClassUtil.IsAbstract(classObj);
		}

		private IList<FileInfo> GetAllClasses()
		{
			return SourceCodeLocationUtil.GetAllSourceFiles(ClassUtils.GetPackageName(GetType()));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldFindListIiOidFormatter()
		{
			Assert.IsNotNull(FormatterRegistry.GetInstance().Get("LIST<II.OID>"), "formatter");
		}
	}
}
