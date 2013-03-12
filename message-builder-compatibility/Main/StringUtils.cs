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
 * Last modified: $LastChangedDate: 2011-10-13 11:51:35 -0400 (Thu, 13 Oct 2011) $
 * Revision:      $LastChangedRevision: 3059 $
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ca.Infoway.Messagebuilder
{
    public static class StringUtils
    {
        private const int PAD_LIMIT = 8192;
		
		public const string EMPTY = "";

        public static bool Equals(String a, String b)
        {
            return null == a ? null == b : a.Equals(b);
        }

        public static int Length(String str)
        {
            return str==null ? 0 : str.Length;
        }
		
        public static bool IsBlank(String a)
        {
            if (String.IsNullOrEmpty(a))
                return true;

            foreach (char c in a)
                if (!Char.IsWhiteSpace(c))
                    return false;

            return true;
        }

        public static bool IsNotBlank(String a)
        {
            return !IsBlank(a);
        }

        public static bool IsEmpty(String a)
        {
            return String.IsNullOrEmpty(a);
        }

        public static bool IsNotEmpty(String a)
        {
            return !IsEmpty(a);
        }

        public static bool IsNumeric(String s)
        {
            if (null == s)
                return false;

            foreach (Char c in s)
                if (-1 == "0123456789".IndexOf(c))
                    return false;

            return true;
        }

        public static String Remove(String s, char x)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            StringBuilder sb = new StringBuilder(s.Length);
            foreach (char c in s)
                if (x != c)
                    sb.Append(c);

            return sb.ToString();
        }
        public static String RemoveStart(String s, String remove)
        {
            if (String.IsNullOrEmpty(s))
                return s;
			if (s.StartsWith(remove)) {
				return Substring(s, remove.Length);
			} else {
				return s;
			}
        }


        public static String Substring(String s, int a)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            if (0 > a)
                a += s.Length;
            if (0 >= a)
                return s;
            if (a >= s.Length)
                return String.Empty;

            return s.Substring(a);
        }

        public static String Substring(String s, int a, Int32? z) {
			if (z.HasValue) {
				return Substring(s, a, z.Value);
			} else {
				return Substring(s, a);
			}
		}
		
        public static String Substring(String s, int a, int z)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            if (0 > a)
                a += s.Length;
            if (0 > z)
                z += s.Length;

            if (a >= s.Length || 0 >= z || a >= z)
                return String.Empty;

            if (0 > a)
                a = 0;

            if (z >= s.Length)
                return s.Substring(a);

            return s.Substring(a, z - a);
        }

        public static String SubstringAfter(String a, String s)
        {
            if (null == s)
                return String.Empty;

            if (null == a || 0 == a.Length || 0 == s.Length)
                return a;

            int n = a.IndexOf(s);
            if (-1 < n)
                return a.Substring(n + s.Length);

            return String.Empty;
        }

        public static String SubstringBefore(String a, String s)
        {
            if (null == a || 0 == a.Length || null == s)
                return a;

            if (0 == s.Length)
                return String.Empty;

            int n = a.IndexOf(s);
            if (-1 < n)
                return a.Substring(0, n);

            return a;
        }

        public static String SubstringBeforeLast(String a, String s)
        {
            if (null == a || 0 == a.Length || null == s || 0 == s.Length)
                return a;

            int n = a.LastIndexOf(s);
            if (-1 < n)
                return a.Substring(0, n);

            return a;
        }

        public static String Trim(String a)
        {
            return null == a ? a : a.Trim();
        }

        public static String TrimToEmpty(String a)
        {
            return null == a ? String.Empty : a.Trim();
        }

        public static String TrimToNull(String a)
        {
            if (null == a)
                return a;

            String r = a.Trim();

            return 0 == a.Length ? null : r;
        }

        public static String replace(String a,String s, String r)
        {
            if (null == a)
                return null;

            return a.Replace(s, r);
        }

        public static String[] Split(String a)
        {
            if (null == a)
                return null;

            return Regex.Split(a, @"\W+");
        }

        public static String[] Split(String a, String separator)
        {
            if (null == a || null == separator)
                return null;

            return a.Split(separator.ToCharArray());
        }

        public static String RightPad(String str, int size)
        {
            return RightPad(str, size, ' ');
        }

        public static String RightPad(String str, int size, char padChar)
        {
            if (str == null)
            {
                return null;
            }

            int pads = size - str.Length;
            if (pads <= 0)
            {
                return str; // returns original String when possible
            }
            if (pads > PAD_LIMIT)
            {
                return RightPad(str, size, padChar.ToString());
            }
            return str + Padding(pads, padChar);
        }
        
        public static String RightPad(String str, int size, String padStr)
        {
            if (str == null)
            {
                return null;
            }
            if (IsEmpty(padStr))
            {
                padStr = " ";
            }
            int padLen = padStr.Length;
            int strLen = str.Length;
            int pads = size - strLen;
            if (pads <= 0)
            {
                return str; // returns original String when possible
            }
            if (padLen == 1 && pads <= PAD_LIMIT)
            {
                return RightPad(str, size, padStr[0]);
            }

            if (pads == padLen)
            {
                return str + padStr;
            }
            else if (pads < padLen)
            {
                return str + padStr.Substring(0, pads);
            }
            else
            {
                char[] padding = new char[pads];
                char[] padChars = padStr.ToCharArray();
                for (int i = 0; i < pads; i++)
                {
                    padding[i] = padChars[i % padLen];
                }
                return str + new String(padding);
            }
        }

        private static String Padding(int repeat, char padChar)
        {
            if (repeat < 0) {
                throw new IndexOutOfRangeException("Cannot pad a negative amount: " + repeat);
            }
            
            char[] buf = new char[repeat];
            for (int i = 0; i < buf.Length; i++) {
                buf[i] = padChar;
            }
            
            return new String(buf);
        }

        public static String LeftPad(String str, int size)
        {
            return LeftPad(str, size, ' ');
        }

        public static String LeftPad(String str, int size, char padChar)
        {
            if (str == null)
            {
                return null;
            }
            int pads = size - str.Length;
            if (pads <= 0)
            {
                return str; // returns original String when possible
            }
            if (pads > PAD_LIMIT)
            {
                return LeftPad(str, size, padChar.ToString());
            }
            return Padding(pads, padChar) + str;
        }

        public static String LeftPad(String str, int size, String padStr)
        {
            if (str == null)
            {
                return null;
            }
            if (IsEmpty(padStr))
            {
                padStr = " ";
            }
            int padLen = padStr.Length;
            int strLen = str.Length;
            int pads = size - strLen;
            if (pads <= 0)
            {
                return str; // returns original String when possible
            }
            if (padLen == 1 && pads <= PAD_LIMIT)
            {
                return LeftPad(str, size, padStr[0]);
            }

            if (pads == padLen)
            {
                return padStr + str;
            }
            else if (pads < padLen)
            {
                return padStr.Substring(0, pads) + str;
            }
            else
            {
                char[] padding = new char[pads];
                char[] padChars = padStr.ToCharArray();
                for (int i = 0; i < pads; i++)
                {
                    padding[i] = padChars[i % padLen];
                }

                return new String(padding) + str;
            }
        }

        public static String Repeat(String str, int repeat)
        {
            // Performance tuned for 2.0 (JDK1.4)

            if (str == null)
            {
                return null;
            }
            if (repeat <= 0)
            {
                return "";
            }
            int inputLength = str.Length;
            if (repeat == 1 || inputLength == 0)
            {
                return str;
            }
            if (inputLength == 1 && repeat <= PAD_LIMIT)
            {
                return Padding(repeat, str[0]);
            }

            int outputLength = inputLength * repeat;
            switch (inputLength)
            {
                case 1:
                    char ch = str[0];
                    char[] output1 = new char[outputLength];
                    for (int i = repeat - 1; i >= 0; i--)
                    {
                        output1[i] = ch;
                    }
                    return new String(output1);
                case 2:
                    char ch0 = str[0];
                    char ch1 = str[1];
                    char[] output2 = new char[outputLength];
                    for (int i = repeat * 2 - 2; i >= 0; i--, i--)
                    {
                        output2[i] = ch0;
                        output2[i + 1] = ch1;
                    }
                    return new String(output2);
                default:

                    StringBuilder buf = new StringBuilder(outputLength);
                    for (int i = 0; i < repeat; i++)
                    {
                        buf.Append(str);
                    }
                    return buf.ToString();
            }
        }

        public static String Replace(String text, String searchString, String replacement)
        {
            return text.Replace(searchString, replacement);
        }

        public static String Left(String str, int? len) {
			if (len.HasValue) {
				return Left(str, len.Value);
			} else {
				return Left(str, 0);
			}
		}
		
        public static String Left(String str, int len)
        {
            if (str == null)
            {
                return null;
            }
            if (len < 0)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(0, len);
        }
		
		public static String Join(IEnumerable<string> str, string sep) {
			string separator = "";
			StringBuilder builder = new StringBuilder();
			foreach (string s in str) {
				builder.Append(separator);
				builder.Append(s);
				separator = sep;
			}
			return builder.ToString();
		}

		
		
        public static String SubstringAfterLast(String str, String separator)
        {
            if (IsEmpty(str))
            {
                return str;
            }
            if (IsEmpty(separator))
            {
                return "";
            }
            int pos = str.LastIndexOf(separator);
            if (pos == -1 || pos == (str.Length - separator.Length))
            {
                return "";
            }
            return str.Substring(pos + separator.Length);
        }
		
		public static String DeleteWhitespace(String str)
		{
	        if (IsEmpty(str)) {
	            return str;
	        }
	        int sz = str.Length;
	        char[] chs = new char[sz];
	        int count = 0;
	        for (int i = 0; i < sz; i++) {
	            if (!Char.IsWhiteSpace(str.ElementAt(i))) {
	                chs[count++] = str.ElementAt(i);
	            }
	        }
	        if (count == sz) {
	            return str;
	        }
	        return new String(chs, 0, count);			
		}
			
		
    }
}
