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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class XmlToCdaModelResult : TransformErrors
	{
		private XmlToModelResult delegate_;

		internal IList<TransformError> errors = new List<TransformError>();

		internal XmlToCdaModelResult(XmlToModelResult result)
		{
			this.delegate_ = result;
			foreach (Hl7Error error in result.GetHl7Errors())
			{
				errors.Add(new TransformError(error));
			}
		}

		public virtual object GetClinicalDocumentObject()
		{
			return this.delegate_.GetMessageObject();
		}

		public virtual bool IsValid()
		{
			return this.delegate_.IsValid();
		}

		public virtual bool HasErrors()
		{
			return this.delegate_.HasErrors();
		}

		public virtual bool HasWarnings()
		{
			return this.delegate_.HasWarnings();
		}

		public virtual IList<TransformError> GetErrors()
		{
			return this.errors;
		}
	}
}
