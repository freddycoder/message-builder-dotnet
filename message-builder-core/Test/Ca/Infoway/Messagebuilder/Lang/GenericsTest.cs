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


/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Lang {
	
	using NUnit;
    using System;
    using System.Reflection;
	
	[NUnit.Framework.TestFixture]
	public class GenericsTest {
	
		[NUnit.Framework.Test]
		public void TestGetParameterType() {
			NUnit.Framework.Assert.AreEqual(typeof(String),Ca.Infoway.Messagebuilder.Lang.Generics
							.GetParameterType(GetProperty("Names")),"type");
		}
	
		public PropertyInfo GetProperty(String name) {
			PropertyInfo result = null;
            PropertyInfo[] descriptors = typeof(MockBean).GetProperties();
			foreach (PropertyInfo descriptor  in  descriptors) {
				if (name.Equals(descriptor.Name)) {
					result = descriptor;
					break;
				}
			}
			return result;
		}
	
		[NUnit.Framework.Test]
		public void TestIsCollection() {
			NUnit.Framework.Assert.IsTrue(Ca.Infoway.Messagebuilder.Lang.Generics
							.IsCollectionParameterizedType(GetProperty("Names")
													.GetGetMethod().ReturnType),"collection");
		}
	}
}
