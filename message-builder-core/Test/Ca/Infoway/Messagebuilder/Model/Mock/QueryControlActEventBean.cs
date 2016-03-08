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


using System;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "MFMI_MT700751CA.ControlActEvent" })]
	public class QueryControlActEventBean<PL> : ControlActEventBean
	{
		private const long serialVersionUID = 7409413947816976194L;

		private ConsentEventBean consentEvent;

		private QueryByParameterBean<PL> queryByParameter = new QueryByParameterBean<PL>();

		public QueryControlActEventBean()
		{
		}

		public QueryControlActEventBean(PL criteria)
		{
			this.queryByParameter.ParameterList = criteria;
		}

		public virtual PL GetCriteria()
		{
			return this.queryByParameter.ParameterList;
		}

		public virtual Identifier QueryId
		{
			get
			{
				return this.queryByParameter.QueryIdentifier;
			}
			set
			{
				Identifier queryId = value;
				this.queryByParameter.QueryIdentifier = queryId;
			}
		}

		public virtual Int32? QueryLimit
		{
			get
			{
				return this.queryByParameter.QueryLimit;
			}
			set
			{
				Int32? queryLimit = value;
				this.queryByParameter.QueryLimit = queryLimit;
			}
		}

		[Hl7XmlMappingAttribute("subjectOf2/consentEvent")]
		public virtual ConsentEventBean ConsentEvent
		{
			get
			{
				return consentEvent;
			}
			set
			{
				ConsentEventBean consentEvent = value;
				this.consentEvent = consentEvent;
			}
		}

		[Hl7XmlMappingAttribute("queryByParameter")]
		public virtual QueryByParameterBean<PL> QueryByParameter
		{
			get
			{
				return this.queryByParameter;
			}
			set
			{
				QueryByParameterBean<PL> queryByParameter = value;
				this.queryByParameter = queryByParameter;
			}
		}
	}
}
