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
using System.IO;
using System.Linq;
using System.Text;

namespace Ca.Infoway.Messagebuilder
{
    public static class IOUtils
    {
        public static void CloseQuietly(Stream stream)
        {
            try
            {
                if (null != stream)
                    stream.Close();
            }
            catch (Exception)
            {
            }
        }

        public static String ToString(Stream stream)
        {
            byte[] buf = new byte[stream.Length];
            stream.Read(buf, 0, (int) stream.Length);
            return Encoding.ASCII.GetString(buf);
        }

        public static IList<String> ReadLines(Stream stream)
        {
            if (null == stream)
                return null;

            String s = ToString(stream);

            String[] sarr = s.Split(new char[] { '\r', '\n' });

            System.Collections.Generic.IList<String> l = new System.Collections.Generic.List<String>(sarr.Length);

            for (int i = 0; i < sarr.Length; i++)
                l.Add(sarr[i]);

            return l;
        }

    }
}
