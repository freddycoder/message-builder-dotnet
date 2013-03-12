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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;
using ILOG.J2CsMapping.Text;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class DataTypeFieldHelper
	{
		private sealed class _NullFlavorSupport_36 : NullFlavorSupport
		{
			public _NullFlavorSupport_36()
			{
			}

			public NullFlavor NullFlavor
			{
				get
				{
					return null;
				}
				set
				{
					NullFlavor nullFlavor = value;
				}
			}

			public bool HasNullFlavor()
			{
				return false;
			}
		}

		private static NullFlavorSupport NULL_VALUABLE = new _NullFlavorSupport_36();

		private readonly ILog log = log4net.LogManager.GetLogger(typeof(Ca.Infoway.Messagebuilder.Marshalling.DataTypeFieldHelper
			));

		private readonly DataTypeFieldHelper.ErrorLogger errorLogger;

		private readonly object bean;

		private readonly string fieldName;

		public class ErrorLogger
		{
			public virtual void LogNotMessagePartBean(ILog log, object bean)
			{
				log.Error(System.String.Format("Unable to extract HL7 value. The bean {0} does not extend {1}", bean.GetType().Name, typeof(
					MessagePartBean).Name));
			}

			public virtual void LogFieldNotFound(ILog log, MessagePartBean messagePartBean, string fieldName)
			{
				log.Error(System.String.Format("Unable to extract HL7 value. The bean {0} does not have the field {1}", messagePartBean.GetType
					().Name, fieldName));
			}

			public virtual void LogInvalidFieldType(ILog log, MessagePartBean bean, string fieldName, Type fieldType, bool isCollection
				)
			{
				string message = System.String.Format("Unable to extract HL7 value. The field {0}.{1} is not a {2}{3}", bean.GetType().Name
					, fieldName, fieldType.Name, isCollection ? " (this is possibly an expected situation)" : string.Empty);
				if (isCollection)
				{
					log.Info(message);
				}
				else
				{
					log.Warn(message);
				}
			}
		}

		public DataTypeFieldHelper(object bean, string propertyName) : this(bean, propertyName, new DataTypeFieldHelper.ErrorLogger
			())
		{
		}

		/// <param name="bean"></param>
		/// <param name="propertyName">
		/// - Note that in C#, the property name usually starts with a capital letter,
		/// whereas the field name starts with a lower-case letter.
		/// </param>
		/// <param name="errorLogger"></param>
		internal DataTypeFieldHelper(object bean, string propertyName, DataTypeFieldHelper.ErrorLogger errorLogger)
		{
			this.bean = bean;
			this.fieldName = WordUtils.Uncapitalize(propertyName);
			this.errorLogger = errorLogger;
		}

		private object Get()
		{
			MessagePartBean messagePartBean = AsMessagePartBean();
			return messagePartBean != null ? GetField(messagePartBean) : null;
		}

		public virtual void SetNullFlavor(NullFlavor nullFlavor)
		{
			AsNullable(this.fieldName).NullFlavor = nullFlavor;
		}

		public virtual NullFlavor GetNullFlavor()
		{
			return AsNullable(this.fieldName).NullFlavor;
		}

		public virtual T Get<T>()
		{
			System.Type fieldType = typeof(T);
			T typedField = default(T);
			object field = Get();
			if (fieldType.IsInstanceOfType(field))
			{
				typedField = (T)field;
			}
			else
			{
				if (field != null)
				{
					bool isCollection = typeof(ICollection<object>).IsInstanceOfType(field);
					this.errorLogger.LogInvalidFieldType(this.log, (MessagePartBean)this.bean, this.fieldName, fieldType, isCollection);
				}
			}
			return typedField;
		}

		private object GetField(MessagePartBean messagePartBean)
		{
			object field = messagePartBean.GetField(this.fieldName);
			if (field == null)
			{
				this.errorLogger.LogFieldNotFound(this.log, messagePartBean, this.fieldName);
			}
			return field;
		}

		private MessagePartBean AsMessagePartBean()
		{
			MessagePartBean messagePartBean = null;
			if (this.bean is MessagePartBean)
			{
				messagePartBean = (MessagePartBean)this.bean;
			}
			else
			{
				this.errorLogger.LogNotMessagePartBean(this.log, this.bean);
			}
			return messagePartBean;
		}

		private NullFlavorSupport AsNullable(string fieldName)
		{
			NullFlavorSupport nullable = NULL_VALUABLE;
			MessagePartBean messagePartBean = AsMessagePartBean();
			if (messagePartBean != null)
			{
				object field = GetField(messagePartBean);
				if (field is NullFlavorSupport)
				{
					nullable = (NullFlavorSupport)field;
				}
			}
			return nullable;
		}
	}
}
