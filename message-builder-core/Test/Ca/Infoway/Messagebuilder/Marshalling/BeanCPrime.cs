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
using Ca.Infoway.Messagebuilder.Annotation;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("ABCD_IN123456CA.BeanC")]
	public class BeanCPrime
	{
		private Ca.Infoway.Messagebuilder.Marshalling.BeanB beanB;

		[Hl7XmlMappingAttribute("component2/textHolder")]
		public virtual Ca.Infoway.Messagebuilder.Marshalling.BeanB BeanB
		{
			get
			{
				return this.beanB;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Marshalling.BeanB beanB = value;
				this.beanB = beanB;
			}
		}
	}
}
