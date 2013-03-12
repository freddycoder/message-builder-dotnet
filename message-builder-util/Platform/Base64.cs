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
 * Last modified: $LastChangedDate: 2013-03-01 17:48:17 -0500 (Fri, 01 Mar 2013) $
 * Revision:      $LastChangedRevision: 6663 $
 */

using System;
using System.Text;

namespace Ca.Infoway.Messagebuilder.Platform
{

    public class Base64
    {
        private Base64()
        {
        }

		public static byte[] EncodeBase64(byte[] base64Data) {
			return System.Text.ASCIIEncoding.ASCII.GetBytes(EncodeBase64String(base64Data));
		}
        public static String EncodeBase64String(byte[] base64Data)
        {
            return Convert.ToBase64String(base64Data);
        }

        public static byte[] DecodeBase64(byte[] base64Data)
        {
            var str = Encoding.ASCII.GetString(base64Data);
            return Convert.FromBase64String(str);

        }
        public static byte[] DecodeBase64String(String base64Data)
        {
            return Convert.FromBase64String(base64Data);

        }
    }
}
