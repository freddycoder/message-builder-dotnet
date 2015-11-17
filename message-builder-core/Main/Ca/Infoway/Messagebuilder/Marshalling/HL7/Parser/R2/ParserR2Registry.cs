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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	public class ParserR2Registry : Registry<ElementParser>
	{
		private static Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2.ParserR2Registry instance = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2.ParserR2Registry
			();

		private ParserR2Registry()
		{
		}

		protected override void RegisterAll()
		{
			Register(new AnyR2ElementParser());
			Register(new AdR2ElementParser());
			Register(new BlR2ElementParser());
			Register(new BxitCdR2ElementParser());
			Register(new EdElementParser(new TelR2ElementParser(), true));
			Register(new EivlTsR2ElementParser());
			Register(new EnR2ElementParser());
			Register(new HxitCeR2ElementParser());
			Register(new IiR2ElementParser());
			Register(new IntR2ElementParser());
			Register(new IvlIntR2ElementParser());
			Register(new IvlMoR2ElementParser());
			Register(new IvlPqR2ElementParser());
			Register(new IvlRealR2ElementParser());
			Register(new IvlTsR2ElementParser());
			Register(new ListR2ElementParser(this));
			Register(new MoR2ElementParser());
			Register(new OnR2ElementParser());
			Register(new PivlTsR2ElementParser());
			Register(new PnR2ElementParser());
			Register(new PqR2ElementParser());
			Register(new RealR2ElementParser());
			Register(new RtoMoPqR2ElementParser());
			Register(new RtoPqPqR2ElementParser());
			Register(new SetR2ElementParser(this));
			Register(new StR2ElementParser());
			Register(new TelR2ElementParser());
			Register(new TnR2ElementParser());
			Register(new TsR2ElementParser());
			Register(new CsR2ElementParser());
			Register(new ScR2ElementParser());
			Register(new CvR2ElementParser());
			// also for CO
			Register(new CeR2ElementParser());
			Register(new CdR2ElementParser());
			Register(new SxcmCdR2ElementParser());
			Register(new PqrR2ElementParser());
			Register(new CrR2ElementParser());
		}

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2.ParserR2Registry GetInstance()
		{
			return instance;
		}
	}
}
