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
using System.Reflection;
using System.Collections;

namespace Ca.Infoway.Messagebuilder
{

	public class ListElementUtil
	{
		public static bool IsCollection(Object list) {
			if (list is IList) {
				return true;
			} else if (list is String) {
				return false;
			} else if (list is IEnumerable) {
				return true;
			} else {
				return false;
			}
		}
		public static bool IsCollection(Type type) {
			if (typeof(IList).IsAssignableFrom(type)) {
				return true;
			} else if (typeof(String).IsAssignableFrom(type)) {
				return false;
			} else if (typeof(IEnumerable).IsAssignableFrom(type)) {
				return true;
			} else {
				return false;
			}
		}
		public static Object GetElement(Object list, int index) {
			if (list is IList) {
				return ((IList) list)[index];
			} else if (list is IEnumerable) {
				return GetElement(ConvertToIList((IEnumerable) list), index);
			} else {
				throw new ArgumentException("list is not convertable to a non-generic list type.");
			}
		}
		
		public static int Count(Object list) {
			if (list is IList) {
				return ((IList) list).Count;
			} else if (list is IEnumerable) {
				return Count(ConvertToIList((IEnumerable) list));
			} else {
				throw new ArgumentException("list is not convertable to a non-generic list type.");
			}
		}
		
		public static bool IsEmpty(Object list) {
			return Count(list) == 0;
		}
		
		private static IList ConvertToIList(IEnumerable e) {
			ArrayList list = new ArrayList();
			foreach (Object o in e) {
				list.Add(o);
			}
			return list;
		}

		public static void AddAllElements(Object list, Object element) {
			foreach (Object o in ((IEnumerable) element)) {
				AddElement(list, o);
			}
		}
		
		public static void AddElement(Object list, Object element) {
			System.Console.WriteLine("----> " + element.GetType());
			MethodInfo method = FindAddMethod (list);
			if (method != null) {
				method.Invoke(list, new Object[] { element });
			} else {
				throw new ArgumentException("list does not appear to have an Add method.");
			}
		}
		
		static MethodInfo FindAddMethod (object list)
		{
			MethodInfo result = null;
			MethodInfo[] methods = list.GetType().GetMethods();
			foreach (MethodInfo m in methods) {
				if ("Add".Equals(m.Name) && m.GetParameters().Length == 1) {
					result = m;
					break;
				}
			}
			return result;
		}
	}
}
