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
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	/// <summary>
	/// Query By Parameter
	/// Class which describes the query specifics and parameter
	/// list.
	/// </summary>
	/// <remarks>
	/// Query By Parameter
	/// Class which describes the query specifics and parameter
	/// list.
	/// InitialQuantity must only be specified if
	/// InitialQuantityCode is specified.
	/// </remarks>
	[System.Serializable]
	[Hl7PartTypeMappingAttribute("MFMI_MT700751CA.QueryByParameter")]
	public class QueryByParameterBean<PL> : MessagePartBean
	{
		private const long serialVersionUID = -3400214301200401224L;

		private II queryIdentifier = new IIImpl();

		private CS expeditedQueryIndicator = new CSImpl();

		private INT queryLimit = new INTImpl();

		private CV queryLimitType = new CVImpl();

		private PL parameterList;

		/// <summary>
		/// H:Query Identifier
		/// Unique number for this particular query.
		/// </summary>
		/// <remarks>
		/// H:Query Identifier
		/// Unique number for this particular query.
		/// Needed to allow continuation of queries and linking of
		/// query requests and responses and therefore mandatory.
		/// </remarks>
		[Hl7XmlMappingAttribute("queryId")]
		public virtual Identifier QueryIdentifier
		{
			get
			{
				return this.queryIdentifier.Value;
			}
			set
			{
				Identifier queryIdentifier = value;
				this.queryIdentifier.Value = queryIdentifier;
			}
		}

		/// <summary>
		/// K: Expedited Query Indicator
		/// This allows the sender to indicate to the receiver that
		/// this query should follow an expedited processing flow.
		/// </summary>
		/// <remarks>
		/// K: Expedited Query Indicator
		/// This allows the sender to indicate to the receiver that
		/// this query should follow an expedited processing flow.
		/// Intended to convey the requested 'packaging' of query
		/// results. This attribute does not affect which rows are
		/// selected by the query, just the manner in which they are
		/// returned. For example, a batch file containing responses, a
		/// response message containing multiple payloads, or a stream
		/// of response messages (notifications) each identifying itself
		/// as a response to a query request.
		/// </remarks>
		[Hl7XmlMappingAttribute("responseModalityCode")]
		public virtual ResponseModality ExpeditedQueryIndicator
		{
			get
			{
				return (ResponseModality)this.expeditedQueryIndicator.Value;
			}
			set
			{
				ResponseModality expeditedQueryIndicator = value;
				this.expeditedQueryIndicator.Value = expeditedQueryIndicator;
			}
		}

		/// <summary>
		/// I:Query Limit
		/// The number of response item repetitions that should be
		/// included in the initial response.
		/// </summary>
		/// <remarks>
		/// I:Query Limit
		/// The number of response item repetitions that should be
		/// included in the initial response.
		/// If not specified, the default behavior is to return all
		/// repetitions. However the recipient of a query may always
		/// choose to limit the quantity returned to be less than the
		/// number requested. Regardless of the number specified here,
		/// the number of rows returned will never exceed the number of
		/// matching rows based on the query parameters.
		/// There may be a very large number of matching rows. To
		/// manage communication bandwidth, a limited set may initially
		/// be returned with further data retrieved by using query
		/// continuations.
		/// </remarks>
		[Hl7XmlMappingAttribute("initialQuantity")]
		public virtual Int32? QueryLimit
		{
			get
			{
				return this.queryLimit.Value;
			}
			set
			{
				Int32? queryLimit = value;
				this.queryLimit.Value = queryLimit;
			}
		}

		/// <summary>
		/// J:Query Limit Type
		/// Defines the units associated with the magnitude of the
		/// maximum size limit of a query response that can be accepted
		/// by the requesting application.
		/// </summary>
		/// <remarks>
		/// J:Query Limit Type
		/// Defines the units associated with the magnitude of the
		/// maximum size limit of a query response that can be accepted
		/// by the requesting application.
		/// Needed to quantify the types of records requested to be
		/// returned in the query.
		/// </remarks>
		[Hl7XmlMappingAttribute("initialQuantityCode")]
		public virtual QueryRequestLimit QueryLimitType
		{
			get
			{
				return (QueryRequestLimit)this.queryLimitType.Value;
			}
			set
			{
				QueryRequestLimit queryLimitType = value;
				this.queryLimitType.Value = queryLimitType;
			}
		}

		[Hl7XmlMappingAttribute("parameterList")]
		public virtual PL ParameterList
		{
			get
			{
				return this.parameterList;
			}
			set
			{
				PL parameterList = value;
				this.parameterList = parameterList;
			}
		}
	}
}
