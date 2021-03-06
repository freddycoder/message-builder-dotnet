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
	public class SeverityObservationBean : MessagePartBean
	{
		private const long serialVersionUID = 3635762510647290962L;

		private CD code = new CDImpl();

		private CD statusCode = new CDImpl();

		private CD severityObservation = new CDImpl();

		public SeverityObservationBean() : base()
		{
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual Ca.Infoway.Messagebuilder.Domainvalue.ActCode GetCode()
		{
			return (Ca.Infoway.Messagebuilder.Domainvalue.ActCode)this.code.Value;
		}

		public virtual void SetCode(Ca.Infoway.Messagebuilder.Domainvalue.ActCode code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute("statusCode")]
		public virtual ActStatus GetStatusCode()
		{
			return (ActStatus)this.statusCode.Value;
		}

		public virtual void SetStatusCode(ActStatus statusCode)
		{
			this.statusCode.Value = statusCode;
		}

		[Hl7XmlMappingAttribute("value")]
		public virtual SeverityObservation GetSeverityObservation()
		{
			return (SeverityObservation)this.severityObservation.Value;
		}

		public virtual void SetSeverityObservation(SeverityObservation severityObservation)
		{
			this.severityObservation.Value = severityObservation;
		}
	}
}
