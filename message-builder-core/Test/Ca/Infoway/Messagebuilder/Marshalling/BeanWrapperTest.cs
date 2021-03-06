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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class BeanWrapperTest
	{
		private static readonly string ORIGINAL_TEXT = "Original Text";

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldWriteSimpleAttribute()
		{
			BeanB beanB = new BeanB();
			BeanWrapper wrapper = new BeanWrapper(beanB);
			wrapper.Write(new Relationship("text", "ST", Cardinality.Create("0-1")), "This is my text");
			Assert.AreEqual("This is my text", beanB.Text, "text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldWriteSimpleAssociation()
		{
			BeanB beanB = new BeanB();
			BeanC beanC = new BeanC();
			BeanWrapper wrapper = new BeanWrapper(beanC);
			wrapper.Write(new Relationship("textHolder", "ABCD_IN123456CA.BeanB", Cardinality.Create("0-1")), beanB);
			Assert.IsNotNull(beanC.BeanB, "bean b");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldWriteMultipleCardinalityAttribute()
		{
			BeanBPrime beanB = new BeanBPrime();
			BeanWrapper wrapper = new BeanWrapper(beanB);
			wrapper.Write(new Relationship("text", "ST", Cardinality.Create("0-10")), "This is my text");
			Assert.AreEqual("This is my text", beanB.Text[0], "text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldWriteNullFlavorOnCollapsedAssociation()
		{
			BeanCPrime beanC = new BeanCPrime();
			BeanWrapper wrapper = new BeanWrapper(beanC);
			wrapper.WriteNullFlavor(null, new Relationship("component2", "ABCD_IN123456CA.BeanB", Cardinality.Create("0-1")), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION);
			Assert.IsNull(beanC.BeanB, "bean");
		}

		//assertNull("bean", beanC.getBeanB().getText());
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldCopyOriginalTextFromCVImplObjectToBean()
		{
			BeanD beanD = new BeanD();
			BeanWrapper wrapper = new BeanWrapper(beanD);
			CVImpl cvImpl = new CVImpl(CodeResolverRegistry.Lookup<IntoleranceValue>("CODE"));
			cvImpl.OriginalText = ORIGINAL_TEXT;
			wrapper.Write(new Relationship("value", "CV", Cardinality.Create("0-1")), cvImpl);
			Assert.AreEqual(ORIGINAL_TEXT, ((CV)beanD.GetField("someCode")).OriginalText, "originalText");
		}

		[SetUp]
		public virtual void Setup()
		{
			CodeResolverRegistry.Register(new TrivialCodeResolver());
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}
	}
}
