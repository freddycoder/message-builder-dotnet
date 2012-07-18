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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ca.Infoway.Messagebuilder
{
    public static class WordUtils
    {
        public static String Capitalize(String s) {
			if (null == s) {
                return s;
			} else {
				bool first = true;
	            StringBuilder builder = new StringBuilder(s.Length);
				foreach (Char c in s) {
					if (first) {
	                    builder.Append(Char.ToUpper(c));
					} else {
						builder.Append(c);
					}
					first = false;
				}
				return builder.ToString();
			}
		}
        public static String Uncapitalize(String s) {
			if (null == s) {
                return s;
			} else {
				bool first = true;
	            StringBuilder builder = new StringBuilder(s.Length);
				foreach (Char c in s) {
					if (first) {
	                    builder.Append(Char.ToLower(c));
					} else {
						builder.Append(c);
					}
					first = false;
				}
				return builder.ToString();
			}
		}
        public static String CapitalizeFully(String s)
        {
            if (null == s)
                return s;

            StringBuilder res = new StringBuilder(s.Length);

            bool white = true;
            foreach (Char c in s)
            {
                if (Char.IsWhiteSpace(c))
                {
                    res.Append(c);
                    white = true;
                }
                else if (white)
                {
                    res.Append(Char.ToUpper(c));
                    white = false;
                }
                else
                    res.Append(Char.ToLower(c));
            }

            return res.ToString();
        }
    }
}
