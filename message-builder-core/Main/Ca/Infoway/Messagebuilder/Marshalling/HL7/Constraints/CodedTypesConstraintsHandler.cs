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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	public class CodedTypesConstraintsHandler
	{
		private readonly ConstraintsHandler constraintsHandler = new ConstraintsHandler();

		private readonly TrivialCodeResolver trivialCodeResolver = new TrivialCodeResolver();

		public CodedTypesConstraintsHandler()
		{
		}

		// only the following constraints are being handled for now:
		//	qualifier (mandatory)
		//	qualifier.name (mandatory)
		//	qualifier.name.code (mandatory, fixed)
		//	qualifier.name.codeSystem (mandatory, fixed)
		//	qualifier.value (mandatory)
		//	codeSystem (mandatory, fixed)
		public virtual void HandleConstraints(ConstrainedDatatype constraints, CodedTypeR2<Code> codedType, ErrorLogger logger)
		{
			if (codedType == null || constraints == null)
			{
				return;
			}
			IList<CodeRole> qualifiers = codedType.Qualifier;
			int numberOfQualifiers = qualifiers.Count;
			// check if qualifier fits into constrained number of items (1, 0-1)
			this.constraintsHandler.ValidateConstraint("qualifier", qualifiers.IsEmpty() ? null : "qualifiers", constraints, logger);
			// just checks if any qualifiers provided
			if (numberOfQualifiers == 1)
			{
				// if only one qualifier present, check other qualifier constraints
				CodeRole qualifier = qualifiers[0];
				CodedTypeR2<Code> qualifierName = qualifier.Name;
				this.constraintsHandler.ValidateConstraint("qualifier.name", qualifierName == null ? null : "qualifierName", constraints, 
					logger);
				// just checks if name provided
				if (qualifierName != null)
				{
					string nameCode = qualifierName.GetCodeValue();
					string newNameCode = this.constraintsHandler.ValidateConstraint("qualifier.name.code", nameCode, constraints, logger);
					string nameCodeSystem = qualifierName.GetCodeSystem();
					string newNameCodeSystem = this.constraintsHandler.ValidateConstraint("qualifier.name.codeSystem", nameCodeSystem, constraints
						, logger);
					if (!StringUtils.Equals(nameCode, newNameCode) || !StringUtils.Equals(nameCodeSystem, newNameCodeSystem))
					{
						Type type = typeof(Code);
						//For .NET translation
						Code newName = this.trivialCodeResolver.Lookup<Code>(type, newNameCode, newNameCodeSystem);
						qualifierName.Code = newName;
					}
				}
				CodedTypeR2<Code> qualifierValue = qualifier.Value;
				this.constraintsHandler.ValidateConstraint("qualifier.value", qualifierValue == null ? null : "qualifierValue", constraints
					, logger);
			}
			else
			{
				// just checks if value provided
				if (numberOfQualifiers > 1)
				{
					// (qualifier can be constrained to at most 1 and to exactly 1)
					Relationship qualifierConstraint = constraints.GetRelationship("qualifier");
					if (qualifierConstraint != null)
					{
						Cardinality qualifierConstraintCardinality = qualifierConstraint.Cardinality;
						if (qualifierConstraintCardinality != null && !qualifierConstraintCardinality.Contains(numberOfQualifiers))
						{
							string message = System.String.Format("Property {0} of type {1} is constrained to a cardinality of {2} but contains {3} values"
								, "qualifier", constraints.BaseType, qualifierConstraintCardinality, numberOfQualifiers);
							logger.LogError(Hl7ErrorCode.CDA_CARDINALITY_CONSTRAINT, ErrorLevel.ERROR, message);
						}
					}
				}
			}
			string codeSystem = codedType.GetCodeSystem();
			codeSystem = StringUtils.IsBlank(codeSystem) ? "not provided" : codeSystem;
			string newCodedSystem = this.constraintsHandler.ValidateConstraint("codeSystem", codeSystem, constraints, logger);
			if (!StringUtils.Equals(codeSystem, newCodedSystem))
			{
			}
		}
		// String codeValue = codedType.getCodeValue();
		// we have the current code value and new codeSystem, but to create a new value we need the actual code class for the codedType
		// need domain passed in... (see CodeLookupUtils/MessageBeanRegistry)
		// TODO CDA - TM - create new code - this may not be feasible; for now, log a missing constraint error (forced via replacing a missing codeSystem with "not provided")
	}
}
