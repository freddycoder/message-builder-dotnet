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
