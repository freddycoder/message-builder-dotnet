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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class TealBeanRenderWalkerTest
	{
		private TealBeanRenderWalker walker;

		private MockVisitor visitor;

		private MockMessageBean message;

		private MockBridgeFactory bridgeFactory;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.bridgeFactory = new MockBridgeFactory();
			this.message = new MockMessageBean();
			this.walker = new TealBeanRenderWalker(this.message, null, null, null, this.bridgeFactory);
			this.visitor = new MockVisitor();
			this.bridgeFactory.interaction = new Interaction();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldPerformTrivialWalk()
		{
			this.bridgeFactory.partBridge = new MockPartBridge();
			this.walker.Accept(this.visitor);
			Assert.IsTrue(this.visitor.IsRootStarted(), "started");
			Assert.IsTrue(this.visitor.IsRootEnded(), "started");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldVisitAttribute()
		{
			MockAttributeBridge bridge = new MockAttributeBridge();
			bridge.relationship = new Relationship();
			this.walker.ProcessRelationship(this.bridgeFactory.interaction, bridge, this.visitor);
			Assert.IsTrue(this.visitor.IsAttributeVisited(), "visited");
		}
	}
}
