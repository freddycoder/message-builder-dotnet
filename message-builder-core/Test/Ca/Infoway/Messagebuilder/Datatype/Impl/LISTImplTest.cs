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

using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype.Impl
{
	[TestFixture]
	public class LISTImplTest
	{
		
		private ST getElement(LIST<ST, string> testList, int index) {
			return ((IList<ST>) testList.Value)[index];
		}

		
		[Test]
		public virtual void ShouldBeAbleToCreateList()
		{
			LIST<ST, string> testList = new LISTImpl<ST, string>(typeof(STImpl));
			Assert.AreEqual(StandardDataType.LIST, testList.DataType);
			Assert.IsTrue(testList.Value.IsEmpty());
			Assert.IsNull(testList.NullFlavor);
		}

		[Test]
		public virtual void ShouldBeAbleToAddToList()
		{
			LIST<ST, string> testList = new LISTImpl<ST, string>(typeof(STImpl));
			IList<string> rawList = testList.RawList<string>();
			rawList.Add("newString");
			Assert.IsFalse(testList.Value.IsEmpty());
			Assert.AreEqual(1, testList.Value.Count);
			Assert.AreEqual(1, testList.RawList().Count);
			Assert.AreEqual("newString", getElement(testList, 0).Value);
			Assert.AreEqual("newString", testList.RawList()[0]);
			Assert.IsNull(getElement(testList, 0).NullFlavor);
		}

		[Test]
		public virtual void ShouldBeAbleToAddMultipleElementsToList()
		{
			LIST<ST, string> testList = new LISTImpl<ST, string>(typeof(STImpl));
			IList<string> rawList = testList.RawList<string>();
			rawList.Add("newString1");
			rawList.Add("newString2");
			Assert.IsFalse(testList.Value.IsEmpty());
			Assert.AreEqual(2, testList.Value.Count);
			Assert.AreEqual("newString1", getElement(testList, 0).Value);
			Assert.AreEqual("newString2", getElement(testList, 1).Value);
			Assert.IsNull(getElement(testList, 0).NullFlavor);
			Assert.IsNull(getElement(testList, 1).NullFlavor);
			rawList.Insert(0, "newString3");
			Assert.AreEqual(3, testList.Value.Count);
			Assert.AreEqual("newString3", getElement(testList, 0).Value);
			bool result = rawList.AddAll(Arrays.AsList("newString4", "newString5"));
			Assert.IsTrue(result);
			Assert.AreEqual(5, testList.Value.Count);
			Assert.AreEqual("newString4", getElement(testList, 3).Value);
			Assert.AreEqual("newString5", getElement(testList, 4).Value);
			Assert.AreEqual(5, testList.Value.Count);
			result = rawList.AddAll(2, Arrays.AsList("newString6", "newString7"));
			Assert.IsTrue(result);
			Assert.AreEqual(7, testList.Value.Count);
			Assert.AreEqual("newString3", getElement(testList, 0).Value);
			Assert.AreEqual("newString1", getElement(testList, 1).Value);
			Assert.AreEqual("newString6", getElement(testList, 2).Value);
			Assert.AreEqual("newString7", getElement(testList, 3).Value);
			Assert.AreEqual("newString2", getElement(testList, 4).Value);
			Assert.AreEqual("newString4", getElement(testList, 5).Value);
			Assert.AreEqual("newString5", getElement(testList, 6).Value);
		}

		[Test]
		public virtual void ShouldBeAbleToRemoveMultipleElementsFromList()
		{
			LIST<ST, string> testList = new LISTImpl<ST, string>(typeof(STImpl));
			IList<string> rawList = testList.RawList();
			rawList.Add("newString1");
			rawList.Add("newString2");
			rawList.Add("newString3");
			rawList.Add("newString4");
			rawList.Add("newString5");
			rawList.Add("newString6");
			Assert.IsTrue(testList.RawList().Contains("newString2"));
			rawList.RemoveAt(1);
			Assert.AreEqual(5, testList.Value.Count);
			Assert.IsFalse(testList.RawList().Contains("newString2"));
			Assert.IsTrue(testList.RawList().Contains("newString6"));
			bool booleanResult = rawList.Remove("newString6");
			Assert.AreEqual(4, testList.Value.Count);
			Assert.IsTrue(booleanResult);
			Assert.IsFalse(testList.RawList().Contains("newString6"));
			booleanResult = rawList.Remove("newString123");
			Assert.IsFalse(booleanResult);
			Assert.AreEqual(4, testList.Value.Count);
			Assert.AreEqual(4, testList.Value.Count);
			booleanResult = rawList.RemoveAll(Arrays.AsList("newString3", "newString5"));
			Assert.IsTrue(booleanResult);
			Assert.AreEqual(2, testList.Value.Count);
			Assert.AreEqual("newString1", getElement(testList, 0).Value);
			Assert.AreEqual("newString4", getElement(testList, 1).Value);
			booleanResult = rawList.RemoveAll(Arrays.AsList("newString3", "newString5"));
			Assert.IsFalse(booleanResult);
			Assert.AreEqual(2, testList.Value.Count);
			Assert.AreEqual("newString1", getElement(testList, 0).Value);
			Assert.AreEqual("newString4", getElement(testList, 1).Value);
			booleanResult = rawList.RetainAll(Arrays.AsList("newString4", "newString1"));
			Assert.IsFalse(booleanResult);
			Assert.AreEqual(2, testList.Value.Count);
			Assert.AreEqual("newString1", getElement(testList, 0).Value);
			Assert.AreEqual("newString4", getElement(testList, 1).Value);
			booleanResult = rawList.RetainAll(Arrays.AsList("newString4"));
			Assert.IsTrue(booleanResult);
			Assert.AreEqual(1, testList.Value.Count);
			Assert.AreEqual("newString4", getElement(testList, 0).Value);
			rawList.Clear();
			Assert.IsTrue(testList.Value.IsEmpty());
			Assert.IsTrue(testList.RawList().IsEmpty());
		}

		[Test]
		public virtual void ShouldBeAbleToDetectLastIndexOf()
		{
			LIST<ST, string> testList = new LISTImpl<ST, string>(typeof(STImpl));
			IList<string> rawList = testList.RawList();
			rawList.Add("newString1");
			rawList.Add("newString1");
			rawList.Add("newString1");
			rawList.Add("newString2");
			Assert.AreEqual(2, testList.RawList().LastIndexOf("newString1"));
		}

		[Test]
		public virtual void ShouldBeAbleToIterateRawList()
		{
			LIST<ST, string> testList = new LISTImpl<ST, string>(typeof(STImpl));
			IList<string> rawList = testList.RawList();
			rawList.Add("newString0");
			rawList.Add("newString1");
			rawList.Add("newString2");
			rawList.Add("newString3");
			int i = 0;
			for (IEnumerator<string> iterator = rawList.GetEnumerator(); iterator.MoveNext(); i++)
			{
				string @string = iterator.Current;
				Assert.AreEqual("newString" + i, @string);
			}
		}

		[Test]
		public virtual void ShouldBeAbleToSetValueInList()
		{
			LIST<ST, string> testList = new LISTImpl<ST, string>(typeof(STImpl));
			IList<string> rawList = testList.RawList();
			rawList.Add("newString0");
			rawList.Add("newString1");
			rawList.Add("newString2");
			rawList.Add("newString3");
			rawList[2] = "newString4";
			Assert.AreEqual(4, testList.Value.Count);
			Assert.AreEqual("newString0", getElement(testList, 0).Value);
			Assert.AreEqual("newString1", getElement(testList, 1).Value);
			Assert.AreEqual("newString4", getElement(testList, 2).Value);
			Assert.AreEqual("newString3", getElement(testList, 3).Value);
		}

		[Test]
		public virtual void ShouldBeAbleToObtainPartOfList()
		{
			LIST<ST, string> testList = new LISTImpl<ST, string>(typeof(STImpl));
			IList<string> rawList = testList.RawList();
			rawList.Add("newString0");
			rawList.Add("newString1");
			rawList.Add("newString2");
			rawList.Add("newString3");
			IList<string> subList = rawList.SubList(1, 3);
			Assert.AreEqual(2, subList.Count);
			Assert.AreEqual("newString1", subList[0]);
			Assert.AreEqual("newString2", subList[1]);
			object[] array = rawList.ToArray(null);
			Assert.AreEqual(4, array.Length);
			Assert.AreEqual("newString0", array[0]);
			Assert.AreEqual("newString1", array[1]);
			Assert.AreEqual("newString2", array[2]);
			Assert.AreEqual("newString3", array[3]);
			string[] array2 = rawList.ToArray(new string[0]);
			Assert.AreEqual(4, array.Length);
			Assert.AreEqual("newString0", array2[0]);
			Assert.AreEqual("newString1", array2[1]);
			Assert.AreEqual("newString2", array2[2]);
			Assert.AreEqual("newString3", array2[3]);
		}

	}
}
