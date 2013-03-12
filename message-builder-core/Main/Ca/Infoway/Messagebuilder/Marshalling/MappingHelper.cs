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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.J5goodies;
using System;

namespace Ca.Infoway.Messagebuilder.Marshalling
{

	public static class MappingHelper
	{
		
		public static Hl7MapByPartTypeAttribute[] GetAllHl7MapByPartType(BeanProperty property) {
			Hl7MapByPartTypeAttribute[] result = property.GetAnnotations<Hl7MapByPartTypeAttribute>();
			if (result.Length > 1) {
				Array.Sort(result);
			}
			return result;
		}
		
	}
	
}
