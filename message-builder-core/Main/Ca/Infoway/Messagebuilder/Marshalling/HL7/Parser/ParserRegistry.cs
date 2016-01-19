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
			Register(new BagElementParser(this));
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
			Register(new ListElementParser(this));
			Register(new SetElementParser(this));
			Register(new MoElementParser());
			Register(new OnElementParser());
			Register(new PnElementParser());
			Register(new PqElementParser());
			Register(new RealElementParser());
			Register(new RtoPqPqElementParser());
			Register(new RtoMoPqElementParser());
			Register(new ScElementParser());
			Register(new StElementParser());
			Register(new TelElementParser());
			Register(new TnElementParser());
			Register(new TsElementParser());
			Register(new UrgPqElementParser());
			Register(new UrgTsElementParser());
			Register(new TsCdaElementParser());
			Register(new PivlTsCdaElementParser());
			Register(new IvlTsCdaElementParser());
		}

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserRegistry GetInstance()
		{
			return instance;
		}
	}
}
