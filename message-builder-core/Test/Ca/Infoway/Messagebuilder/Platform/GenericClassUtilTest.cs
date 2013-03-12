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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */


using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Platform
{

	[TestFixture]
	public class GenericClassUtilTest
	{
		
		[Test]
		public void ShouldInstantiateList() 
		{
			Type t = typeof(List<>);
			foreach (Type argument in t.GetGenericArguments()) {
				Console.WriteLine(argument.Name);
			}
			
			List<TemplateArgument> arguments = new List<TemplateArgument>();
			arguments.Add(new TemplateArgument(typeof(String), new List<TemplateArgument>()));
			Object o = GenericClassUtil.Instantiate(typeof(List<>), arguments);
			Assert.AreEqual("System.Collections.Generic.List`1[System.String]", o.GetType().ToString(), "type");
		}

		[Test]
		public void ShouldInstantiateListFromDictionary() 
		{
			Type t = typeof(List<>);
			IDictionary<String,Type> dictionary = new Dictionary<String,Type>();
			dictionary.Add("T", typeof(String));
			Object o = GenericClassUtil.Instantiate(typeof(List<>), dictionary);
			Assert.AreEqual("System.Collections.Generic.List`1[System.String]", o.GetType().ToString(), "type");
		}

		[Test]
		public void ShouldInstantiateListOfLists() 
		{
			List<TemplateArgument> arguments = new List<TemplateArgument>();
			List<TemplateArgument> subArguments = new List<TemplateArgument>();
			subArguments.Add(new TemplateArgument(typeof(String), new List<TemplateArgument>()));
			arguments.Add(new TemplateArgument(typeof(List<>), subArguments));
			Object o = GenericClassUtil.Instantiate(typeof(List<>), arguments);
			Assert.AreEqual("System.Collections.Generic.List`1[System.Collections.Generic.List`1[System.String]]", o.GetType().ToString(), "type");
		}

		[Test]
		public void ShouldInstantiateNonGenericType() 
		{
			Object o = GenericClassUtil.Instantiate(typeof(ArrayList), new List<TemplateArgument>());
			Assert.AreEqual("System.Collections.ArrayList", o.GetType().ToString(), "type");
		}
	}
}
