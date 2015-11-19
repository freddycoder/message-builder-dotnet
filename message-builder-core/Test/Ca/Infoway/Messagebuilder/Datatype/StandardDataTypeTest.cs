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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype
{
	[TestFixture]
	public class StandardDataTypeTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldGetHl7TypeName()
		{
			Hl7TypeName typeName = StandardDataType.AD_BASIC.TypeName;
			Assert.AreEqual("AD.BASIC", typeName.ToString(), "name");
			Assert.AreEqual("AD", typeName.UnspecializedName, "unqualified name");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldGetRootName()
		{
			Assert.AreEqual("AD", StandardDataType.AD_BASIC.TypeName.RootName, "AD");
			Assert.AreEqual("IVL", StandardDataType.IVL_FULL_DATE.TypeName.RootName, "IVL");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldCalculateIsCoded()
		{
			Assert.IsTrue(StandardDataType.CD.Coded, "CD");
			Assert.IsTrue(StandardDataType.CD_LAB.Coded, "CD.LAB");
			Assert.IsTrue(StandardDataType.CV.Coded, "CV");
			Assert.IsFalse(StandardDataType.ST.Coded, "ST");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldResolveSimpleXmlType()
		{
			Assert.AreEqual(StandardDataType.II, StandardDataType.ConvertSimpleXmlToDataType("InstanceIdentifier"), "II");
			Assert.AreEqual(StandardDataType.TS_DATE, StandardDataType.ConvertSimpleXmlToDataType("PartialDate"), "TS.DATE");
		}
	}
}
