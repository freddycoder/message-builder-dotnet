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
using System.Reflection;
using Ca.Infoway.Messagebuilder.Annotation;

namespace Ca.Infoway.Messagebuilder.Xml.Service
{
    class ManifestMessageDefinitionService : BaseMessageDefinitionService
    {
        protected override IList<ResourcePair> Names
        {
            get { return getResourceNamesFromManifests(); }
        }

        private List<ResourcePair> getResourceNamesFromManifests()
        {
            var manifests = new List<ResourcePair>();
            foreach (var executingAssembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                string simpleAssemblyname = executingAssembly.GetName().Name;
                if (simpleAssemblyname.StartsWith("message-builder-"))
                {
                    addAssemblyToManifests(manifests, executingAssembly);
                }

                //.NET loads assemblies dynamically as they are needed so we need to load all referenced assemblies manually
                foreach (var assemblyName in executingAssembly.GetReferencedAssemblies())
                {
				
				    if (assemblyName.Name.StartsWith("message-builder-"))
				    {
                        Assembly assembly = Assembly.Load(assemblyName);
                        addAssemblyToManifests(manifests, assembly);
				    }
                }

            }


            return manifests;
        }

        private static void addAssemblyToManifests(List<ResourcePair> manifests, Assembly assembly)
        {
            var attr = GetAssemblyAttribute(assembly);

            List<string> resourceNames = new List<string>();
            foreach(var item in manifests)
            {
                resourceNames.Add(item.Name);
            }

            if (attr != null)
            {
                string[] collection = attr.value.Split(' ');

                foreach (var s in collection)
                {
                    if (!resourceNames.Contains(s))
                    {
                        manifests.Add(new ResourcePair(s, assembly));
                    }
                }

            }
        }

        private static MbtMessageSetAttribute GetAssemblyAttribute(Assembly assembly)
        {
            var assemblyAttributes = assembly.GetCustomAttributes(typeof(MbtMessageSetAttribute), true);

            MbtMessageSetAttribute attr = null;

            if (assemblyAttributes.Length > 0)
            {
                attr = assemblyAttributes[0] as MbtMessageSetAttribute;
            }

            return attr;
        }
    }

    public class ResourcePair
    {
        public ResourcePair(string s, Assembly assembly)
        {
            Name = s;
            Assembly = assembly;
        }

        public string Name { get; set; }

        public Assembly Assembly { get; set; }
    }
}
