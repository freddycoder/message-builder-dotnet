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
