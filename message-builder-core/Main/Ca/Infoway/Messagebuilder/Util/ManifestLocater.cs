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


namespace Ca.Infoway.Messagebuilder.Util {
    using Ca.Infoway.Messagebuilder.Annotation;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class ManifestLocater {
        public Dictionary<Assembly, string[]> GetAssembliesWithVersionAttribute(Type attributeType) {
            var candidates = new Dictionary<Assembly, string[]>();
            var candidateSet = new HashSet<string>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                string simpleAssemblyName = assembly.GetName().Name;

                if (simpleAssemblyName.StartsWith("message-builder-")) {
                    var attr = GetAssemblyAttribute(assembly, attributeType);
                    if (attr != null && !candidateSet.Contains(simpleAssemblyName))
                    {
                        candidates.Add(assembly, attr.value.Split(' '));
                        candidateSet.Add(simpleAssemblyName);
                    }
                }

                foreach(var referenceAssemblyName in assembly.GetReferencedAssemblies())
                {
                    if (referenceAssemblyName.Name.StartsWith("message-builder-"))
                    {
                        var referencedAssembly = Assembly.Load(referenceAssemblyName);
                        var attr = GetAssemblyAttribute(referencedAssembly, attributeType);
                        if (attr != null && !candidateSet.Contains(referenceAssemblyName.Name))
                        {
                            candidates.Add(referencedAssembly, attr.value.Split(' '));
                            candidateSet.Add(referenceAssemblyName.Name);
                        }
                    }
                }
            }

            return candidates;
        }



        private MbtModelVersionNumberAttribute GetAssemblyAttribute(Assembly assembly, Type attributeType) {
            var assemblyAttributes = assembly.GetCustomAttributes(attributeType, true);

            MbtModelVersionNumberAttribute attr = null;

            if (assemblyAttributes.Length > 0) {
                attr = assemblyAttributes[0] as MbtModelVersionNumberAttribute;
            }

            return attr;
        }
    }
}