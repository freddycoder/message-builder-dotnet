/**
 * Copyright 2015 Canada Health Infoway, Inc.
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
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: NullAuthorRole</summary>
     * 
     * <remarks>QUQI_MT020000CA.AuthorRole: Null Author Role 
     * <p>This is a messaging artifact used by HL7 to allow the 
     * time, signiture and method to be captured when the author is 
     * not sent. This will happen in circumstances where the author 
     * information is sent as part of the authentication token.</p> 
     * MCAI_MT700210CA.AuthorRole: Null Author Role <p>This is a 
     * messaging artifact used by HL7 to allow the time, signiture 
     * and method to be captured when the author is not sent. This 
     * will happen in circumstances where the author information is 
     * sent as part of the authentication token.</p> 
     * QUQI_MT020002CA.AuthorRole: Null Author Role <p>This is a 
     * messaging artifact used by HL7 to allow the time, signiture 
     * and method to be captured when the author is not sent. This 
     * will happen in circumstances where the author information is 
     * sent as part of the authentication token.</p> 
     * MCAI_MT700211CA.AuthorRole: Null Author Role <p>This is a 
     * messaging artifact used by HL7 to allow the time, signiture 
     * and method to be captured when the author is not sent. This 
     * will happen in circumstances where the author information is 
     * sent as part of the authentication token.</p> 
     * MCAI_MT700220CA.AuthorRole: Null Author Role <p>This is a 
     * messaging artifact used by HL7 to allow the time, signiture 
     * and method to be captured when the author is not sent. This 
     * will happen in circumstances where the author information is 
     * sent as part of the authentication token.</p> 
     * MFMI_MT700711CA.AuthorRole: Null Author Role <p>This is a 
     * messaging artifact used by HL7 to allow the time, signiture 
     * and method to be captured when the author is not sent. This 
     * will happen in circumstances where the author information is 
     * sent as part of the authentication token.</p> 
     * MCAI_MT700212CA.AuthorRole: Null Author Role <p>This is a 
     * messaging artifact used by HL7 to allow the time, signiture 
     * and method to be captured when the author is not sent. This 
     * will happen in circumstances where the author information is 
     * sent as part of the authentication token.</p> 
     * MFMI_MT700751CA.AuthorRole: Null Author Role <p>This is a 
     * messaging artifact used by HL7 to allow the time, signiture 
     * and method to be captured when the author is not sent. This 
     * will happen in circumstances where the author information is 
     * sent as part of the authentication token.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700210CA.AuthorRole","MCAI_MT700211CA.AuthorRole","MCAI_MT700212CA.AuthorRole","MCAI_MT700220CA.AuthorRole","MFMI_MT700711CA.AuthorRole","MFMI_MT700751CA.AuthorRole","QUQI_MT020000CA.AuthorRole","QUQI_MT020002CA.AuthorRole"})]
    public class NullAuthorRole : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Merged.IAuthorPerson_2, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Merged.IAuthorPerson_1 {


        public NullAuthorRole() {
        }
    }

}