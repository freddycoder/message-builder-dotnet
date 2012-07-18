/**
 * Copyright 2012 Canada Health Infoway, Inc.
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

namespace Ca.Infoway.Messagebuilder.Annotation
{
	using System;
	
	[AttributeUsage(AttributeTargets.Method | 
	                AttributeTargets.Property | 
	                AttributeTargets.Interface,
	                AllowMultiple = true)]
	public class Hl7MapByPartTypeAttribute : Attribute, IComparable
	{
		private string name;
		private string type;
		
     	public string Name
     	{
			get
         	{
            		return this.name;
         	}
         	set
         	{
            		this.name = value;
         	}
		}
		
     	public string Type
     	{
			get
         	{
            		return this.type;
         	}
         	set
         	{
            		this.type = value;
         	}
		}
		
		public int CompareTo(object obj)
		{
			if (obj is Hl7MapByPartTypeAttribute) {
				int result = this.Name.CompareTo((obj as Hl7MapByPartTypeAttribute).Name);
				if (result == 0) {
					result = this.Type.CompareTo((obj as Hl7MapByPartTypeAttribute).Type);
				}
				return result;
			}
			throw new ArgumentException("Object is not an Hl7MapByPartType: " + obj.GetType());	
		}
	}
}
