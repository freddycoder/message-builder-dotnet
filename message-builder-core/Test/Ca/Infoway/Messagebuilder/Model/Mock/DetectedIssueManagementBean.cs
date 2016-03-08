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
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PORX_MT980010CA.DetectedIssueManagement", "PORX_MT980030CA.DetectedIssueManagement"
		 })]
	public class DetectedIssueManagementBean : MessagePartBean
	{
		private const long serialVersionUID = 5300042834504076009L;

		private CD code = new CDImpl();

		private CD statusCode = new CDImpl();

		private AuthorBean author = new AuthorBean();

		private ST text = new STImpl();

		public DetectedIssueManagementBean() : base()
		{
		}

		[Hl7XmlMappingAttribute(new string[] { "code" })]
		public virtual ActDetectedIssueManagementCode GetCode()
		{
			return (ActDetectedIssueManagementCode)this.code.Value;
		}

		public virtual void SetCode(ActDetectedIssueManagementCode code)
		{
			this.code.Value = code;
		}

		public virtual ActStatus GetStatusCode()
		{
			return (ActStatus)this.statusCode.Value;
		}

		public virtual void SetStatusCode(ActStatus statusCode)
		{
			this.statusCode.Value = statusCode;
		}

		[Hl7XmlMappingAttribute(new string[] { "author" })]
		public virtual AuthorBean GetAuthor()
		{
			return author;
		}

		public virtual void SetAuthor(AuthorBean author)
		{
			this.author = author;
		}

		[Hl7XmlMappingAttribute(new string[] { "text" })]
		public virtual string GetText()
		{
			return this.text.Value;
		}

		public virtual void SetText(string text)
		{
			this.text.Value = text;
		}
	}
}
