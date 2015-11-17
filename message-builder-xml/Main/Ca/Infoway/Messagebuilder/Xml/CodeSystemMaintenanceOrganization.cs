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
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class CodeSystemMaintenanceOrganization
	{
		[XmlAttributeAttribute(Required = false)]
		private string name;

		[XmlAttributeAttribute(Required = false)]
		private string repositoryUrl;

		public CodeSystemMaintenanceOrganization()
		{
		}

		public CodeSystemMaintenanceOrganization(string name)
		{
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

		public virtual string RepositoryUrl
		{
			get
			{
				return repositoryUrl;
			}
			set
			{
				string repositoryUrl = value;
				this.repositoryUrl = repositoryUrl;
			}
		}
	}
}
