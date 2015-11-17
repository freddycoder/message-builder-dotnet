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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	[TestFixture]
	public class CollectionToSetOfTnAdapterTest
	{
		private CollectionToSetOfTnAdapter adapter;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.adapter = new CollectionToSetOfTnAdapter();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMatch()
		{
			Assert.IsTrue(this.adapter.CanAdapt(typeof(SET<TNImpl, TrivialName>), "SET<TN>"), "typeName, type (SET)");
            Assert.IsTrue(this.adapter.CanAdapt(typeof(LIST<TNImpl, TrivialName>), "SET<TN>"), "typeName, type (LIST)");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldAdaptListCorrectly()
		{
			LIST<ST, string> list = new LISTImpl<ST, string>(typeof(STImpl));
			list.RawList().Add("text1");
			list.RawList().Add("text2");
			BareANY adapted = this.adapter.Adapt("SET<TN>", list);
			Assert.IsTrue(adapted is SET<TNImpl, TrivialName>, "type");
            LinkedSet<TNImpl> set = (LinkedSet<TNImpl>)adapted.BareValue;
			Assert.AreEqual(2, set.Count, "size");
			Assert.IsTrue(EveryItemTN(set), "all TNs");
			Assert.IsTrue(HasItemWithValue(set, "text1"));
			Assert.IsTrue(HasItemWithValue(set, "text2"));
		}

		private bool HasItemWithValue(ICollection<TNImpl> set, string value)
		{
			foreach (TN tnItem in set)
			{
				if (tnItem.Value.Name.Equals(value))
				{
					return true;
				}
			}
			return false;
		}

		private bool EveryItemTN(ICollection<TNImpl> set)
		{
			foreach (object item in set)
			{
				if (!(item is TN))
				{
					return false;
				}
			}
			return true;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldAdaptSetCorrectly()
		{
			SET<ST, string> list = new SETImpl<ST, string>(typeof(STImpl));
			list.RawSet().Add("text1");
			list.RawSet().Add("text2");
			BareANY adapted = this.adapter.Adapt("SET<TN>", list);
            Assert.IsTrue(adapted is SET<TNImpl, TrivialName>, "type");
            LinkedSet<TNImpl> set = (LinkedSet<TNImpl>)adapted.BareValue;
			Assert.AreEqual(2, set.Count, "size");
			Assert.IsTrue(EveryItemTN(set), "all TNs");
			Assert.IsTrue(HasItemWithValue(set, "text1"));
			Assert.IsTrue(HasItemWithValue(set, "text2"));
		}
	}
}
