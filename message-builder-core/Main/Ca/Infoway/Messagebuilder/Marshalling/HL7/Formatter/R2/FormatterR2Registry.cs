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
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	public class FormatterR2Registry : Registry<PropertyFormatter>
	{
		private static Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2.FormatterR2Registry instance = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2.FormatterR2Registry
			();

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2.FormatterR2Registry GetInstance()
		{
			return instance;
		}

		private FormatterR2Registry()
		{
		}

		protected override void RegisterAll()
		{
			Register(new AdR2PropertyFormatter());
			Register(new AnyR2PropertyFormatter());
			Register(new BlR2PropertyFormatter());
			Register(new BagR2PropertyFormatter(this));
			Register(new BxitCdR2PropertyFormatter());
			Register(new CdR2PropertyFormatter());
			Register(new CeR2PropertyFormatter());
			Register(new CrR2PropertyFormatter());
			Register(new CsR2PropertyFormatter());
			Register(new CvR2PropertyFormatter());
			Register(new EdPropertyFormatter(new TelR2PropertyFormatter(), true));
			Register(new EivlTsR2PropertyFormatter());
			Register(new EnR2PropertyFormatter());
			Register(new HxitCeR2PropertyFormatter());
			Register(new IiR2PropertyFormatter());
			Register(new IntR2PropertyFormatter());
			Register(new IvlIntR2PropertyFormatter());
			Register(new IvlMoR2PropertyFormatter());
			Register(new IvlPqR2PropertyFormatter());
			Register(new IvlRealR2PropertyFormatter());
			Register(new IvlTsR2PropertyFormatter());
			Register(new ListR2PropertyFormatter(this));
			Register(new MoR2PropertyFormatter());
			Register(new PivlTsR2PropertyFormatter());
			Register(new PqR2PropertyFormatter());
			Register(new PqrR2PropertyFormatter());
			Register(new RealR2PropertyFormatter());
			Register(new RtoMoPqR2PropertyFormatter());
			Register(new RtoPqPqR2PropertyFormatter());
			Register(new ScR2PropertyFormatter());
			Register(new SetR2PropertyFormatter(this));
			Register(new StR2PropertyFormatter());
			Register(new SxcmCdR2PropertyFormatter());
			Register(new TelR2PropertyFormatter());
			Register(new TsR2PropertyFormatter());
		}
	}
}
