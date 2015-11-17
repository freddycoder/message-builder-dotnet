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
