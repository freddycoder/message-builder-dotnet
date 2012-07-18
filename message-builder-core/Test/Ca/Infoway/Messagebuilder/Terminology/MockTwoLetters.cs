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
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Terminology
{
    [Serializable]
    public class MockTwoLetters : EnumPattern, MockCharacters
    {

        public static readonly MockTwoLetters CANADA = new MockTwoLetters("CANADA", "2.16.124");
        public static readonly MockTwoLetters HEALTH_CANADA = new MockTwoLetters("HEALTH_CANADA", "2.16.124.101.1.277");
        public static readonly MockTwoLetters PROVINCE_OF_ONTARIO = new MockTwoLetters("PROVINCE_OF_ONTARIO", "2.16.124.8");

        private readonly string _subcode;

        private const long serialVersionUID = -8250727697675835177L;

        private MockTwoLetters(string name, string subcode) : base(name)
        {
            _subcode = subcode;
        }

        static MockTwoLetters() { }

        public string CodeValue
        {
            get { return _subcode; }
        }

        public string CodeSystem
        {
            get { throw new NotImplementedException(); }
        }
    }
}
