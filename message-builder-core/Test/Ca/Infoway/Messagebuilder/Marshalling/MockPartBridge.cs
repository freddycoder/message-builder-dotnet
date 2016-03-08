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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MockPartBridge : PartBridge
	{
		private bool isEmpty;

		private string typeName;

		private NullFlavor nullFlavor;

		private IList<Realm> realmCode;

		public virtual void SetTypeName(string typeName)
		{
			this.typeName = typeName;
		}

		public virtual void SetEmpty(bool isEmpty)
		{
			this.isEmpty = isEmpty;
		}

		public virtual string GetPropertyName()
		{
			return "aPropertyName2";
		}

		public virtual IList<BaseRelationshipBridge> GetRelationshipBridges()
		{
			return CollUtils.EmptyList<BaseRelationshipBridge>();
		}

		public virtual string GetTypeName()
		{
			return this.typeName;
		}

		public virtual bool IsCollapsed()
		{
			return false;
		}

		public virtual bool IsEmpty()
		{
			return this.isEmpty;
		}

		public virtual NullFlavor GetNullFlavor()
		{
			return this.nullFlavor;
		}

		public virtual void SetNullFlavor(NullFlavor nullFlavor)
		{
			this.nullFlavor = nullFlavor;
		}

		public virtual bool HasNullFlavor()
		{
			return this.nullFlavor != null;
		}

		public virtual bool IsNullPart()
		{
			return false;
		}

		public virtual void AddRealmCode(Realm realmCode)
		{
			this.realmCode = new List<Realm>();
			this.realmCode.Add(realmCode);
		}

		public virtual IList<Realm> GetRealmCode()
		{
			return this.realmCode;
		}
	}
}
