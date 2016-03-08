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


using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT470000CA.Subject3", "RCMR_MT010001CA.Subject2" })]
	public class InformationAccessTypeBean : MessagePartBean
	{
		private const long serialVersionUID = -1127816597472476758L;

		private CD code = new CDImpl();

		[Hl7XmlMappingAttribute(new string[] { "actDefinition/code", "recordType/code" })]
		public virtual ActInformationAccessTypeCode GetCode()
		{
			return (ActInformationAccessTypeCode)this.code.Value;
		}

		public virtual void SetCode(ActInformationAccessTypeCode code)
		{
			this.code.Value = code;
		}
	}
}
