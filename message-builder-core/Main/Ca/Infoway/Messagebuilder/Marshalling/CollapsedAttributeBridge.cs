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
using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class CollapsedAttributeBridge : AttributeBridge
	{
		private readonly Relationship relationship;

		private BareANY any;

		private object value;

		private readonly string propertyName;

		public CollapsedAttributeBridge(string propertyName, Relationship relationship, object value)
		{
			this.propertyName = propertyName;
			this.relationship = relationship;
			if (value is BareANY)
			{
				this.any = (BareANY)value;
				this.value = this.any.BareValue;
			}
			else
			{
				this.value = value;
				this.any = null;
			}
		}

		public virtual BareANY GetHl7Value()
		{
			return this.any;
		}

		public virtual BareANY GetHl7Value(int index)
		{
			throw new NotSupportedException();
		}

		public virtual object GetValue()
		{
			return this.value;
		}

		public virtual bool IsEmpty()
		{
			return this.value == null;
		}

		public virtual string GetPropertyName()
		{
			return this.propertyName;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual bool IsAssociation()
		{
			return false;
		}
	}
}
