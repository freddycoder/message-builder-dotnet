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
using System.IO;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Cdavalidator;
using ILOG.J2CsMapping.IO;
using NUnit.Framework;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml.Cdavalidator
{
	[TestFixture]
	public class ContainedTemplateValidatorTest
	{
		private static Serializer serializer = new Persister();

		private static MessageSet derivedMessageSet;

		/// <exception cref="System.Exception"></exception>
        [TestFixtureSetUp]
		public static void SetUp()
		{
			derivedMessageSet = (MessageSet)serializer.Read(typeof(MessageSet), Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource
				(typeof(ContainedTemplateValidatorTest), "cdaMessageSet.xml"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldValidateDocument()
		{
			ContainedTemplateValidator validator = new ContainedTemplateValidator(derivedMessageSet.PackageLocations.Values);
            StringWriter writer = new StringWriter();
            using (StreamReader reader = new StreamReader(Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource
				(typeof(SchematronValidatorTest), "contained-template-test.xml"))) {
                    string line;
			    while ((line = reader.ReadLine()) != null)
			    {
				    writer.Write(line);
			    }
            }
            writer.Close();
			ModelToXmlResult result = new ModelToXmlResult();
			validator.Validate(writer.ToString(), result);
			Assert.IsFalse(result.IsValid());
			Assert.AreEqual(5, result.GetHl7Errors().Count);
			Assert.AreEqual("Expected [1] instances of template 2.16.840.1.113883.10.20.22.2.6.1, but found 0", result.GetHl7Errors()
				[0].GetMessage(), "Missing section at document level - message");
			Assert.AreEqual("/ClinicalDocument", result.GetHl7Errors()[0].GetPath(), "Missing section at document level - path");
			Assert.AreEqual("Expected [1] instances of template 2.16.840.1.113883.10.20.22.2.1.1, but found 2", result.GetHl7Errors()
				[1].GetMessage(), "Extra section at document level - message");
			Assert.AreEqual("/ClinicalDocument", result.GetHl7Errors()[1].GetPath(), "Extra section at document level - path");
			Assert.AreEqual("Expected [*] instances of template 2.16.840.1.113883.10.20.22.4.16, but found 0", result.GetHl7Errors()[
				3].GetMessage(), "Missing entry at section level - message");
			Assert.AreEqual("/ClinicalDocument/component/structuredBody/component[3]/section", result.GetHl7Errors()[3].GetPath(), "Missing entry at section level - path"
				);
			Assert.AreEqual("Expected [*] instances of template 2.16.840.1.113883.10.20.22.4.4, but found 0", result.GetHl7Errors()[4
				].GetMessage(), "Missing entryRelationship at entry level - message");
			Assert.AreEqual("/ClinicalDocument/component/structuredBody/component[1]/section/entry[2]/act", result.GetHl7Errors()[4].
				GetPath(), "Missing entryRelationship at entry level - path");
        } 
	}
}
