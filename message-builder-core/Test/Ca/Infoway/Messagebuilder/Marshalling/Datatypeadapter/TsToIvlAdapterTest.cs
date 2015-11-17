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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	[TestFixture]
	public class TsToIvlAdapterTest
	{
		private TsToIvlAdapter adapter;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.adapter = new TsToIvlAdapter();
			CodeResolverRegistry.Register(new TrivialCodeResolver());
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMatch()
		{
			Assert.IsTrue(this.adapter.CanAdapt(typeof(TS), StandardDataType.IVL_FULL_DATE.Type), "FULL_DATE_IVL");
			Assert.IsTrue(this.adapter.CanAdapt(typeof(TS), StandardDataType.IVL_FULL_DATE_WITH_TIME.Type), "IVL_FULL_DATE_WITH_TIME"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldAdaptCorrectly()
		{
			TSImpl ts = new TSImpl(new PlatformDate());
			BareANY adapted = this.adapter.Adapt(StandardDataType.IVL_FULL_DATE.Type, ts);
			Assert.AreEqual(((IVL<TS, Interval<PlatformDate>>)adapted).Value.Low, ts.Value, "low");
		}
	}
}
