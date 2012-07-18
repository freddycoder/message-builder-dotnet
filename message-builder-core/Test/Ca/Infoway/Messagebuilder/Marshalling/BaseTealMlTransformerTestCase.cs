using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public abstract class BaseTealMlTransformerTestCase
	{
		protected MessageBeanTransformerImpl transformer;

		protected DocumentFactory factory;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.transformer = new MessageBeanTransformerImpl();
			this.factory = new DocumentFactory();
			CodeResolverRegistry.Register(new TrivialCodeResolver());
		}

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}
	}
}
