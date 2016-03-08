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


using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	[TestFixture]
	public class CollectionOfAnyToAnyAdapterTest
	{
		private CollectionOfAnyToAnyAdapter adapter;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.adapter = new CollectionOfAnyToAnyAdapter();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMatch()
		{
			Assert.IsTrue(this.adapter.CanAdapt(typeof(SET<IIImpl, Identifier>), "II"), "typeName, type (SET)");
            Assert.IsTrue(this.adapter.CanAdapt(typeof(LIST<IIImpl, Identifier>), "II"), "typeName, type (LIST)");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldAdaptListCorrectly()
		{
			IIImpl ii = new IIImpl(new Identifier("1", "2"));
			LIST<IIImpl, Identifier> list = new LISTImpl<IIImpl, Identifier>(typeof(IIImpl));
			list.Value.Add(ii);
			BareANY adapted = this.adapter.Adapt("II", list);
			Assert.IsTrue(adapted is II);
			Assert.IsTrue(adapted == ii);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldAdaptSetCorrectly()
		{
			IIImpl ii = new IIImpl(new Identifier("1", "2"));
			SET<IIImpl, Identifier> set = new SETImpl<IIImpl, Identifier>(typeof(IIImpl));
			set.Value.Add(ii);
			BareANY adapted = this.adapter.Adapt("II", set);
			Assert.IsTrue(adapted is II);
			Assert.IsTrue(adapted == ii);
		}
	}
}
