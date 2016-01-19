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


using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[RootAttribute]
	[NamespaceAttribute(Prefix = "regen", Reference = "regen_ns")]
	public class DifferenceValue
	{
		[XmlAttributeAttribute]
		private string version;

		[XmlAttributeAttribute]
		private string value;

		public DifferenceValue()
		{
		}

		public DifferenceValue(string version, string value)
		{
			this.version = version;
			this.value = value;
		}

		/// <summary>The messageset version this difference applies to .</summary>
		/// <remarks>The messageset version this difference applies to .</remarks>
		/// <returns>the version</returns>
		public virtual string Version
		{
			get
			{
				return this.version;
			}
			set
			{
				string version = value;
				this.version = version;
			}
		}

		/// <summary>The value that is different.</summary>
		/// <remarks>The value that is different.</remarks>
		/// <returns>the value</returns>
		public virtual string Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}
	}
}
