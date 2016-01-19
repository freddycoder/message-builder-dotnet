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
namespace Ca.Infoway.Messagebuilder.Platform
{
	public class UUID
	{
		private Guid guid;
		
		public UUID() {
		    guid = Guid.NewGuid();
		}

        private UUID(Guid guid)
        {
            this.guid = guid;
        }
		
		public static UUID RandomUUID() {
			return new UUID();
		}
		
		public static UUID FromString(string uuid) {
			return new UUID(new Guid(uuid));
		}
		
		public override string ToString() {
            return guid.ToString();
		}

        public override bool Equals(object obj)
        {
            var cast = obj as UUID;

            return cast!=null && guid.Equals(cast.guid);
        }
	}
}

