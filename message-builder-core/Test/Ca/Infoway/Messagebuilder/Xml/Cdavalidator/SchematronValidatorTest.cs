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
using System.Xml;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Cdavalidator;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.IO;
using NUnit.Framework;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml.Cdavalidator
{
	[TestFixture]
	public class SchematronValidatorTest
	{
		private static Serializer serializer = new Persister();

		private static MessageSet derivedMessageSet;

		/// <exception cref="System.Exception"></exception>
        [TestFixtureSetUp]
		public static void SetUp()
		{
			derivedMessageSet = (MessageSet)serializer.Read(typeof(MessageSet), Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource
                (typeof(SchematronValidatorTest), "cdaMessageSet.xml"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldValidateDocument()
		{
			SchematronValidator validator = new SchematronValidator(derivedMessageSet.SchematronContexts);
            XmlDocument document = new DocumentFactory().CreateFromStream(Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource
				(typeof(SchematronValidatorTest), "problems-and-medications.xml"));
			ModelToXmlResult result = new ModelToXmlResult();
			validator.Validate(document, result);
			Assert.IsFalse(result.IsValid());
			Assert.AreEqual(5, result.GetHl7Errors().Count);
			foreach (Hl7Error error in result.GetHl7Errors())
			{
				System.Console.Out.WriteLine(error.GetMessage());
			}
        }
	}
}
