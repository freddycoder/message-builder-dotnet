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
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PORX_MT010120CA.QuantityObservationEvent" })]
	public class QuantityObservationEventBean : MessagePartBean
	{
		private const long serialVersionUID = 4825026708205805716L;

		private TS patientMeasurementTime = new TSImpl();

		private PQ patientMeasuredValue = new PQImpl();

		private CD patientMeasurementType = new CDImpl();

		[Hl7XmlMappingAttribute("effectiveTime")]
		public virtual PlatformDate PatientMeasurementTime
		{
			get
			{
				return this.patientMeasurementTime.Value;
			}
			set
			{
				PlatformDate patientMeasurementTime = value;
				this.patientMeasurementTime.Value = patientMeasurementTime;
			}
		}

		[Hl7XmlMappingAttribute("value")]
		public virtual PhysicalQuantity PatientMeasuredValue
		{
			get
			{
				return this.patientMeasuredValue.Value;
			}
			set
			{
				PhysicalQuantity patientMeasuredValue = value;
				this.patientMeasuredValue.Value = patientMeasuredValue;
			}
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual x_ActObservationHeightOrWeight PatientMeasurementType
		{
			get
			{
				return (x_ActObservationHeightOrWeight)this.patientMeasurementType.Value;
			}
			set
			{
				x_ActObservationHeightOrWeight patientMeasurementType = value;
				this.patientMeasurementType.Value = patientMeasurementType;
			}
		}
	}
}
