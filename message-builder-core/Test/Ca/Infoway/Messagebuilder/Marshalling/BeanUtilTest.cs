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
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class BeanUtilTest
	{
		private MockMessageBean testBean;

		[SetUp]
		public virtual void Initialize()
		{
			this.testBean = new MockMessageBean();
		}

		[Test]
		public virtual void ShouldHandleNullBean()
		{
			Assert.AreEqual(string.Empty, BeanUtil.DescribeBeanPath(null, "/a/b/c"));
		}

		[Test]
		public virtual void ShouldHandleNullPath()
		{
			Assert.AreEqual(string.Empty, BeanUtil.DescribeBeanPath(new object(), null));
		}

		[Test]
		public virtual void ShouldHandleEmptyPath()
		{
			Assert.AreEqual(string.Empty, BeanUtil.DescribeBeanPath(new object(), " "));
		}

		[Test]
		public virtual void ShouldHandlePathNotFound()
		{
			Assert.AreEqual(PropertyPath.ToPath("MockMessageBean"), BeanUtil.DescribeBeanPath(this.testBean, "/aNotFound/b/c"));
		}

		[Test]
		public virtual void ShouldHandleMassageBeanOnlyPath()
		{
			string result = BeanUtil.DescribeBeanPath(this.testBean, "/MOCK_IN123456CA");
			Assert.AreEqual(PropertyPath.ToPath("MockMessageBean"), result);
		}

		[Test]
		public virtual void ShouldHandleSimplePath()
		{
			string result = BeanUtil.DescribeBeanPath(this.testBean, "/MOCK_IN123456CA/theType");
			Assert.AreEqual(PropertyPath.ToPath("MockMessageBean.type"), result);
		}

		[Test]
		public virtual void ShouldHandleComplexPath()
		{
			string result = BeanUtil.DescribeBeanPath(this.testBean, "/MOCK_IN123456CA/theType/component/subject3/name");
			Assert.AreEqual(PropertyPath.ToPath("MockMessageBean.type.name"), result);
		}

		[Test]
		public virtual void ShouldHandleComplexPathWithoutMessageBean()
		{
			string result = BeanUtil.DescribeBeanPath(this.testBean, "theType/component/subject3/name");
			Assert.AreEqual(PropertyPath.ToPath("MockMessageBean.type.name"), result);
		}

		[Test]
		public virtual void ShouldHandleComplexPathEndingInNullProperty()
		{
			string result = BeanUtil.DescribeBeanPath(this.testBean, "/MOCK_IN123456CA/theType/component/subject3/name");
			Assert.AreEqual(PropertyPath.ToPath("MockMessageBean.type.name"), result);
		}
	}
}
