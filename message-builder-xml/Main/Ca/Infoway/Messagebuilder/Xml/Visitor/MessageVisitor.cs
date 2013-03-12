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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml.Visitor
{
	public interface MessageVisitor
	{
		void VisitStructuralAttribute(XmlElement @base, XmlAttribute attr, Relationship relationship);

		void VisitAssociation(XmlElement @base, string xmlName, IList<XmlElement> elements, Relationship relationship);

		void VisitNonStructuralAttribute(XmlElement @base, IList<XmlElement> elements, Relationship relationship);

		void VisitRoot(XmlElement documentElement, Interaction interaction);
	}
}
