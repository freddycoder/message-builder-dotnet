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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	/// <summary>
	/// An object that represents the result of transforming an object from HL7 XML format
	/// to an object representation.
	/// </summary>
	/// <remarks>
	/// An object that represents the result of transforming an object from HL7 XML format
	/// to an object representation.  The result tends to contain two key items:
	/// 
	/// An object representation of the HL7 message that contains all of the populated
	/// data.
	/// A set of errors that were encountered during parsing of the message.
	/// 
	/// </remarks>
	/// <author>Intelliware Development</author>
	public class XmlToModelResult : Hl7Errors
	{
		private object messageObject;

		private readonly IList<Hl7Error> hl7Errors = new List<Hl7Error>();

		/// <summary>The object representation of the HL7 message.</summary>
		/// <remarks>The object representation of the HL7 message.</remarks>
		/// <returns>- the populated classes that contain the message data.</returns>
		public virtual object GetMessageObject()
		{
			return messageObject;
		}

		public virtual void SetMessageObject(object messageObject)
		{
			this.messageObject = messageObject;
		}

		public virtual bool HasErrors()
		{
			return HasErrorLevel(ErrorLevel.ERROR);
		}

		public virtual bool HasWarnings()
		{
			return HasErrorLevel(ErrorLevel.WARNING);
		}

		public virtual bool IsValid()
		{
			return !(HasErrors() || HasWarnings());
		}

		private bool HasErrorLevel(ErrorLevel level)
		{
			foreach (Hl7Error hl7Error in this.hl7Errors)
			{
				if (hl7Error.GetHl7ErrorLevel() == level)
				{
					return true;
				}
			}
			return false;
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
