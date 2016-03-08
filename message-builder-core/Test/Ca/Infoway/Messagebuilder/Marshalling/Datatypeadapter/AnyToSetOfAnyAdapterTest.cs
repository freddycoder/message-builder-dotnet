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
	public class AnyToSetOfAnyAdapterTest
	{
		private AnyToSetOfAnyAdapter adapter;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.adapter = new AnyToSetOfAnyAdapter();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMatch()
		{
			Assert.IsTrue(this.adapter.CanAdapt("II", typeof(SETImpl<IIImpl, Identifier>)), "typeName, type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldAdaptCorrectly()
		{
			IIImpl ii = new IIImpl(new Identifier("1", "2"));
			BareANY adapted = this.adapter.Adapt(typeof(SETImpl<IIImpl, Identifier>), ii);
			Assert.IsTrue(adapted is SETImpl<IIImpl, Identifier>);
			Assert.IsTrue(((SETImpl<IIImpl, Identifier>)adapted).Value.Contains(ii));
		}
	}
}
