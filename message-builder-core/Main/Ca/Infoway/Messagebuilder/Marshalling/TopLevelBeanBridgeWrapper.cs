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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class TopLevelBeanBridgeWrapper : PartBridge
	{
		public class FixedValueIfNotProvidedAttributeBeanBridge : FixedValueAttributeBeanBridge
		{
			private readonly AttributeBridge relationshipBridge;

			public FixedValueIfNotProvidedAttributeBeanBridge(TopLevelBeanBridgeWrapper _enclosing, AttributeBridge relationshipBridge
				, BareANY any) : base(relationshipBridge.GetRelationship(), any)
			{
				this._enclosing = _enclosing;
				this.relationshipBridge = relationshipBridge;
			}

			public override BareANY GetHl7Value()
			{
				BareANY any = this.relationshipBridge.GetHl7Value();
				if (any == null || any.BareValue == null)
				{
					return base.GetHl7Value();
				}
				else
				{
					return any;
				}
			}

			private readonly TopLevelBeanBridgeWrapper _enclosing;
		}

		private readonly PartBridge bridge;

		private readonly string interactionId;

		private readonly VersionNumber version;

		private readonly IiValidationUtils iiValidationUtils = new IiValidationUtils();

		public TopLevelBeanBridgeWrapper(PartBridge bridge, string interactionId, VersionNumber version)
		{
			this.bridge = bridge;
			this.interactionId = interactionId;
			this.version = version;
		}

		public virtual IList<BaseRelationshipBridge> GetRelationshipBridges()
		{
			IList<BaseRelationshipBridge> result = new List<BaseRelationshipBridge>();
			foreach (BaseRelationshipBridge relationshipBridge in this.bridge.GetRelationshipBridges())
			{
				if ("versionCode".Equals(relationshipBridge.GetRelationship().Name) && !relationshipBridge.GetRelationship().Fixed)
				{
					result.Add(new TopLevelBeanBridgeWrapper.FixedValueIfNotProvidedAttributeBeanBridge(this, (AttributeBridge)relationshipBridge
						, new CSImpl(Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode.V3_2007_05)));
				}
				else
				{
					if ("interactionId".Equals(relationshipBridge.GetRelationship().Name))
					{
						IIImpl iiImpl = new IIImpl(new Identifier("2.16.840.1.113883.1.6", this.interactionId));
						if (iiValidationUtils.IsSpecializationTypeRequired(version, relationshipBridge.GetRelationship().Type))
						{
							// we must set a concrete specialization type when defined as abstract
							iiImpl.DataType = StandardDataType.II_PUBLIC;
						}
						result.Add(new TopLevelBeanBridgeWrapper.FixedValueIfNotProvidedAttributeBeanBridge(this, (AttributeBridge)relationshipBridge
							, iiImpl));
					}
					else
					{
						result.Add(relationshipBridge);
					}
				}
			}
			return result;
		}

		public virtual string GetTypeName()
		{
			return this.interactionId;
		}

		public virtual bool IsEmpty()
		{
			return this.bridge.IsEmpty();
		}

		public virtual string GetPropertyName()
		{
			return this.bridge.GetPropertyName();
		}

		public virtual bool IsCollapsed()
		{
			return false;
		}

		public virtual NullFlavor GetNullFlavor()
		{
			return null;
		}

		public virtual bool HasNullFlavor()
		{
			return false;
		}

		public virtual bool IsNullPart()
		{
			return false;
		}
	}
}
