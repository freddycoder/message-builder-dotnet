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
 * Last modified: $LastChangedDate: 2012-01-18 21:43:51 -0500 (Wed, 18 Jan 2012) $
 * Revision:      $LastChangedRevision: 4345 $
 */

using System;
using System.IO;
using System.Reflection;

namespace Ca.Infoway.Messagebuilder.Platform
{
	public class ResourceLoader
	{

		public static Stream GetResource(string path) {
			return GetResource(Assembly.GetExecutingAssembly(), path);
		}

		public static Stream GetResource(Type type, string path) {
			Assembly assembly = type!=null ? type.Assembly : Assembly.GetExecutingAssembly();
			String winPath = type!=null && !path.StartsWith("/") ? type.Namespace + "." + path : path;
			String unixPath = type!=null && !path.StartsWith("/") ? type.Namespace.ToLower() + "." + path : path;
			Stream resourceStream = GetResource(assembly, winPath);
			if (resourceStream == null) {
				resourceStream = GetResource(assembly, unixPath);
			}
			return resourceStream;	
		}
		
		public static Stream GetResource(Assembly assembly, string path) {
			Assembly targetAssembly = assembly != null ? assembly : Assembly.GetExecutingAssembly();
			string targetPath = path;
			if (targetPath.Contains("/")) {
				if (targetPath.StartsWith("/")) {
					targetPath = targetPath.Substring(1);
				}
				targetPath = targetPath!=null ? StringUtils.Replace(targetPath, "/", ".") : "";
			}

			string assemblyName = targetAssembly.GetName().Name.Replace("-","");

		    Stream stream = targetAssembly.GetManifestResourceStream(assemblyName + ".MainResource." + targetPath);

			if (stream==null || !stream.CanRead) {
				stream = targetAssembly.GetManifestResourceStream(assemblyName + ".TestResource." + targetPath);
				if (stream==null || !stream.CanRead) {
					stream = targetAssembly.GetManifestResourceStream("Ca.Infoway.Messagebuilder.TestResource." + targetPath);
					if (stream==null || !stream.CanRead) {
						stream = targetAssembly.GetManifestResourceStream(assemblyName + "." + targetPath);
					}
				}
			}
			
			return stream;
		}
		
	}
}

