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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public class ParserRegistry : Registry<ElementParser>
	{
		private static Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserRegistry instance = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserRegistry
			();

		private ParserRegistry()
		{
		}

		protected override void RegisterAll()
		{
			Register(new AdElementParser());
			Register(new AnyElementParser());
			Register(new BagElementParser());
			Register(new BlElementParser());
			Register(new CvElementParser());
			Register(new EdElementParser());
			Register(new EdSignatureElementParser());
			Register(new EnElementParser());
			Register(new IiElementParser());
			Register(new IntElementParser());
			Register(new GtsBoundedPivlElementParser());
			Register(new PivlTsElementParser());
			Register(new PivlTsDateTimeElementParser());
			Register(new IvlIntElementParser());
			Register(new IvlPqElementParser());
			Register(new IvlTsElementParser());
			Register(new ListElementParser());
			Register(new SetElementParser());
			Register(new MoElementParser());
			Register(new OnElementParser());
			Register(new PnElementParser());
			Register(new PqElementParser());
			Register(new RealElementParser());
			Register(new RtoPqPqElementParser());
			Register(new RtoMoPqElementParser());
			Register(new ScElementParser<Code>());
			Register(new StElementParser());
			Register(new TelElementParser());
			Register(new TnElementParser());
			Register(new TsElementParser());
			Register(new UrgPqElementParser());
			Register(new UrgTsElementParser());
		}

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserRegistry GetInstance()
		{
			return instance;
		}
	}
}
