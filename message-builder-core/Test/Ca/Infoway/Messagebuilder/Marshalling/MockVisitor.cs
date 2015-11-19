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
using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MockVisitor : Visitor
	{
		private bool rootStarted;

		private bool rootEnded;

		private bool attributeVisited;

		public virtual bool IsRootStarted()
		{
			return rootStarted;
		}

		public virtual void SetRootStarted(bool rootStarted)
		{
			this.rootStarted = rootStarted;
		}

		public virtual void VisitAssociationEnd(PartBridge tealBean, Relationship relationship)
		{
		}

		public virtual void VisitAssociationStart(PartBridge tealBean, Relationship relationship)
		{
		}

		public virtual void VisitAttribute(AttributeBridge tealBean, Relationship relationship, ConstrainedDatatype constraints, 
			VersionNumber version, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone)
		{
			this.attributeVisited = true;
		}

		public virtual void VisitRootEnd(PartBridge tealBean, Interaction interaction)
		{
			this.rootEnded = true;
		}

		public virtual void VisitRootStart(PartBridge tealBean, Interaction interaction)
		{
			this.rootStarted = true;
		}

		public virtual bool IsRootEnded()
		{
			return this.rootEnded;
		}

		public virtual bool IsAttributeVisited()
		{
			return this.attributeVisited;
		}

		public virtual void LogError(Hl7Error error)
		{
		}

		// do nothing
		public virtual string GetCurrentPropertyPath()
		{
			return string.Empty;
		}
	}
}
