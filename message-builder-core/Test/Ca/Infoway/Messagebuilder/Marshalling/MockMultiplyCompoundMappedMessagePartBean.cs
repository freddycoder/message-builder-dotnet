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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

namespace Ca.Infoway.Messagebuilder.Marshalling {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;

	[Hl7PartTypeMappingAttribute(new string[] {"MOCK_MT898989CA"})]
	public class MockMultiplyCompoundMappedMessagePartBean {
	
		private MockSubType type = new MockSubType();
		private MockSubType2 type2 = new MockSubType2();
	
	    [Hl7XmlMappingAttribute(new string[] {"theType/theSubType/theSubSubType"})]
		[Hl7MapByPartType(Name="theType",Type="MOCK_MT123458CA.SubTypeA")]
		[Hl7MapByPartType(Name="theType/theSubType",Type="MOCK_MT123457CA.SubTypeB")]
		[Hl7MapByPartType(Name="theType/theSubType/theSubSubType",Type="MOCK_MT123456CA.SubType")]
		public MockSubType Type
		{
				get{return this.type;}
				set{this.type = value;}
		}
	
				
	    [Hl7XmlMappingAttribute(new string[] {"theType/theSubType/theSubSubType"})]
		[Hl7MapByPartType(Name="theType",Type="MOCK_MT123458CA.SubTypeA")]
		[Hl7MapByPartType(Name="theType/theSubType",Type="MOCK_MT123457CA.SubTypeB")]
		[Hl7MapByPartType(Name="theType/theSubType/theSubSubType",Type="MOCK_MT898989CA.SubType")]
		public MockSubType2 Type2
		{
				get{return this.type2;}
				set{this.type2 = value;}
		}
	}
}
