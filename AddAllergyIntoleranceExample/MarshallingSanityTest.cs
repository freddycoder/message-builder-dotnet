/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2012-01-18 20:51:44 -0500 (Wed, 18 Jan 2012) $
 * Revision:      $LastChangedRevision: 3827 $
 */

using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction;
using System.Reflection;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder
{
	[TestFixture]
	public class MarshallingSanityTest
	{
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			CodeResolverRegistry.Register(new TrivialCodeResolver());
			Assembly.Load(new AssemblyName("message-builder-release-r02_04_02"));
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		/*
		[Test]
		public virtual void TestBasicMarshalling()
		{
			ModelToXmlResult result = new MessageBeanTransformerImpl().TransformToHl7AndReturnResult(
                        SpecificationVersion.R02_04_02,
                        new AddAllergyIntoleranceRequest());
			System.Console.WriteLine("output:");
			System.Console.WriteLine(result.GetXmlMessage());
			Assert.IsNotNullOrEmpty(result.GetXmlMessage());
		}
		*/

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicUnmarshalling()
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml("<REPC_IN000012CA xmlns=\"urn:hl7-org:v3\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\"></REPC_IN000012CA>");
			
			XmlToModelResult result = new MessageBeanTransformerImpl().TransformFromHl7(
                        SpecificationVersion.R02_04_02,
                        doc);
			Assert.IsNotNull(result.GetMessageObject());
		}
	}
}
