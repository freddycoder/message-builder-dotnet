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
