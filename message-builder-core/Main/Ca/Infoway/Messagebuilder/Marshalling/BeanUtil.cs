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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class BeanUtil
	{
		private static readonly string XPATH_SEPARATOR = "/";

		public static T Instantiate<T>(Type value)
		{
			try
			{
				return (T)System.Activator.CreateInstance(value);
			}
			catch (Exception e)
			{
				throw new MarshallingException(e);
			}
		}

		public static string DescribeBeanPath(object bean, string xpath)
		{
			StringBuilder result = new StringBuilder();
			if (bean != null && StringUtils.IsNotBlank(xpath))
			{
				DescribeBeanPath(bean, xpath.Trim(), result);
			}
			return result.ToString();
		}

		private static void DescribeBeanPath(object bean, string xpath, StringBuilder result)
		{
			IList<string> pathParts = ObtainParts(xpath);
			RemovePartType(bean, pathParts);
			result.Append(bean.GetType().Name).Append('.');
			RelationshipSorter sorter = RelationshipSorter.Create(string.Empty, bean);
			foreach (string part in pathParts)
			{
				object sorterObj = sorter.Get(part);
				if (sorterObj is RelationshipSorter)
				{
					sorter = (RelationshipSorter)sorterObj;
				}
				else
				{
					if (sorterObj is BeanProperty)
					{
						BeanProperty beanProperty = (BeanProperty)sorterObj;
						//				result.append(beanProperty.getPropertyType().getSimpleName()).append('.');  // BEAN PATH
						result.Append(beanProperty.Name).Append('.');
						// ACCESSOR PATH
						sorter = RelationshipSorter.Create(string.Empty, beanProperty.Get());
					}
					else
					{
						// if can't find a mapping match then stop here
						// just append letfover parts? i.e. a.b.c (.leftover1.leftover2)
						break;
					}
				}
			}
			if (result[result.Length - 1] == '.')
			{
				result.DeleteCharAt(result.Length - 1);
			}
		}

		private static void RemovePartType(object bean, IList<string> pathParts)
		{
			if (CollUtils.IsNotEmpty(pathParts))
			{
				if (HasPartType(bean, pathParts[0]))
				{
					pathParts.RemoveAt(0);
				}
			}
		}

		private static bool HasPartType(object bean, string part)
		{
			bool result = false;
			if (bean.GetType().IsAnnotationPresent(typeof(Hl7PartTypeMappingAttribute)))
			{
				Hl7PartTypeMappingAttribute partType = bean.GetType().GetAnnotation<Hl7PartTypeMappingAttribute>();
				string[] values = partType.Value;
				result = values.Length > 0 && values[0].Equals(part);
			}
			return result;
		}

		private static IList<string> ObtainParts(string xpath)
		{
			// need to handle attribute ('@') in xpath - currently attributes are not included in any of our error xpaths,
			//                                          so not handling this situation for now
			if (xpath.StartsWith(XPATH_SEPARATOR))
			{
				xpath = Ca.Infoway.Messagebuilder.StringUtils.Substring(xpath, 1);
			}
			IList<string> fixedList = Arrays.AsList(xpath.Split(XPATH_SEPARATOR));
			// need to return a modifiable list
			return new List<string>(fixedList);
		}
	}
}
