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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml.Util;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml.Util
{
	[TestFixture]
	public class XmlWarningRendererTest
	{
		[Test]
		public virtual void ShouldOutputWarning()
		{
			Assert.AreEqual("<!-- WARNING: warning text -->" + SystemUtils.LINE_SEPARATOR, new XmlWarningRenderer().CreateWarning(0, 
				"warning text"), "output text without indent");
		}

		[Test]
		public virtual void ShouldOutputWarningWithIndent()
		{
			Assert.AreEqual("    <!-- WARNING: warning text -->" + SystemUtils.LINE_SEPARATOR, new XmlWarningRenderer().CreateWarning
				(2, "warning text"), "output text without indent");
		}

		[Test]
		public virtual void ShouldOutputWarningWithTrueProperty()
		{
			Runtime.SetProperty(XmlWarningRenderer.MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML, "TrUE");
			Assert.AreEqual("    <!-- WARNING: warning text -->" + SystemUtils.LINE_SEPARATOR, new XmlWarningRenderer().CreateWarning
				(2, "warning text"), "output text with property true");
			Runtime.SetProperty(XmlWarningRenderer.MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML, XmlWarningRenderer.MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML_DEFAULT
				);
		}

		[Test]
		public virtual void ShouldNotOutputWarningWithFalseProperty()
		{
			Runtime.SetProperty(XmlWarningRenderer.MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML, "false");
			Assert.AreEqual(string.Empty, new XmlWarningRenderer().CreateWarning(2, "warning text"), "output text suppressed");
			Runtime.SetProperty(XmlWarningRenderer.MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML, XmlWarningRenderer.MESSAGEBUILDER_OUTPUT_WARNINGS_IN_GENERATED_XML_DEFAULT
				);
		}
	}
}
