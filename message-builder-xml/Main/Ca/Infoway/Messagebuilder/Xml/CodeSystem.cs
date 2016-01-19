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
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class CodeSystem
	{
		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute]
		private string businessName;

		[XmlAttributeAttribute]
		private string oid;

		[XmlAttributeAttribute(Required = false)]
		private string versionId;

		[XmlAttributeAttribute(Required = false)]
		private PlatformDate releaseDate;

		[XmlAttributeAttribute]
		private bool complete;

		[ElementAttribute(Required = false)]
		private CodeSystemMaintenanceOrganization maintenanceOrganization = new CodeSystemMaintenanceOrganization();

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation = new Ca.Infoway.Messagebuilder.Xml.Documentation();

		[ElementListAttribute(Required = false, Inline = false, Name = "concepts", Entry = "concept")]
		private List<Concept> concepts = new List<Concept>();

		public CodeSystem()
		{
		}

		public CodeSystem(string name)
		{
			// RM 17524: TM - changed to ArrayList to prevent simpleframework from outputting java class reference
			this.Name = name;
		}

		public virtual string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				string name = value;
				this.name = name;
			}
		}

		public virtual string BusinessName
		{
			get
			{
				return businessName;
			}
			set
			{
				string businessName = value;
				this.businessName = businessName;
			}
		}

		public virtual string Oid
		{
			get
			{
				return oid;
			}
			set
			{
				string oid = value;
				this.oid = oid;
			}
		}

		public virtual string VersionId
		{
			get
			{
				return versionId;
			}
			set
			{
				string versionId = value;
				this.versionId = versionId;
			}
		}

		public virtual PlatformDate ReleaseDate
		{
			get
			{
				return releaseDate;
			}
			set
			{
				PlatformDate releaseDate = value;
				this.releaseDate = releaseDate;
			}
		}

		public virtual bool Complete
		{
			get
			{
				return complete;
			}
			set
			{
				bool complete = value;
				this.complete = complete;
			}
		}

		public virtual CodeSystemMaintenanceOrganization MaintenanceOrganization
		{
			get
			{
				return maintenanceOrganization;
			}
			set
			{
				CodeSystemMaintenanceOrganization maintenanceOrganization = value;
				this.maintenanceOrganization = maintenanceOrganization;
			}
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.Documentation Documentation
		{
			get
			{
				return documentation;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.Documentation documentation = value;
				this.documentation = documentation;
			}
		}

		public virtual List<Concept> Concepts
		{
			get
			{
				return concepts;
			}
			set
			{
				List<Concept> concepts = value;
				this.concepts = concepts;
			}
		}
	}
}
