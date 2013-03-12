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
using System.Collections.Generic;
using System.IO;

namespace Ca.Infoway.Messagebuilder.Platform
{


	public class FileUtil
	{

		public static IList<FileInfo> GetFilesInDirectoryBySuffix(string directory, String extension) {
			DirectoryInfo folder = new DirectoryInfo(directory);
			IList<FileInfo> matchingFiles = new List<FileInfo>();
			foreach (FileInfo file in folder.GetFiles()) {
				if (file.Name.EndsWith(extension)) { 
					matchingFiles.Add(file);
				}
			}
			return matchingFiles;
		}
	}
}
