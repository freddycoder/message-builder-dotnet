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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Validator;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class MessageValidatorImpl : MessageValidator
	{
		private readonly MessageBeanTransformerImpl messageTransformer;

		public MessageValidatorImpl() : this(new MessageDefinitionServiceFactory().Create())
		{
		}

		public MessageValidatorImpl(MessageDefinitionService service)
		{
			this.messageTransformer = new MessageBeanTransformerImpl(service, RenderMode.PERMISSIVE);
		}

		public virtual MessageValidatorResult Validate(XmlDocument message, VersionNumber version)
		{
			return this.Validate(message, version, null);
		}

		public virtual MessageValidatorResult Validate(XmlDocument message, VersionNumber version, GenericCodeResolverRegistry codeResolverRegistryOverride
			)
		{
			XmlToModelResult transformResults = this.messageTransformer.TransformFromHl7(version, message, codeResolverRegistryOverride
				);
			return new MessageValidatorResult(transformResults.GetHl7Errors());
		}
	}
}
