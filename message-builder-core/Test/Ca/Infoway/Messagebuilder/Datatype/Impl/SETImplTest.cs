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
	public class SETImplTest
	{
		//@sharpen.ignore - datatype - translated manually
		[Test]
		public virtual void ShouldBeAbleToCreateSet()
		{
			SET<ST, string> testSet = new SETImpl<ST, string>(typeof(STImpl));
			Assert.AreEqual(StandardDataType.SET, testSet.DataType);
			Assert.IsTrue(testSet.Value.IsEmpty());
			Assert.IsNull(testSet.NullFlavor);
		}

		[Test]
		public virtual void ShouldBeAbleToAddToSet()
		{
			SET<ST, string> testSet = new SETImpl<ST, string>(typeof(STImpl));
			ICollection<string> rawSet = testSet.RawSet<string>();
			rawSet.Add("newString");
			Assert.IsFalse(testSet.Value.IsEmpty());
			Assert.AreEqual(1, testSet.Value.Count);
			Assert.AreEqual(1, testSet.RawSet().Count);
			
			IEnumerator<ST> enumerator = testSet.Value.GetEnumerator ();
			enumerator.MoveNext();
			Assert.AreEqual("newString", enumerator.Current.Value);
			Assert.IsNull(enumerator.Current.NullFlavor);
		}

		[Test]
		public virtual void ShouldBeAbleToAddMultipleElementsToSet()
		{
			SET<ST, string> testSet = new SETImpl<ST, string>(typeof(STImpl));
			ICollection<string> rawSet = testSet.RawSet();
			rawSet.Add("newString1");
			rawSet.Add("newString2");
			Assert.IsFalse(testSet.Value.IsEmpty());
			Assert.AreEqual(2, testSet.Value.Count);
			Assert.IsTrue(testSet.RawSet().Contains("newString1"));
			Assert.IsTrue(testSet.RawSet().Contains("newString2"));
			rawSet.Add("newString3");
			Assert.AreEqual(3, testSet.Value.Count);
			Assert.IsTrue(testSet.RawSet().Contains("newString3"));
			bool result = rawSet.AddAll(Arrays.AsList("newString4", "newString5"));
			Assert.IsTrue(result);
			Assert.AreEqual(5, testSet.Value.Count);
			Assert.IsTrue(testSet.RawSet().Contains("newString4"));
			Assert.IsTrue(testSet.RawSet().Contains("newString5"));
			Assert.AreEqual(5, testSet.Value.Count);
		}

		[Test]
		public virtual void ShouldBeAbleToRemoveMultipleElementsFromSet()
		{
			SET<ST, string> testSet = new SETImpl<ST, string>(typeof(STImpl));
			ICollection<string> rawSet = testSet.RawSet();
			rawSet.Add("newString1");
			rawSet.Add("newString2");
			rawSet.Add("newString3");
			rawSet.Add("newString4");
			rawSet.Add("newString5");
			rawSet.Add("newString6");
			Assert.IsTrue(testSet.RawSet().Contains("newString2"));
			bool result = rawSet.Remove("newString2");
			Assert.AreEqual(5, testSet.Value.Count);
			Assert.IsTrue(result);
			Assert.IsFalse(testSet.RawSet().Contains("newString2"));
			Assert.IsTrue(testSet.RawSet().Contains("newString6"));
			bool booleanResult = rawSet.Remove("newString6");
			Assert.AreEqual(4, testSet.Value.Count);
			Assert.IsTrue(booleanResult);
			Assert.IsFalse(testSet.RawSet().Contains("newString6"));
			booleanResult = rawSet.Remove("newString123");
			Assert.IsFalse(booleanResult);
			Assert.AreEqual(4, testSet.Value.Count);
			Assert.IsTrue(testSet.RawSet().Contains("newString1"));
			Assert.IsTrue(testSet.RawSet().Contains("newString4"));
			rawSet.Clear();
			Assert.IsTrue(testSet.Value.IsEmpty());
			Assert.IsTrue(testSet.RawSet().IsEmpty());
		}

		[Test]
		public virtual void ShouldBeAbleToIterateRawSet()
		{
			SET<ST, string> testSet = new SETImpl<ST, string>(typeof(STImpl));
			ICollection<string> rawSet = testSet.RawSet();
			rawSet.Add("newString0");
			rawSet.Add("newString1");
			rawSet.Add("newString2");
			rawSet.Add("newString3");
			int i = 0;
			for (IEnumerator<string> iterator = rawSet.GetEnumerator(); iterator.MoveNext(); i++)
			{
				string @string = iterator.Current;
				Assert.AreEqual("newString" + i, @string);
			}
		}

		[Test]
		public virtual void ShouldBeAbleToObtainArrayFromSet()
		{
			SET<ST, string> testSet = new SETImpl<ST, string>(typeof(STImpl));
			ICollection<string> rawSet = testSet.RawSet();
			rawSet.Add("newString0");
			rawSet.Add("newString1");
			rawSet.Add("newString2");
			rawSet.Add("newString3");
			object[] array = rawSet.ToArray(null);
			Assert.AreEqual(4, array.Length);
			Assert.AreEqual("newString0", array[0]);
			Assert.AreEqual("newString1", array[1]);
			Assert.AreEqual("newString2", array[2]);
			Assert.AreEqual("newString3", array[3]);
			string[] array2 = rawSet.ToArray(new string[0]);
			Assert.AreEqual(4, array.Length);
			Assert.AreEqual("newString0", array2[0]);
			Assert.AreEqual("newString1", array2[1]);
			Assert.AreEqual("newString2", array2[2]);
			Assert.AreEqual("newString3", array2[3]);
		}
	}
}
