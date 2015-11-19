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
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	public class ConstraintsHandler
	{
		public ConstraintsHandler()
		{
		}

		public virtual bool HasFixedConstraint(string name, ConstrainedDatatype constraints)
		{
			Relationship constrainedRelationship = ObtainConstraint(name, constraints);
			string fixedConstraint = ObtainFixedValue(constrainedRelationship);
			return StringUtils.IsNotBlank(fixedConstraint);
		}

		public virtual string ValidateConstraint(string name, string value, ConstrainedDatatype constraints, ErrorLogger errorLogger
			)
		{
			return ValidateConstraint(name, value, constraints, errorLogger, false);
		}

		public virtual string ValidateConstraint(string name, string value, ConstrainedDatatype constraints, ErrorLogger errorLogger
			, bool isSingletonTemplateIdRoot)
		{
			if (constraints == null)
			{
				return value;
			}
			string newValue = value;
			// check fixed constraint
			Relationship constrainedRelationship = ObtainConstraint(name, constraints);
			string fixedConstraint = ObtainFixedValue(constrainedRelationship);
			bool hasFixedConstraint = StringUtils.IsNotBlank(fixedConstraint);
			if (hasFixedConstraint)
			{
				if (!StringUtils.Equals(value, fixedConstraint))
				{
					if (StringUtils.IsBlank(value))
					{
						// this is an acceptable case; send back the fixed value to use instead
						newValue = fixedConstraint;
					}
					else
					{
						// leave the value as is, but log an error
						LogFixedConstraintError(name, value, fixedConstraint, constraints.BaseType, errorLogger, isSingletonTemplateIdRoot);
					}
				}
				if (StringUtils.Equals(newValue, fixedConstraint) && isSingletonTemplateIdRoot)
				{
					LogTemplateIdFound(fixedConstraint, errorLogger);
				}
			}
			// check cardinality constraint (but only if there wasn't a fixed value constraint) 
			bool isMandatory = ObtainMandatory(constrainedRelationship);
			if (isMandatory && !hasFixedConstraint && StringUtils.IsBlank(value))
			{
				LogMandatoryConstraintError(name, constraints.BaseType, errorLogger);
			}
			bool isProhibited = ObtainProhibited(constrainedRelationship);
			if (isProhibited && StringUtils.IsNotBlank(value))
			{
				LogProhibitedConstraintError(name, constraints.BaseType, errorLogger);
			}
			return newValue;
		}

		private void LogMandatoryConstraintError(string name, string type, ErrorLogger errorLogger)
		{
			string message = System.String.Format("Property {0} of type {1} is constrained to be mandatory but no value was provided"
				, name, type);
			errorLogger.LogError(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, ErrorLevel.ERROR, message);
		}

		private void LogFixedConstraintError(string name, string value, string fixedConstraint, string type, ErrorLogger errorLogger
			, bool isSingletonTemplateIdRoot)
		{
			string message = System.String.Format("Property {0} of type {1} is constrained to a fixed value of {2} but was {3}", name
				, type, fixedConstraint, value);
			Hl7ErrorCode error = (isSingletonTemplateIdRoot ? Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING : Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING
				);
			errorLogger.LogError(error, ErrorLevel.ERROR, message);
		}

		private void LogTemplateIdFound(string fixedConstraint, ErrorLogger errorLogger)
		{
			string message = System.String.Format("Found match for templateId fixed constraint: {0}", fixedConstraint);
			errorLogger.LogError(Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MATCH, ErrorLevel.INFO, message);
		}

		private void LogProhibitedConstraintError(string name, string type, ErrorLogger errorLogger)
		{
			string message = System.String.Format("Property {0} of type {1} is constrained to be prohibited but a value was provided"
				, name, type);
			errorLogger.LogError(Hl7ErrorCode.CDA_PROHIBITED_CONSTRAINT, ErrorLevel.ERROR, message);
		}

		private bool ObtainMandatory(Relationship constrainedRelationship)
		{
			if (constrainedRelationship != null)
			{
				Cardinality cardinality = constrainedRelationship.Cardinality;
				return cardinality != null && cardinality.Mandatory;
			}
			return false;
		}

		private bool ObtainProhibited(Relationship constrainedRelationship)
		{
			if (constrainedRelationship != null)
			{
				Cardinality cardinality = constrainedRelationship.Cardinality;
				return cardinality != null && cardinality.Max == 0;
			}
			return false;
		}

		private string ObtainFixedValue(Relationship constrainedRelationship)
		{
			if (constrainedRelationship != null)
			{
				return constrainedRelationship.FixedValue;
			}
			return null;
		}

		private Relationship ObtainConstraint(string name, ConstrainedDatatype constraints)
		{
			Relationship result = null;
			if (constraints != null)
			{
				result = constraints.GetRelationship(name);
			}
			return result;
		}
	}
}
