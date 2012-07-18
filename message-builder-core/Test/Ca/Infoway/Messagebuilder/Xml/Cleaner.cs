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

using System.IO;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class Cleaner
	{
		/// <exception cref="System.Exception"></exception>
		public static void Main(string[] args)
		{
			//		File file = new File("../message-builder-release-v02_r02/src/main/resources/messageSet_v02_r02.xml");
			//		File file = new File("../message-builder-release-v01_r04_3/src/main/resources/messageSet_v01r04_3.xml");
			//		File file = new File("../message-builder-release-newfoundland/src/main/resources/messageSet_NEWFOUNDLAND.xml");
			//		File file = new File("../message-builder-release-r02_04_02/src/main/resources/messageSet_r02_04_02.xml");
			FileInfo file = new FileInfo("../message-builder-xml-validation/src/test/resources/ca/infoway/messagebuilder/xml/validator/messageSet_v02r02.xml"
				);
			MessageSetMarshaller marshaller = new MessageSetMarshaller();
			MessageSet messageSet = marshaller.Unmarshall(file);
			marshaller.Marshall(messageSet, file);
		}
	}
}
