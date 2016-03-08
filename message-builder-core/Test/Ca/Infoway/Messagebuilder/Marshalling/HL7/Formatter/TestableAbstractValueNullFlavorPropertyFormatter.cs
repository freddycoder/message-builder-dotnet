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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>Used to open up the visibility of the protected getAttributeNameValuePairs method in the parent class.</summary>
	/// <remarks>
	/// Used to open up the visibility of the protected getAttributeNameValuePairs method in the parent class.
	/// In C#, test classes cannot call protected methods unless they extend the class under test.
	/// </remarks>
	public interface TestableAbstractValueNullFlavorPropertyFormatter<V>
	{
		IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, V t, BareANY bareAny);
	}
}
