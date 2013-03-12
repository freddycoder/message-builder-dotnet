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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using Ca.Infoway.Messagebuilder.Xml.Visitor;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class Validator
	{
		private readonly MessageWalker messageWalker;

		private readonly VersionNumber version;

		public Validator(MessageDefinitionService service, XmlDocument message, VersionNumber version)
		{
			this.version = version;
			this.messageWalker = new MessageWalker(service, message, version);
		}

		public virtual MessageValidatorResult Validate()
		{
			ValidatingVisitor visitor = new ValidatingVisitor(this.version);
			this.messageWalker.Accept(visitor);
			return visitor.GetResult();
		}
	}
}
