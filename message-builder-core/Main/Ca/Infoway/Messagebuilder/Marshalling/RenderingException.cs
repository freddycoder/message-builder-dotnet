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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[System.Serializable]
	public class RenderingException : MarshallingException
	{
		private const long serialVersionUID = 1300553061611883012L;

		public RenderingException() : base()
		{
		}

		public RenderingException(string message, Exception cause) : base(message, cause)
		{
		}

		public RenderingException(string message) : base(message)
		{
		}

		public RenderingException(Exception cause) : base(cause)
		{
		}
	}
}
