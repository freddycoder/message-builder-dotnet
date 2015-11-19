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
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal interface Hl7Source
	{
		MessageDefinitionService GetService();

		string GetMessagePartName();

		XmlElement GetCurrentElement();

		VersionNumber GetVersion();

		TimeZoneInfo GetDateTimeZone();

		TimeZoneInfo GetDateTimeTimeZone();

		string Type
		{
			get;
		}

		XmlToModelResult GetResult();

		Hl7PartSource CreatePartSource(Relationship relationship, XmlElement currentElement);

		Hl7PartSource CreatePartSourceForSpecificType(Relationship relationship, XmlElement currentElement, string type);

		Relationship GetRelationship(string name);

		IList<Relationship> GetAllRelationships();

		Interaction GetInteraction();

		bool IsR2();

		bool IsCda();
	}
}
