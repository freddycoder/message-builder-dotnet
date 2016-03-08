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
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;


namespace Ca.Infoway.Messagebuilder.Platform
{

	[TestFixture]
	public class ListElementUtilTest
	{

		[Test]
		public void ShouldDetectCollection() 
		{
			IList<String> list = new List<String>();
			Assert.IsTrue(ListElementUtil.IsCollection(list), "is list");
		}
		[Test]
		public void ShouldDetectCollectionOnCollapsedType() 
		{
			IList<PersonName> list = new RawListWrapper<PN, PersonName>(new List<PN>(), typeof(PNImpl));
			Assert.IsTrue(ListElementUtil.IsCollection(list), "is list");
		}
		[Test]
		public void ShouldGetElementFromGenericList() 
		{
			IList<String> list = new List<String>();
			list.Add("Fred");
			list.Add("Barney");
			list.Add("Wilma");
			
			Assert.AreEqual("Barney", ListElementUtil.GetElement(list, 1), "element");
		}

		[Test]
		public void ShouldGetElementFromArrayList() 
		{
			ArrayList list = new ArrayList();
			list.Add("Fred");
			list.Add("Barney");
			list.Add("Wilma");
			
			Assert.AreEqual("Barney", ListElementUtil.GetElement(list, 1), "element");
		}

		[Test]
		public void ShouldGetElementFromHl7List() 
		{
			IList<String> list = new LISTImpl<ST,String>(typeof(STImpl)).RawList();
			list.Add("Fred");
			list.Add("Barney");
			list.Add("Wilma");
			
			Assert.AreEqual("Barney", ListElementUtil.GetElement(list, 1), "element");
		}

		[Test]
		public void ShouldGetElementFromLinkedSet() 
		{
			LinkedSet<String> list = new LinkedSet<String>();
			list.Add("Fred");
			list.Add("Barney");
			list.Add("Wilma");
			
			Assert.AreEqual("Barney", ListElementUtil.GetElement(list, 1), "element");
		}
		
		[Test]
		public void ShouldAddToList() {
			IList<String> list = new List<String>();
			list.Add("Fred");
			list.Add("Barney");
			list.Add("Wilma");
			
			ListElementUtil.AddElement(list, "Betty");
			Assert.AreEqual(4, list.Count, "count");
			Assert.IsTrue(list.Contains("Betty"));
		}

		[Test]
		public void ShouldAddToHl7List() {
			Object list = new LISTImpl<ST,String>(typeof(STImpl)).BareValue;
			
			ListElementUtil.AddElement(list, new STImpl("Betty"));
			Assert.AreEqual(1, ListElementUtil.Count(list), "count");
		}

		[Test]
		public void ShouldAddToHl7RawList() {
			IList<String> list = new LISTImpl<ST,String>(typeof(STImpl)).RawList();
			list.Add("Fred");
			list.Add("Barney");
			list.Add("Wilma");
			
			ListElementUtil.AddElement(list, "Betty");
			Assert.AreEqual(4, list.Count, "count");
			Assert.IsTrue(list.Contains("Betty"));
		}

	}
}
