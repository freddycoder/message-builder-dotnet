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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling {
    
    public class CodedTypeR2Helper {

        public static bool IsCodedTypeR2(object value) {
            bool result = false;
            if (value != null) {
                Type codedTypeR2Type = typeof(CodedTypeR2<>);
                Type type = value.GetType();
                if (type.FullName.StartsWith(codedTypeR2Type.FullName)) {
                    result = true;
                }
            }
            return result;
        }

        public static string GetCodeValue(object codedTypeR2) {
            if (!IsCodedTypeR2(codedTypeR2)) {
                throw new ArgumentException("Object is not a CodedTypeR2 " + codedTypeR2);
            }
            var method = codedTypeR2.GetType().GetMethod("GetCodeValue");
            return (string) method.Invoke(codedTypeR2, null);
        }

        public static Code GetCode(object codedTypeR2) {
            if (!IsCodedTypeR2(codedTypeR2)) {
                throw new ArgumentException("Object is not a CodedTypeR2 " + codedTypeR2);
            }
            var property = codedTypeR2.GetType().GetProperty("Code");
            return (Code)property.GetValue(codedTypeR2, null);
        }

        public static object ConvertCodedTypeR2(CodedTypeR2<Code> source, Type parameterType) {
            if (source == null) {
                return null;
            }
            Type codedType = typeof(CodedTypeR2<>);
            Type baseCodeType = typeof(Code);
            Type genericType;
            if (!baseCodeType.IsAssignableFrom(parameterType)) {
                genericType = codedType.MakeGenericType(baseCodeType);
            } else {
                genericType = codedType.MakeGenericType(parameterType);
            }
            object result = Activator.CreateInstance(genericType);
            genericType.GetProperty("Code").SetValue(result, source.Code, null);
            genericType.GetProperty("CodeSystemName").SetValue(result, source.CodeSystemName, null);
            genericType.GetProperty("CodeSystemVersion").SetValue(result, source.CodeSystemVersion, null);
            genericType.GetProperty("DisplayName").SetValue(result, source.DisplayName, null);
            genericType.GetProperty("NullFlavorForTranslationOnly").SetValue(result, source.NullFlavorForTranslationOnly, null);
            genericType.GetProperty("OriginalText").SetValue(result, source.OriginalText, null);
            genericType.GetProperty("Qualifier").SetValue(result, source.Qualifier, null);
            genericType.GetProperty("Translation").SetValue(result, source.Translation, null);
            genericType.GetProperty("SimpleValue").SetValue(result, source.SimpleValue, null);
            genericType.GetProperty("Operator").SetValue(result, source.Operator, null);
            genericType.GetProperty("Value").SetValue(result, source.Value, null);
            genericType.GetProperty("ValidTime").SetValue(result, source.ValidTime, null);
            genericType.GetProperty("Qty").SetValue(result, source.Qty, null);
            return result;
        }

        public static CodedTypeR2<Code> ConvertCodedTypeR2(object source) {
            if (source == null) {
                return null;
            }
            CodedTypeR2<Code> result = new CodedTypeR2<Code>();
            Type sourceType = source.GetType();
            result.Code = (Code) sourceType.GetProperty("Code").GetValue(source, null);
            result.CodeSystemName = (string) sourceType.GetProperty("CodeSystemName").GetValue(source, null);
            result.CodeSystemVersion = (string) sourceType.GetProperty("CodeSystemVersion").GetValue(source, null);
            result.DisplayName = (string) sourceType.GetProperty("DisplayName").GetValue(source, null);
            result.NullFlavorForTranslationOnly = (NullFlavor) sourceType.GetProperty("NullFlavorForTranslationOnly").GetValue(source, null);
            result.OriginalText = (EncapsulatedData) sourceType.GetProperty("OriginalText").GetValue(source, null);
            result.Qualifier = (IList<CodeRole>) sourceType.GetProperty("Qualifier").GetValue(source, null);
            result.Translation = (IList<CodedTypeR2<Code>>) sourceType.GetProperty("Translation").GetValue(source, null);
            result.Operator = (SetOperator) sourceType.GetProperty("Operator").GetValue(source, null);
            result.SimpleValue = (string)sourceType.GetProperty("SimpleValue").GetValue(source, null);
            result.Value = (BigDecimal)sourceType.GetProperty("Value").GetValue(source, null);
            result.ValidTime = (Interval<PlatformDate>) sourceType.GetProperty("ValidTime").GetValue(source, null);
            result.Qty = (Int32?) sourceType.GetProperty("Qty").GetValue(source, null);
            return result;
        }

       	public static CollectionHelper CreateCDList(Type codeType) {
            return CreateList(typeof(CD_R2<>), typeof(CD_R2Impl<>), codeType);
	    }

        public static CollectionHelper CreateCSList(Type codeType) {
            return CreateList(typeof(CS_R2<>), typeof(CS_R2Impl<>), codeType);
	    }

        public static CollectionHelper CreateCEList(Type codeType) {
            return CreateList(typeof(CE_R2<>), typeof(CE_R2Impl<>), codeType);
	    }

        private static CollectionHelper CreateList(Type interfaceType, Type implType, Type codeType) {
            Type baseCodeType = typeof(Code);
            Type actualCodeType = !baseCodeType.IsAssignableFrom(codeType) ? baseCodeType : codeType;
            Type cdR2Type = interfaceType.MakeGenericType(actualCodeType);
            Type codedType = typeof(CodedTypeR2<>).MakeGenericType(actualCodeType);
            Type listType = typeof(LISTImpl<,>).MakeGenericType(cdR2Type, codedType);
            Type cdImplType = implType.MakeGenericType(actualCodeType);
            return (CollectionHelper)Activator.CreateInstance(listType, cdImplType);
        }

        public static BareANY CreateCEInstance(Type codeType) {
            return CreateR2Instance(typeof(CE_R2Impl<>), codeType);
        }

        private static BareANY CreateR2Instance(Type r2Type, Type codeType) {
            Type baseCodeType = typeof(Code);
            Type genericType;
            if (!baseCodeType.IsAssignableFrom(codeType)) {
                genericType = r2Type.MakeGenericType(baseCodeType);
            } else {
                genericType = r2Type.MakeGenericType(codeType);
            }
            return (BareANY)Activator.CreateInstance(genericType);
        }

        public static BareANY CreateCDInstance(Type codeType) {
            return CreateR2Instance(typeof(CD_R2Impl<>), codeType);
        }

        public static BareANY CreateCOInstance(Type codeType) {
            return CreateR2Instance(typeof(COImpl<>), codeType);
        }

        public static BareANY CreateCSInstance(Type codeType) {
            return CreateR2Instance(typeof(CS_R2Impl<>), codeType);
        }

        public static BareANY CreateCVInstance(Type codeType) {
            return CreateR2Instance(typeof(CV_R2Impl<>), codeType);
        }

        public static BareANY CreateHXITInstance(Type codeType) {
            return CreateR2Instance(typeof(HXITImpl<>), codeType);
        }

        public static BareANY CreatePQRInstance(Type codeType) {
            return CreateR2Instance(typeof(PQRImpl<>), codeType);
        }

        public static BareANY CreateSCInstance(Type codeType) {
            return CreateR2Instance(typeof(SC_R2Impl<>), codeType);
        }

        public static BareANY CreateBXITInstance(Type codeType) {
            return CreateCodedTypeR2Instance(typeof(BXITImpl<>), codeType);
        }

        public static BareANY CreateSXCMInstance(Type codeType) {
            return CreateCodedTypeR2Instance(typeof(SXCM_R2Impl<>), codeType); ;
        }

        private static BareANY CreateCodedTypeR2Instance(Type r2Type, Type codeType) {
            Type codedType = typeof(CodedTypeR2<>);
            Type baseCodeType = typeof(Code);
            Type codedTypeGenericType;
            if (!baseCodeType.IsAssignableFrom(codeType)) {
                codedTypeGenericType = codedType.MakeGenericType(baseCodeType);
            } else {
                codedTypeGenericType = codedType.MakeGenericType(codeType);
            }
            return (BareANY)Activator.CreateInstance(r2Type.MakeGenericType(codedTypeGenericType));
        }
    }

}
