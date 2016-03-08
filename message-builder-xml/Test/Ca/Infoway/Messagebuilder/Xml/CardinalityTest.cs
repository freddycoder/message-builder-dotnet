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


using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[TestFixture]
	public class CardinalityTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldCreateFromString()
		{
			Cardinality cardinality = Cardinality.Create("5");
			Assert.AreEqual(5, cardinality.Min.Value);
			Assert.AreEqual(5, cardinality.Max.Value);
			cardinality = Cardinality.Create("*");
			Assert.AreEqual(1, cardinality.Min.Value);
			Assert.AreEqual(int.MaxValue, cardinality.Max.Value);
			cardinality = Cardinality.Create("0-*");
			Assert.AreEqual(0, cardinality.Min.Value);
			Assert.AreEqual(int.MaxValue, cardinality.Max.Value);
			cardinality = Cardinality.Create("1-5");
			Assert.AreEqual(1, cardinality.Min.Value);
			Assert.AreEqual(5, cardinality.Max.Value);
			cardinality = Cardinality.Create("0..*");
			Assert.AreEqual(0, cardinality.Min.Value);
			Assert.AreEqual(int.MaxValue, cardinality.Max.Value);
			cardinality = Cardinality.Create("1..5");
			Assert.AreEqual(1, cardinality.Min.Value);
			Assert.AreEqual(5, cardinality.Max.Value);
		}
	}
}
