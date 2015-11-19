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
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Util;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;

namespace Ca.Infoway.Messagebuilder.CodeRegistry {

    public class CodeTypeRegistry : CodeTypeHandler {

        private static CodeTypeRegistry instance;
        private Dictionary<MessageTypeKey, Type> codeTypeRegistry = new Dictionary<MessageTypeKey, Type>();

        public Type GetCodeType(string domainType, string version) {
            var key = new MessageTypeKey(version, domainType);
            return codeTypeRegistry.ContainsKey(key) ? codeTypeRegistry[key] : null;
        }

        public static CodeTypeRegistry GetInstance() {
            if (instance == null) {
                InitializeInstance();
            }
            return instance;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void InitializeInstance() {
            CodeTypeRegistry registry = new CodeTypeRegistry();
            registry.Initialize();
            instance = registry;
        }

        private void Initialize() {
            var candidates = new ManifestLocater().GetAssembliesWithVersionAttribute(typeof(MbtModelVersionNumberAttribute));

            foreach (var item in candidates) {
                var classes = FindClasses(item.Key);

                RegisterClasses(classes, item.Value);
            }
        }

        private void RegisterClasses(List<Type> classes, string[] versions) {
            foreach (var type in classes) {
                RegisterClass(type, versions);
            }
        }

        private void RegisterClass(Type type, String[] versions) {
            string domainType = type.Name;
            foreach (var version in versions) {
                var key = new MessageTypeKey(version, domainType);
                //Workaround for the fact that we do not have a separate DLL for test classes
                if (!codeTypeRegistry.ContainsKey(key)) {
                    codeTypeRegistry.Add(key, type);
                }
            }
        }			

        private static List<Type> FindClasses(Assembly assembly)
        {
            var selectedTypes = new List<Type>();

            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (typeof(Code).IsAssignableFrom(type))
                {
                    selectedTypes.Add(type);
                }
            }

            return selectedTypes;
        }

    }
}