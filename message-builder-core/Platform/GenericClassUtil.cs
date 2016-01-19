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
using System.Text;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;

namespace Ca.Infoway.Messagebuilder {

	public class GenericClassUtil {

        private GenericClassUtil() {}

        public static bool IsInstanceOfANY(object value) {
            if (value != null) {
                Type anyType = typeof(ANY<>);
                foreach (Type interfaceType in value.GetType().GetInterfaces()) {
                    if (interfaceType.FullName.StartsWith(anyType.FullName)) {
                        return true;
                    }
                }
            }
            return false;
        }

        public static object GetValueFromANY(object anyObject) {
            if (!IsInstanceOfANY(anyObject)) {
                throw new ArgumentException("Object is not an instance of ANY " + anyObject);
            }
            var property = anyObject.GetType().GetProperty("Value");
            return property.GetValue(anyObject, null);
        }

        public static ICollection<BareANY> ConvertToBareANYCollection(BareANY hl7Value) {
            object bareValue = (hl7Value == null ? null : hl7Value.BareValue);
            if (bareValue is IEnumerable<BareANY>) {
                IEnumerable<BareANY> oldCollection = (IEnumerable<BareANY>)bareValue;
                ICollection<BareANY> newCollection = new List<BareANY>();
                newCollection.AddAll(oldCollection);
                return newCollection;
            }
            return null;
        }

        public static Interval<PlatformDate> CastBareValueAsIntervalDate(object bareValue) {
            return bareValue is Interval<PlatformDate> ? (Interval<PlatformDate>)bareValue : null;
        }

        public static CollectionHelper CreateSXCMR2List() {
            Type implType = typeof(SXCM_R2Impl<MbDate>);
		    return new LISTImpl<SXCM_R2<MbDate>, MbDate>(implType);
	    }

        public static BareANY AdaptValue(BareANY any) {
            if (any is ANYImpl<DateInterval>) {
                ANYImpl<DateInterval> anyDateInterval = (ANYImpl<DateInterval>)any;
                SXCM_R2Impl<MbDate> adaptedValue = new SXCM_R2Impl<MbDate>(anyDateInterval.Value);
                adaptedValue.NullFlavor = anyDateInterval.NullFlavor;
                adaptedValue.DataType = anyDateInterval.DataType;
                adaptedValue.Language = anyDateInterval.Language;
                adaptedValue.DisplayName = anyDateInterval.DisplayName;
                adaptedValue.Translations.AddAll(anyDateInterval.Translations);
                adaptedValue.OriginalText = anyDateInterval.OriginalText;
                adaptedValue.IsCdata = anyDateInterval.IsCdata;
                adaptedValue.Unsorted = anyDateInterval.Unsorted;
                adaptedValue.Operator = anyDateInterval.Operator;
                return adaptedValue;
            } else if (any is ANYImpl<PeriodicIntervalTimeR2>) {
                ANYImpl<PeriodicIntervalTimeR2> anyTimeInterval = (ANYImpl<PeriodicIntervalTimeR2>)any;
                SXCM_R2Impl<MbDate> adaptedValue = new SXCM_R2Impl<MbDate>(anyTimeInterval.Value);
                adaptedValue.NullFlavor = anyTimeInterval.NullFlavor;
                adaptedValue.DataType = anyTimeInterval.DataType;
                adaptedValue.Language = anyTimeInterval.Language;
                adaptedValue.DisplayName = anyTimeInterval.DisplayName;
                adaptedValue.Translations.AddAll(anyTimeInterval.Translations);
                adaptedValue.OriginalText = anyTimeInterval.OriginalText;
                adaptedValue.IsCdata = anyTimeInterval.IsCdata;
                adaptedValue.Unsorted = anyTimeInterval.Unsorted;
                adaptedValue.Operator = anyTimeInterval.Operator;
                return adaptedValue;
            } else if (any is ANYImpl<EventRelatedPeriodicIntervalTime>) {
                ANYImpl<EventRelatedPeriodicIntervalTime> anyTimeInterval = (ANYImpl<EventRelatedPeriodicIntervalTime>)any;
                SXCM_R2Impl<MbDate> adaptedValue = new SXCM_R2Impl<MbDate>(anyTimeInterval.Value);
                adaptedValue.NullFlavor = anyTimeInterval.NullFlavor;
                adaptedValue.DataType = anyTimeInterval.DataType;
                adaptedValue.Language = anyTimeInterval.Language;
                adaptedValue.DisplayName = anyTimeInterval.DisplayName;
                adaptedValue.Translations.AddAll(anyTimeInterval.Translations);
                adaptedValue.OriginalText = anyTimeInterval.OriginalText;
                adaptedValue.IsCdata = anyTimeInterval.IsCdata;
                adaptedValue.Unsorted = anyTimeInterval.Unsorted;
                adaptedValue.Operator = anyTimeInterval.Operator;
                return adaptedValue;
            }
            return any;
        }

		public static Type GetCollectionContentsType(BeanProperty property)
		{
			Type[] actualTypeArguments = property.Descriptor.GetGetMethod().GetGenericArguments();
			return actualTypeArguments != null && actualTypeArguments.Length > 0 ? actualTypeArguments[0] : null;
		}

		public static Object Instantiate(Type t, IDictionary<String,Type> templateArguments) {
			Type resolvedType = ResolveGenerics(t, templateArguments);
			return Activator.CreateInstance(resolvedType);
		}
		
		public static Object Instantiate(Type t, IList<TemplateArgument> templateArguments) {
			Type resolvedType = ResolveGenerics(t, templateArguments);
			return Activator.CreateInstance(resolvedType);
		}

		private static Type ResolveGenerics(Type t, IDictionary<String,Type> dictionary) {
			if (t.IsGenericType) {
				Type[] templateArguments = t.GetGenericArguments();
				Type[] arguments = new Type[templateArguments.Length];
				for (int i = 0, length = templateArguments.Length; i < length; i++) {
					String templateName = templateArguments[i].Name;
					if (dictionary.ContainsKey(templateName)) {
						arguments[i] = ResolveGenerics(dictionary[templateName], dictionary);
					} else {
						throw new System.ArgumentException("Missing parameter: " + templateName);
					}
				}
				return t.MakeGenericType(arguments);
			} else {
				return t;
			}
		}			
		
		private static Type ResolveGenerics(Type t, IList<TemplateArgument> templateArguments) {
			if (templateArguments == null || templateArguments.Count == 0) {
				return t;
			} else {
				Type[] arguments = new Type[templateArguments.Count];
				for (int i = 0, length = templateArguments.Count; i < length; i++) {
					TemplateArgument argument = templateArguments[i];
					arguments[i] = ResolveGenerics(argument.ArgumentType, argument.TemplateArguments);
				}
				return t.MakeGenericType(arguments);
			}
		}			
	}
}
