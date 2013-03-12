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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MockAttributeBridge : AttributeBridge
	{
		private BareANY hl7Value;

		private object value;

		private bool isEmpty;

		internal Relationship relationship;

		public virtual void SetHl7Value(BareANY hl7Value)
		{
			this.hl7Value = hl7Value;
		}

		public virtual BareANY GetHl7Value()
		{
			return this.hl7Value;
		}

		public virtual BareANY GetHl7Value(int index)
		{
			return null;
		}

		public virtual object GetValue()
		{
			return this.value;
		}

		public virtual bool IsEmpty()
		{
			return this.isEmpty;
		}

		public virtual string GetPropertyName()
		{
			return null;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual bool IsAssociation()
		{
			return false;
		}

		public virtual void SetValue(object value)
		{
			this.value = value;
		}

		public virtual void SetEmpty(bool isEmpty)
		{
			this.isEmpty = isEmpty;
		}
	}
}
