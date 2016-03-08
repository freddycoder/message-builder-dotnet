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


/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Xml {
	
	using NUnit;
    using System;
    using System.Collections.Generic;
	
	[NUnit.Framework.TestFixture]
	public class Hl7TypeParserTest {
	
		[NUnit.Framework.Test]
		public void ShouldParseSimpleCase() {
			Hl7TypeName name = new Hl7TypeParser().Parse("ST");
			NUnit.Framework.Assert.AreEqual("ST",((String) name.ToString()),"name");
		}
	
		[NUnit.Framework.Test]
		public void ShouldParseParameterizedTypes() {
			Hl7TypeName name = new Hl7TypeParser().Parse("SET<ST>");
			NUnit.Framework.Assert.AreEqual("SET<ST>",((String) name.ToString()),"name");
			NUnit.Framework.Assert.AreEqual("SET",name.UnparameterizedName,"base");
		}
	
		[NUnit.Framework.Test]
		public void ShouldParseComplexParameterizedTypes() {
			Hl7TypeName name = new Hl7TypeParser().Parse("SET<RTO<PQ,PQ>>");
			NUnit.Framework.Assert.AreEqual("SET<RTO<PQ,PQ>>",((String) name.ToString()),"name");
			NUnit.Framework.Assert.AreEqual("SET",name.UnparameterizedName,"base");
            NUnit.Framework.Assert.AreEqual(1, name.Parameters.Count, "parameter count");
	
			Hl7TypeName parameter = name.Parameters[0];
			NUnit.Framework.Assert.AreEqual("RTO",parameter.UnparameterizedName,"parameter name");
            NUnit.Framework.Assert.AreEqual(2, parameter.Parameters.Count, "parameters of parameter count");
		}
	
		[NUnit.Framework.Test]
		public void ShouldStripWhitespace() {
			Hl7TypeName name = new Hl7TypeParser().Parse("SET<RTO<PQ, PQ>>");
			NUnit.Framework.Assert.AreEqual("SET<RTO<PQ,PQ>>",((String) name.ToString()),"name");
			NUnit.Framework.Assert.AreEqual("SET",name.UnparameterizedName,"base");
            NUnit.Framework.Assert.AreEqual(1, name.Parameters.Count, "parameter count");
	
			Hl7TypeName parameter = name.Parameters[0];
			NUnit.Framework.Assert.AreEqual("RTO",parameter.UnparameterizedName,"parameter name");
            NUnit.Framework.Assert.AreEqual(2, parameter.Parameters.Count, "parameters of parameter count");
		}
	
		[NUnit.Framework.Test]
		public void ShouldSplitOnCommas() {
			IList<String> parts = new Hl7TypeParser().Split("PQ.DRUG,PQ.QUANTITY");
            NUnit.Framework.Assert.AreEqual(2, parts.Count, "count");
			NUnit.Framework.Assert.AreEqual("PQ.DRUG",parts[0],"first part");
		}
	
		[NUnit.Framework.Test]
		public void ShouldNotSplitOnNestedCommas() {
			IList<String> parts = new Hl7TypeParser()
					.Split("RTO<PQ.DRUG,PQ.QUANTITY>");
            NUnit.Framework.Assert.AreEqual(1, parts.Count, "count");
			NUnit.Framework.Assert.AreEqual("RTO<PQ.DRUG,PQ.QUANTITY>",parts[0],"first part");
		}
	}
}
