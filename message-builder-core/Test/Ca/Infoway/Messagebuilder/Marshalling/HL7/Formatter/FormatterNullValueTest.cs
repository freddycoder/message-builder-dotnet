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
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class FormatterNullValueTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAllFormattersWithNullValue()
		{
			IDictionary<string, PropertyFormatter> formatters = FormatterRegistry.GetInstance().GetProtectedRegistryMap();
			foreach (string key in formatters.Keys)
			{
				PropertyFormatter formatter = formatters.SafeGet(key);
				FormatContext context = GetContext("name", key);
				try
				{
					formatter.Format(context, null);
					formatter.Format(context, null, 0);
				}
				catch (Exception e)
				{
					Assert.Fail(key + " (" + formatter.GetType().Name + "): formatter failed when given a null value: " + e.Message);
				}
			}
		}
	}
}
