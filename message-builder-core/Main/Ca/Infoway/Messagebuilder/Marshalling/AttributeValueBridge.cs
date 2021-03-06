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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class AttributeValueBridge : AttributeBridge
	{
		private readonly ANY<object> any;

		private readonly object value;

		private readonly Relationship relationship;

		internal AttributeValueBridge(Relationship relationship, ANY<object> any)
		{
			this.relationship = relationship;
			this.any = any;
			this.value = any != null ? any.Value : null;
		}

		internal AttributeValueBridge(Relationship relationship, object value)
		{
			this.relationship = relationship;
			if (value is ANY<object>)
			{
				this.any = (ANY<object>)value;
				this.value = any.Value;
			}
			else
			{
				this.value = value;
				this.any = null;
			}
		}

		public virtual object GetValue()
		{
			return this.value;
		}

		public virtual bool IsEmpty()
		{
			return EmptinessUtil.IsEmpty(GetValue());
		}

		public virtual BareANY GetHl7Value()
		{
			return any;
		}

		public virtual string GetPropertyName()
		{
			return FixedValueAttributeBeanBridge.FIXED;
		}

		public virtual bool IsAssociation()
		{
			return false;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual BareANY GetHl7Value(int index)
		{
			throw new NotSupportedException();
		}
	}
}
