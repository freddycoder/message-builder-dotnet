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
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Util
{
	[TestFixture]
	public class DomainTypeHelperTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldSanitizeDomainName()
		{
			Assert.AreEqual("NonPersonLivingSubject", DomainTypeHelper.Sanitize("Non-personLivingSubject"), "1");
			Assert.AreEqual("HL7TriggerEventCode", DomainTypeHelper.Sanitize("HL7TriggerEventCode"), "2");
			Assert.AreEqual("x_VeryBasicConfidentialityKind", DomainTypeHelper.Sanitize("x_VeryBasicConfidentialityKind"), "3");
		}
	}
}
