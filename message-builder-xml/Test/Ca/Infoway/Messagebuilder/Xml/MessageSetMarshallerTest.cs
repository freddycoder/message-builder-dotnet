using System.Collections.Generic;
using System.IO;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[TestFixture]
	public class MessageSetMarshallerTest
	{
		private MessageSetMarshaller marshaller;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.marshaller = new MessageSetMarshaller();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldReadSampleXmlWithBreadcrumbHistory()
		{
			MessageSet testset = GetMessageSet("sample_with_breadcrumbs.xml");
			Assert.IsTrue(testset.RemixHistory.Count > 0);
			Assert.AreEqual(testset.RemixHistory[0].Value, "R02_04_02");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldReadSampleWithRimClass()
		{
			MessageSet testset = GetMessageSet("sample_with_rim_class.xml");
			ICollection<MessagePart> allMessageParts = testset.AllMessageParts;
			foreach (MessagePart messagePart in allMessageParts)
			{
				Assert.IsNotNull(messagePart.RimClass);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldReadSampleXml()
		{
			MessageSet set = GetMessageSet("sample.xml");
			Assert.IsNotNull(set, "set");
			Assert.AreEqual(2, set.PackageLocations.SafeGet("COCT_MT470002CA").MessageParts.Count, "number of parts");
			Assert.AreEqual(new Cardinality(1, 1), set.GetMessagePart("COCT_MT470002CA.ActDefinition").Relationships[0].Cardinality, 
				"cardinality");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldReadSampleXmlWithArgumentChoices()
		{
			MessageSet set = GetMessageSet("sample_with_argument_choices.xml");
			Assert.IsNotNull(set, "set");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestWriteXml()
		{
			MessageSet set = new MessageSet();
			Interaction interaction = new Interaction();
			interaction.Name = "ABCD_IN000001CA";
			interaction.SuperTypeName = "MCCI_IN002100CA.Message";
			set.Interactions["ABCD_IN000001CA"] = interaction;
			MessageSet newSet = MarshallAndUnmarshall(set);
			Assert.AreEqual(set.Interactions.Count, newSet.Interactions.Count, "interactions");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestWriteXmlWithNesting()
		{
			MessageSet set = new MessageSet();
			Interaction interaction = new Interaction();
			interaction.Name = "ABCD_IN000001CA";
			interaction.SuperTypeName = "MCCI_IN002100CA.Message";
			Argument triggerEvent = new Argument();
			triggerEvent.Name = "REPC_MT123456CA.ControlActEvent";
			Argument payload = new Argument();
			payload.Name = "REPC_MT123456CA.Payload";
			triggerEvent.Arguments.Add(payload);
			interaction.Arguments.Add(triggerEvent);
			set.Interactions["ABCD_IN000001CA"] = interaction;
			MessageSet newSet = MarshallAndUnmarshall(set);
			Assert.AreEqual(set.Interactions.Count, newSet.Interactions.Count, "interactions");
		}

		/// <exception cref="System.Exception"></exception>
		private MessageSet MarshallAndUnmarshall(MessageSet set)
		{
			MemoryStream output = new MemoryStream();
			this.marshaller.Marshall(set, output);
			byte[] b = output.ToArray();
			System.Console.Out.WriteLine(System.Text.ASCIIEncoding.ASCII.GetString(b));
			return this.marshaller.Unmarshall(new MemoryStream(b));
		}

		/// <exception cref="System.Exception"></exception>
		private MessageSet GetMessageSet(string xml)
		{
			Stream input = Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource(GetType(), xml);
			try
			{
				return this.marshaller.Unmarshall(input);
			}
			finally
			{
				IOUtils.CloseQuietly(input);
			}
		}
	}
}
