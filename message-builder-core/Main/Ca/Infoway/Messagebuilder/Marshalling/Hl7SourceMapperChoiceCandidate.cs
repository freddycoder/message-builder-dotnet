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

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class Hl7SourceMapperChoiceCandidate
	{
		private readonly object parsedBean;

		private readonly IList<Hl7Error> storedErrors = new List<Hl7Error>();

		internal Hl7SourceMapperChoiceCandidate(object parsedBean)
		{
			this.parsedBean = parsedBean;
		}

		internal virtual object GetParsedBean()
		{
			return this.parsedBean;
		}

		internal virtual IList<Hl7Error> GetStoredErrors()
		{
			return this.storedErrors;
		}

		internal virtual void AddError(Hl7Error error)
		{
			this.storedErrors.Add(error);
		}

		internal virtual bool IsAcceptableChoiceCandidate(int currentErrorLevel)
		{
			// to be acceptable can't have any templateId errors in the first two levels past choice
			// to be acceptable can't have any missing mandatory associations in the first level past choice
			// to be acceptable can't have any invalid association cardinality errors in the first two levels past choice
			foreach (Hl7Error hl7Error in this.storedErrors)
			{
				if (hl7Error.GetErrorDepth() - currentErrorLevel == 0)
				{
					// a "missing" error actually appears to be one level higher (we never get to the missing node)
					if (hl7Error.GetHl7ErrorCode() == Hl7ErrorCode.MANDATORY_ASSOCIATION_NOT_PROVIDED)
					{
						return false;
					}
				}
				if (hl7Error.GetErrorDepth() - currentErrorLevel <= 1)
				{
					// actually a depth of two, as the error is reported one level higher
					if (hl7Error.GetHl7ErrorCode() == Hl7ErrorCode.NUMBER_OF_ASSOCIATIONS_INCORRECT_FOR_CARDINALITY)
					{
						return false;
					}
				}
				if (hl7Error.GetErrorDepth() - currentErrorLevel <= 2)
				{
					if (hl7Error.GetHl7ErrorCode() == Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING)
					{
						return false;
					}
				}
			}
			return true;
		}

		internal virtual bool HasTemplateIdMatch(int currentErrorLevel)
		{
			// to be a match must have correct template id fixed constraint within the first two levels past choice
			foreach (Hl7Error hl7Error in this.storedErrors)
			{
				if (hl7Error.GetErrorDepth() - currentErrorLevel <= 2)
				{
					if (hl7Error.GetHl7ErrorCode() == Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MATCH)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
