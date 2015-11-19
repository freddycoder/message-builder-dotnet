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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	public class IiConstraintsHandler
	{
		private static readonly ConstraintsHandler constraintsHandler = new ConstraintsHandler();

		public IiConstraintsHandler()
		{
		}

		public virtual void HandleConstraints(ConstrainedDatatype constraints, Identifier identifier, ErrorLogger logger, bool isSingleCardinality
			)
		{
			if (identifier == null || constraints == null)
			{
				return;
			}
			bool isTemplateId = (constraints.Name == null ? false : constraints.Name.EndsWith(".templateId"));
			string newRoot = constraintsHandler.ValidateConstraint("root", identifier.Root, constraints, logger, isSingleCardinality 
				&& isTemplateId);
			string newExtension = constraintsHandler.ValidateConstraint("extension", identifier.Extension, constraints, logger);
			identifier.Root = newRoot;
			identifier.Extension = newExtension;
		}
	}
}
