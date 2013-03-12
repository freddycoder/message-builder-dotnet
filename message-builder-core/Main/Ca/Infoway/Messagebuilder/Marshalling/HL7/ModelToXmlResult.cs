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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class ModelToXmlResult : Hl7Errors
	{
		private string xmlMessage;

		private readonly IList<Hl7Error> hl7Errors = new List<Hl7Error>();

		public virtual string GetXmlMessage()
		{
			return this.xmlMessage;
		}

		public virtual string GetXmlMessageWithoutFormatting()
		{
			return this.xmlMessage == null ? null : System.Text.RegularExpressions.Regex.Replace(this.xmlMessage, ">\\s+<", "><");
		}

		public virtual void SetXmlMessage(string xmlMessage)
		{
			this.xmlMessage = xmlMessage;
		}

		public virtual bool IsValid()
		{
			return this.hl7Errors.Count == 0;
		}

		public virtual void AddHl7Error(Hl7Error hl7Error)
		{
			this.hl7Errors.Add(hl7Error);
		}

		public virtual IList<Hl7Error> GetHl7Errors()
		{
			return this.hl7Errors;
		}

		public virtual void ClearErrors()
		{
			this.hl7Errors.Clear();
		}
	}
}
