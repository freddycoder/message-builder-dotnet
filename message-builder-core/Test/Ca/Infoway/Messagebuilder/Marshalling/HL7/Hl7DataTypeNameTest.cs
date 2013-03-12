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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	[TestFixture]
	public class Hl7DataTypeNameTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldDetermineUnqualifiedName()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("TS.FULLDATE");
			Assert.AreEqual("TS", name.GetUnqualifiedVersion().ToString());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldRecognizeQualifiedTypes()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("TS.FULLDATE");
			Assert.IsTrue(name.IsQualified(), "TS.FULLDATE");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldDetermineUnqualifiedCollectionName()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("SET<TS.FULLDATE>");
			Assert.AreEqual("SET<TS>", name.GetUnqualifiedVersion().ToString());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldDetermineUnqualifiedComplicatedName()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("RTO<MO.CAD,PQ.BASIC>");
			Assert.AreEqual("RTO<MO,PQ>", name.GetUnqualifiedVersion().ToString());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldDetermineUnqualifiedInnerTypesComplicatedName()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("IVL.LOW<PQ.LAB>");
			Assert.AreEqual("IVL.LOW<PQ>", name.GetUnqualifiedInnerTypesVersion().ToString());
		}
	}
}
