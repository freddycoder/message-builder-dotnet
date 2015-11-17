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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	public class IiCollectionConstraintHandler
	{
		public class ConstraintResult
		{
			private readonly Identifier identifer;

			private readonly bool foundMatch;

			private readonly bool isTemplateId;

			public ConstraintResult(IiCollectionConstraintHandler _enclosing, bool foundMatch, bool isTemplateId, Identifier identifer
				)
			{
				this._enclosing = _enclosing;
				this.foundMatch = foundMatch;
				this.isTemplateId = isTemplateId;
				this.identifer = identifer;
			}

			public virtual Identifier GetIdentifer()
			{
				return this.identifer;
			}

			public virtual bool IsFoundMatch()
			{
				return this.foundMatch;
			}

			public virtual bool IsTemplateId()
			{
				return this.isTemplateId;
			}

			private readonly IiCollectionConstraintHandler _enclosing;
		}

		public virtual IiCollectionConstraintHandler.ConstraintResult CheckConstraints(string type, ConstrainedDatatype constraints
			, ICollection<BareANY> collection)
		{
			// pull out root/extension fixed constraints
			// check for a match within collection
			// if no match, add to collection (last?)
			if (constraints != null && collection != null)
			{
				if ("II".Equals(type))
				{
					string fixedRootValue = null;
					Relationship rootRelationship = constraints.GetRelationship("root");
					if (rootRelationship != null)
					{
						fixedRootValue = rootRelationship.FixedValue;
					}
					string fixedExtensionValue = null;
					Relationship extensionRelationship = constraints.GetRelationship("extension");
					if (extensionRelationship != null)
					{
						fixedExtensionValue = extensionRelationship.FixedValue;
					}
					bool hasFixedConstraint = fixedRootValue != null || fixedExtensionValue != null;
					if (hasFixedConstraint)
					{
						Identifier matchingIdentifier = null;
						foreach (BareANY item in collection)
						{
							object value = item.BareValue;
							if (value is Identifier)
							{
								Identifier id = (Identifier)value;
								if (fixedRootValue == null || fixedRootValue.Equals(id.Root))
								{
									if (fixedExtensionValue == null || fixedExtensionValue.Equals(id.Extension))
									{
										matchingIdentifier = id;
										break;
									}
								}
							}
						}
						bool foundMatch = (matchingIdentifier != null);
						bool isTemplateId = (constraints.Name == null ? false : constraints.Name.EndsWith(".templateId"));
						Identifier identifer = (foundMatch ? matchingIdentifier : new Identifier(fixedRootValue, fixedExtensionValue));
						return new IiCollectionConstraintHandler.ConstraintResult(this, foundMatch, isTemplateId, identifer);
					}
				}
			}
			return null;
		}
	}
}
