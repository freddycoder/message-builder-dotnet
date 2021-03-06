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

		private readonly string propertyName;

		public MockAttributeBridge(string propertyName)
		{
			this.propertyName = propertyName;
		}

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
