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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	public class EdConstraintsHandler
	{
		private readonly ConstraintsHandler constraintsHandler = new ConstraintsHandler();

		public EdConstraintsHandler()
		{
		}

		public virtual void HandleConstraints(ConstrainedDatatype constraints, EncapsulatedData ed, ErrorLogger logger)
		{
			if (ed == null || constraints == null)
			{
				return;
			}
			TelecommunicationAddress reference = ed.ReferenceObj;
			// ignoring any fixed value returned from reference constraints checking
			this.constraintsHandler.ValidateConstraint("reference", reference == null ? null : "reference", constraints, logger);
			// just checks if reference provided
			if (reference != null)
			{
				// only check this constraint if a reference has been provided (whether the reference was mandatory or not)
				string referenceValue = reference.ToString();
				this.constraintsHandler.ValidateConstraint("reference.value", referenceValue, constraints, logger);
			}
			// checks for actual value
			string mediaType = ed.MediaType == null ? null : ed.MediaType.CodeValue;
			string newMediaType = this.constraintsHandler.ValidateConstraint("mediaType", mediaType, constraints, logger);
			if (!StringUtils.Equals(mediaType, newMediaType))
			{
				x_DocumentMediaType newMediaTypeEnum = Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.Get(newMediaType);
				if (newMediaTypeEnum != null)
				{
					ed.MediaType = newMediaTypeEnum;
				}
			}
		}
	}
}
