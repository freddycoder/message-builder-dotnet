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
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class InstantiatorTest
	{
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFindUniqueTealBeanForHl7PartType()
		{
			Assert.IsTrue(Instantiator.GetInstance().InstantiateMessagePartBean(MockVersionNumber.MOCK_NEWFOUNDLAND, "MOCK_MT123456CA.SubType"
				, new Interaction()) is MockSubType, "instance of Sender");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFindTealBeanWhenPartTypeHasVersionSuffix()
		{
			Assert.IsTrue(Instantiator.GetInstance().InstantiateMessagePartBean(MockVersionNumber.MOCK_NEWFOUNDLAND, "MOCK_MT123456CA.SubType_V02R02"
				, new Interaction()) is MockSubType, "instance of Sender");
		}
	}
}
