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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Xml {
	
	using NUnit;
	
	[NUnit.Framework.TestFixture]
	public class Hl7TypeNameTest {
	
		[NUnit.Framework.Test]
		public void ShouldCorrectlyIndicateEquality() {
			NUnit.Framework.Assert.IsTrue(Hl7TypeName.Parse("RTO < PQ.DRUG, PQ.TIME >").Equals(
                            Hl7TypeName.Parse("RTO<PQ.DRUG,PQ.TIME>")), "name");
            NUnit.Framework.Assert.IsFalse(Hl7TypeName.Parse("RTO < PQ.DRUG, PQ >")
                            .Equals(Hl7TypeName.Parse("RTO<PQ.DRUG,PQ.TIME>")), "different specialization");
		}

        [NUnit.Framework.Test]
        public void TestRootNames()
        {
            Hl7TypeName nameWithSpecialization = Hl7TypeName.Parse("IVL.LOW<TS.DATETIME>");
            Hl7TypeName nameWithoutSpecialization = Hl7TypeName.Parse("IVL<TS>");
            NUnit.Framework.Assert.IsTrue(nameWithoutSpecialization.ToString()
                .Equals(nameWithSpecialization.UnspecializedName));
        }
	}
}