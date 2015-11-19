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
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang.Util
{
	[System.Serializable]
	public class IntegrityCheckAlgorithm : EnumPattern
	{
		private const long serialVersionUID = 1L;

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.IntegrityCheckAlgorithm SHA_1 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.IntegrityCheckAlgorithm
			("SHA_1");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.IntegrityCheckAlgorithm SHA_256 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.IntegrityCheckAlgorithm
			("SHA_256");

		private IntegrityCheckAlgorithm(string name) : base(name)
		{
		}
	}
}