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
 * Last modified: $LastChangedDate: 2012-01-03 16:19:27 -0500 (Tue, 03 Jan 2012) $
 * Revision:      $LastChangedRevision: 3187 $
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Util;
using System.Runtime.CompilerServices;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
    public class MessageBeanRegistry
    {
        private static MessageBeanRegistry instance;

        private Dictionary<MessageTypeKey, Type> registry = new Dictionary<MessageTypeKey, Type>();
        private Dictionary<MessageTypeKey, Type> partTypeRegistry = new Dictionary<MessageTypeKey, Type>();

        public static MessageBeanRegistry GetInstance()
        {
            if (instance == null)
            {
                InitializeInstance();
            }

            return instance;
        }

        private Type GetMessagePartType(MessageTypeKey key)
        {
            return partTypeRegistry.ContainsKey(key) ? partTypeRegistry[key] : null;
        }

        public Dictionary<MessageTypeKey, Type>.ValueCollection GetAllMessageParts()
        {
            return partTypeRegistry.Values;
        }

        public Dictionary<MessageTypeKey, Type>.KeyCollection GetMessageTypeKeys()
        {
            return registry.Keys;
        }

        public Type GetInteractionBeanType(MessageTypeKey key)
        {
            Type value;

            registry.TryGetValue(key, out value);

            return value;

        }

        public MessageTypeKey GetMessageTypeKey(VersionNumber version, IInteraction messageBean)
        {
            if (messageBean != null && IsAnnotationPresent(messageBean.GetType(), typeof(Hl7PartTypeMappingAttribute)))
            {
                return GetTypeFromPartTypeMapping(version, messageBean);
            }

            throw new MarshallingException("Cannot find a type for " + (messageBean == null ? "" : messageBean.GetType().ToString()));
        }

        public Type GetMessagePartClass(VersionNumber version, String type)
        {
            MessageTypeKey key = new MessageTypeKey(version, type);

            var result = GetMessagePartType(key);
            if (result == null && type.Contains("."))
            {
                String unqualifiedTypeName = StringUtils.SubstringAfter(type, ".");
                key = new MessageTypeKey(version, unqualifiedTypeName);
                result = GetMessagePartType(key);

                if (result == null && unqualifiedTypeName.Contains("_"))
                {
                    String typeWithoutVersionCode = StringUtils.SubstringBefore(type, ".")
                        + "." + StringUtils.SubstringBefore(unqualifiedTypeName, "_");
                    result = GetMessagePartClass(version, typeWithoutVersionCode);
                }
            }
            return result;
        }

        public Boolean IsMessagePartDefined(VersionNumber version, String type)
        {
            return GetMessagePartClass(version, type) != null;
        }

        private MessageTypeKey GetTypeFromPartTypeMapping(VersionNumber version, IInteraction messageBean)
        {
            var mapping = GetClassAttributes(messageBean.GetType(), typeof(Hl7PartTypeMappingAttribute));

            if (mapping != null && mapping.Value.Length > 0 && StringUtils.IsNotBlank(mapping.Value[0]))
            {

                return new MessageTypeKey(version, mapping.Value[0]);

            }

            throw new MarshallingException("Cannot find a type for " + messageBean.GetType());
        }

        private static bool IsAnnotationPresent(Type type, Type attributeType)
        {
            var classAttributes = type.GetCustomAttributes(attributeType, false);

            return classAttributes.Length > 0;
        }

		[MethodImpl(MethodImplOptions.Synchronized)]
        private static void InitializeInstance()
        {
            if (instance == null)
            {
                var registry = new MessageBeanRegistry();
                registry.Initialize();
                instance = registry;
            }
        }

        private void Initialize()
        {
            var candidates = new ManifestLocater().GetAssembliesWithVersionAttribute(typeof(MbtModelVersionNumberAttribute));

            foreach (var item in candidates)
            {
                var classes = FindClasses(item.Key);

                RegisterClasses(classes, item.Value);
            }
        }

        private void RegisterClasses(List<Type> classes, string[] versions)
        {
            foreach (var type in classes)
            {
				RegisterClass(type, versions);
            }
        }

		public void RegisterClass(Type type, VersionNumber version) {
			RegisterClass(type, new String[] { version.VersionLiteral });
		}
		
		private void RegisterClass(Type type, String[] versions) {
            var mapping = GetClassAttributes(type, typeof(Hl7PartTypeMappingAttribute));

            foreach (var partId in mapping.Value)
            {
                foreach (var version in versions)
                {
                    var key = new MessageTypeKey(version, partId);

                    if (partTypeRegistry.ContainsKey(key))
                    {
                        continue; // or shall will let it fail ?
                    }

                    partTypeRegistry.Add(key, type);

                    if (typeof(IInteraction).IsAssignableFrom(type))
                    {
                        registry.Add(key, type);
                    }
                }

            }
		}			

        private static List<Type> FindClasses(Assembly assembly)
        {
            var selectedTypes = new List<Type>();

            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var attr = GetClassAttributes(type, typeof(Hl7PartTypeMappingAttribute));

                if (attr != null)
                {
                    selectedTypes.Add(type);
                }
            }

            return selectedTypes;
        }

        private static Hl7PartTypeMappingAttribute GetClassAttributes(Type type, Type attributeType)
        {
            var classAttributes = type.GetCustomAttributes(attributeType, false);

            Hl7PartTypeMappingAttribute attr = null;

            if (classAttributes.Length > 0)
            {
                attr = classAttributes[0] as Hl7PartTypeMappingAttribute;
            }

            return attr;
        }
    }
}
