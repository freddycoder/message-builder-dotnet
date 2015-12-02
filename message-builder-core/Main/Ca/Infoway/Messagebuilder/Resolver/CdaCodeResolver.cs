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
using System.IO;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Terminology.Proxy;
using Ca.Infoway.Messagebuilder.Xml.Cda.Vocabulary;
using Platform.SimpleXml;
using log4net;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	/// <summary>Knows how to provide Codes sourced from the Trifolia voc.xml file.</summary>
	/// <remarks>Knows how to provide Codes sourced from the Trifolia voc.xml file.</remarks>
	/// <author>Intelliware Development</author>
	public class CdaCodeResolver : CodeResolver
	{
        public static readonly string MODE_STRICT = "STRICT";
        public static readonly string MODE_LENIENT = "LENIENT";

        private class ValueSet
		{
			private readonly IDictionary<string, IList<CdaCodeResolver.CodedValue>> codes = new Dictionary<string, IList<CdaCodeResolver.CodedValue
				>>();

			private readonly IDictionary<string, IList<CdaCodeResolver.CodedValue>> codesByLowerCase = new Dictionary<string, IList<CdaCodeResolver.CodedValue
				>>();

			public virtual CdaCodeResolver.CodedValue GetCode(string code, bool ignoreCase)
			{
				IList<CdaCodeResolver.CodedValue> codes = ignoreCase ? this.codesByLowerCase.SafeGet(code.ToLower()) : this.
					codes.SafeGet(code);
				if (codes != null && codes.Count >= 1)
				{
					return codes[0];
				}
				return null;
			}

			public virtual CdaCodeResolver.CodedValue GetCode(string code, string codeSystemOid, bool ignoreCase)
			{
				IList<CdaCodeResolver.CodedValue> codes = ignoreCase ? this.codesByLowerCase.SafeGet(code.ToLower()) : this.
					codes.SafeGet(code);
				if (codes != null)
				{
					foreach (CdaCodeResolver.CodedValue codedValue in codes)
					{
						// not applying ignoreCase to codeSystem check
						if (StringUtils.Equals(codeSystemOid, codedValue.GetCodeSystemOid()))
						{
							return codedValue;
						}
					}
				}
				return null;
			}

			public virtual IList<CdaCodeResolver.CodedValue> GetAllCodes()
			{
				IList<CdaCodeResolver.CodedValue> allValues = new List<CdaCodeResolver.CodedValue>();
				foreach (IList<CdaCodeResolver.CodedValue> list in this.codes.Values)
				{
					allValues.AddAll(list);
				}
				return allValues;
			}

			public virtual void AddCode(CdaCodeResolver.CodedValue code)
			{
				if (code != null && code.GetValue() != null)
				{
					IList<CdaCodeResolver.CodedValue> list = this.codes.SafeGet(code.GetValue());
					if (list == null)
					{
						list = new List<CdaCodeResolver.CodedValue>();
						this.codes[code.GetValue()] = list;
						this.codesByLowerCase[code.GetValue().ToLower()] = list;
					}
					list.Add(code);
				}
			}
		}

		private class CodedValue
		{
			private readonly string value;

			private readonly string codeSystemOid;

			private readonly string codeSystemName;

			private readonly string displayName;

			public CodedValue(string value, string codeSystemOid, string codeSystemName, string displayName)
			{
				this.value = value;
				this.codeSystemOid = codeSystemOid;
				this.codeSystemName = codeSystemName;
				this.displayName = displayName;
			}

			public virtual string GetValue()
			{
				return value;
			}

			public virtual string GetCodeSystemOid()
			{
				return codeSystemOid;
			}

			public virtual string GetCodeSystemName()
			{
				return codeSystemName;
			}

			public virtual string GetDisplayName()
			{
				return displayName;
			}
		}

		private readonly ILog log = log4net.LogManager.GetLogger(typeof(CdaCodeResolver));

        //There is no equivalent of AnnotationStrategy in the .NET port of simple xml framework.
        //However, it appears that we are not using the Convert annotation in message-builder-core in the Java code.
        //It should be okay to use the default persister implemented in .NET
		//private Serializer serializer = new Persister(new AnnotationStrategy());
        private Serializer serializer = new Persister();

		private readonly TypedCodeFactory codeFactory;

		private readonly IDictionary<string, CdaCodeResolver.ValueSet> valueSetsByTypeName = new Dictionary<string, CdaCodeResolver.ValueSet
			>();

        private TrivialCodeResolver fallbackResolver;

        /// <summary>Create and initialize the code resolver.</summary>
        /// <remarks>Create and initialize the code resolver.</remarks>
        /// <param name="codeFactory">the code factory.</param>
        /// <param name="vocabularyDefinitionsFile">an input stream containing a list of known value sets and the codes that each contains.</param>
        /// <param name="valueSetNameMappingFile">an input stream containing the mapping from value set OIDs to interface names.</param>
        public CdaCodeResolver(TypedCodeFactory codeFactory, Stream vocabularyDefinitionsFile, Stream valueSetNameMappingFile)
        {
            this.codeFactory = codeFactory;
            this.Initialize(vocabularyDefinitionsFile, valueSetNameMappingFile, MODE_STRICT);
        }

        /// <summary>Create and initialize the code resolver.</summary>
        /// <remarks>Create and initialize the code resolver.</remarks>
        /// <param name="codeFactory">the code factory.</param>
        /// <param name="vocabularyDefinitionsFile">an input stream containing a list of known value sets and the codes that each contains.</param>
        /// <param name="valueSetNameMappingFile">an input stream containing the mapping from value set OIDs to interface names.</param>
        /// <param name="mode">indicates whether the resolver should return null for unexpected vocabulary domains (MODE_STRICT) or return a proxy code object (MODE_LENIENT)</param>
        public CdaCodeResolver(TypedCodeFactory codeFactory, Stream vocabularyDefinitionsFile, Stream valueSetNameMappingFile, String mode)
		{
            this.codeFactory = codeFactory;
            this.Initialize(vocabularyDefinitionsFile, valueSetNameMappingFile, mode);
        }

        private void Initialize(Stream vocabularyDefinitionsFile, Stream valueSetNameMappingFile, String mode)
        {
            try
            {
                ValueSetDefinition valueSetDefinition = (ValueSetDefinition)serializer.Read(typeof(ValueSetDefinition), vocabularyDefinitionsFile
                    );
                ValueSetDefinition valueSetMapping = (ValueSetDefinition)serializer.Read(typeof(ValueSetDefinition), valueSetNameMappingFile
                    );
                IDictionary<string, string> valueSetMap = new Dictionary<string, string>();
                foreach (ValueSetDefinitionSystem mapping in valueSetMapping.Systems)
                {
                    if (StringUtils.IsNotBlank(mapping.ValueSetOid))
                    {
                        valueSetMap[mapping.ValueSetOid] = mapping.ValueSetName;
                    }
                }
                foreach (ValueSetDefinitionSystem system in valueSetDefinition.Systems)
                {
                    if (StringUtils.IsNotBlank(system.ValueSetOid))
                    {
                        CdaCodeResolver.ValueSet valueSet = new CdaCodeResolver.ValueSet();
                        string valueSetName = valueSetMap.SafeGet(system.ValueSetOid);
                        if (valueSetName == null)
                        {
                            valueSetName = system.ValueSetName;
                        }
                        valueSetsByTypeName[valueSetName] = valueSet;
                        foreach (Ca.Infoway.Messagebuilder.Xml.Cda.Vocabulary.Code code in system.Codes)
                        {
                            valueSet.AddCode(new CdaCodeResolver.CodedValue(code.Value, code.CodeSystem, code.CodeSystemName, code.DisplayName));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("Unable to initialize resolver", e);
            }

            if (MODE_LENIENT.Equals(mode))
            {
                fallbackResolver = new TrivialCodeResolver();
            }
        }

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual ICollection<T> Lookup<T>(Type type) where T : Code
		{
			ICollection<T> result = new List<T>();
			CdaCodeResolver.ValueSet valueSet = valueSetsByTypeName.SafeGet(type.Name);
			if (valueSet != null)
			{
				foreach (CdaCodeResolver.CodedValue value in valueSet.GetAllCodes())
				{
					result.Add(CreateCode<T>(type, value));
				}
			}
			return result;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual T Lookup<T>(Type type, string code) where T : Code
		{
			return Lookup<T>(type, code, true);
		}

		public virtual T Lookup<T>(Type type, string code, bool ignoreCase) where T : Code
		{
			CdaCodeResolver.ValueSet valueSet = valueSetsByTypeName.SafeGet(type.Name);
			if (valueSet != null)
			{
				CdaCodeResolver.CodedValue codedValue = valueSet.GetCode(code, ignoreCase);
				if (codedValue != null)
				{
					return CreateCode<T>(type, codedValue);
				}
			}
			return default(T);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual T Lookup<T>(Type type, string code, string codeSystemOid) where T : Code
		{
			return Lookup<T>(type, code, codeSystemOid, true);
		}

		public virtual T Lookup<T>(Type type, string code, string codeSystemOid, bool ignoreCase) where T : Code
		{
			CdaCodeResolver.ValueSet valueSet = valueSetsByTypeName.SafeGet(type.Name);
            if (valueSet != null)
            {
                CdaCodeResolver.CodedValue codedValue = valueSet.GetCode(code, codeSystemOid, ignoreCase);
                if (codedValue != null)
                {
                    return CreateCode<T>(type, codedValue);
                }
            }
            else if (fallbackResolver != null)
            {
                return fallbackResolver.Lookup<T>(type, code, codeSystemOid, ignoreCase);
            }

            return default(T);
		}

		private T CreateCode<T>(Type type, CdaCodeResolver.CodedValue value) where T : Code
		{
			ICollection<Type> implementedTypes = new HashSet<Type>();
			implementedTypes.Add(type);
			Dictionary<string, string> displayTextMap = new Dictionary<string, string>();
			displayTextMap["en"] = value.GetDisplayName();
			return type.Cast<T>(this.codeFactory.Create(type, implementedTypes, value.GetValue(), value.GetCodeSystemOid(), 
                value.GetCodeSystemName(), displayTextMap, 1, true, true));
		}
	}
}
