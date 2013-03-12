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
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class GenericDataTypeFactoryTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFindIntervalTypes()
		{
			AssertType("IVL<PQ.BASIC>");
			AssertType("IVL<TS.FULLDATETIME>");
			AssertType("IVL<TS.DATE>");
		}

		private void AssertType(string type)
		{
			Assert.IsNotNull(GenericDataTypeFactory.Create(type), "type " + type);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFindListTypes()
		{
			AssertType("LIST<II.OID>");
			AssertType("LIST<GTS.BOUNDEDPIVL>");
			AssertType("LIST<PN.BASIC>");
			AssertType("LIST<TEL.PHONEMAIL>");
		}
	}
}
