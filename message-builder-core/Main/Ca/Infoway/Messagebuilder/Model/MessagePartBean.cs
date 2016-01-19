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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text.RegularExpressions;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.J5goodies;
using ILOG.J2CsMapping.Text;
using log4net;

namespace Ca.Infoway.Messagebuilder.Model
{
    [Serializable]
    public class MessagePartBean : ExtendedNullFlavorSupport, SpecializationTypeSupport
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(MessagePartBean));

        private const long serialVersionUID = -850542695451569891L;

        private NullFlavor nullFlavor;
        private IList<Realm> realmcode;

        private Object getHl7ValueFromMessageAttributes(String propertyName)
        {

            var property = BeanProperty.GetProperty(this, "messageAttributes");

            var messageAttributesBean = (MessagePartBean)property.Get();

            return messageAttributesBean.GetField(propertyName);
        }

        private int extractIndex(String indexPart)
        {

            return Convert.ToInt32(indexPart.ReplaceAll("\\[|\\]", ""));
        }

        private FieldInfo getAccessibleField(String basePropertyName)
        {

            var type = GetType();

            return getAccessibleField(type, basePropertyName);
        }

        private FieldInfo getAccessibleField(Type type, String basePropertyName)
        {
            var field = type.GetField(basePropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var baseType = type.BaseType;

            if(field == null && !baseType.Equals(type))
            {
                field = getAccessibleField(baseType, basePropertyName);
            }


            return field;
        }

        private String pickIndexPart(String propertyName)
        {
            var indexPart = "";
            var regex = new Regex("\\[\\d+\\]");
            var match = regex.Match(propertyName);

            if (match.Success)
            {
                indexPart = match.Groups[0].Value;
            }

            return indexPart;
        }

        public Object GetField(String propertyName)
        {
            Object hl7Value = null;
            try
            {

                String indexPart = pickIndexPart(propertyName);

                if (indexPart.Length == 0)
                { // a strict translation of the 1.6-only "indexPart.isEmpty()"

                    var field = getAccessibleField(propertyName);

                    if (field == null)
                    {

                        if (isInteraction())
                        {
                            hl7Value = getHl7ValueFromMessageAttributes(propertyName);
                        }
                        //        			else {
                        //            			log.error(String.format("The field %s.%s was not found", this.getClass().getSimpleName(), propertyName));
                        //            		}
                    }
                    else
                    {
                        hl7Value = field.GetValue(this);
                    }
                }
                else
                {
                    var field = getAccessibleField(propertyName.Replace(indexPart, ""));
                    var value = field.GetValue(this);
                    var valueType = value.GetType();
                    var genericType = typeof(LIST<,>);

                    bool isList = valueType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == genericType);

                    if(isList)
                    {
                        
                        var valuePropertyInfo = valueType.GetProperty("Value");
                        var list = valuePropertyInfo.GetValue(value,null);

                        var itemPropertyList = list.GetType().GetProperty("Item");

                        hl7Value = itemPropertyList.GetValue(list, new Object[] { extractIndex(indexPart) });

                    }
                    else
                    {
                        log.Error(String.Format("The indexed field {0} of bean {1} is not a LIST.", propertyName, this));
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(String.Format("Unable to get field {0} of bean {1}", propertyName, this), e);
            }
            return hl7Value;
        }

        
        private bool isInteraction()
        {
            BeanProperty property = BeanProperty.GetProperty(this, "messageAttributes");
            return property != null;
        }


        public bool HasNullFlavor()
        {
            return NullFlavor != null;
        }

        public NullFlavor NullFlavor
        {
            get { return nullFlavor; }
            set { nullFlavor = value; }
        }
		
		public NullFlavor GetNullFlavor(String propertyName) {
			Object field = GetField(propertyName);
			if (field is BareANY) {
				return ((BareANY) field).NullFlavor;
			} else {
                log.Error("Could not find property " + propertyName + " in order to get specialization type");
				return null;
			}
		}
		
		public bool HasNullFlavor(String propertyName) {
			return GetNullFlavor(propertyName) != null;
		}

        public virtual void SetNullFlavor(string propertyName, Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor nullFlavor)
        {
            object field = GetField(propertyName);
            if (field is BareANY)
            {
                ((BareANY)field).NullFlavor = nullFlavor;
            }
            else
            {
                if (field is MessagePartBean)
                {
                    ((MessagePartBean)field).NullFlavor = nullFlavor;
                }
                else
                {
                    throw new InvalidOperationException("Could not find property " + propertyName + " in order to set nullFlavor");
                }
            }
        }

        public virtual bool HasNullFlavorInList(string propertyName, int indexInList)
        {
            return GetNullFlavorInList(propertyName, indexInList) != null;
        }

        public virtual Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor GetNullFlavorInList(string propertyName, int indexInList)
        {
            return (Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor)GetMetadataInCollection(propertyName, indexInList, null, false);
        }

        public virtual bool SetNullFlavorInList(string propertyName, int indexInList, Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor
             nullFlavor)
        {
            return SetMetadataInCollection(propertyName, indexInList, null, nullFlavor, false);
        }

        public virtual bool HasNullFlavorInSet(string propertyName, object valueInSet)
        {
            return GetNullFlavorInSet(propertyName, valueInSet) != null;
        }

        public virtual Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor GetNullFlavorInSet(string propertyName, object valueInSet
            )
        {
            return (Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor)GetMetadataInCollection(propertyName, -1, valueInSet, false);
        }

        public virtual bool SetNullFlavorInSet(string propertyName, object valueInSet, Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor
             nullFlavor)
        {
            return SetMetadataInCollection(propertyName, -1, valueInSet, nullFlavor, false);
        }

        public virtual IList<Realm> GetRealmCode()
        {
            return this.realmcode;
        }

        public virtual void AddRealmCode(Realm code)
        {
            if (this.realmcode == null)
            {
                this.realmcode = new List<Realm>();
            }
            this.realmcode.Add(code);
        }

        public virtual void ClearRealmCode()
        {
            this.realmcode = null;
        }
        
        public StandardDataType GetSpecializationType(String propertyName)
        {
			Object field = GetField(propertyName);
			if (field is BareANY) {
				return ((BareANY) field).DataType;
			} else {
                log.Error("Could not find property " + propertyName + " in order to get specialization type");
				return null;
			}
		}
		
		public void SetSpecializationType(String propertyName, StandardDataType specializationType) {
			Object field = GetField(propertyName);
			if (field is BareANY) {
				((BareANY) field).DataType = specializationType;
			} else {
                log.Error("Could not find property " + propertyName + " in order to set specialization type");
			}
		}

        public virtual StandardDataType GetSpecializationTypeInList(string propertyName, int indexInList)
        {
            return (StandardDataType)GetMetadataInCollection(propertyName, indexInList, null, true);
        }

        public virtual bool SetSpecializationTypeInList(string propertyName, int indexInList, StandardDataType specializationType
            )
        {
            return SetMetadataInCollection(propertyName, indexInList, null, specializationType, true);
        }

        public virtual StandardDataType GetSpecializationTypeInSet(string propertyName, object valueInSet)
        {
            return (StandardDataType)GetMetadataInCollection(propertyName, -1, valueInSet, true);
        }

        public virtual bool SetSpecializationTypeInSet(string propertyName, object valueInSet, StandardDataType specializationType
            )
        {
            return SetMetadataInCollection(propertyName, -1, valueInSet, specializationType, true);
        }

        // TODO - TM - modify get/set to accommodate NFs on collections of associations? (users can set NF directly on MessagePart beans, not really necessary to do this here)
        private object GetMetadataInCollection(string propertyName, int indexInList, object valueInSet, bool isSpecializationType)
        {
	    ICollection<ANY<object>> value = ObtainFieldInCollection(propertyName, indexInList);
	    if (value == null)
	    {
		return null;
	    }

            object result = null;
            int pos = 0;
            for (IEnumerator<ANY<object>> iterator = value.GetEnumerator(); iterator.MoveNext(); pos++)
            {
                ANY<object> item = iterator.Current;
                object actualValue = item.Value;
                if ((indexInList == -1 && valueInSet.Equals(actualValue)) || pos == indexInList)
                {
                    result = isSpecializationType ? (object)item.DataType : (object)item.NullFlavor;
                    break;
                }
            }
            return result;
        }

        private bool SetMetadataInCollection(string propertyName, int indexInList, object valueInSet, object valueToApply, bool isSpecializationType)
        {
    		// the field specified by propertyName MUST be a LIST/SET/COLLECTION datatype or a Collection, otherwise this method will fail
            ICollection<ANY<object>> value = ObtainFieldInCollection(propertyName, indexInList);
		    if (value == null) {
			    return false;
		    }

            bool result = false;
            int pos = 0;
            for (IEnumerator<ANY<object>> iterator = value.GetEnumerator(); iterator.MoveNext(); pos++)
            {
                ANY<object> item = iterator.Current;
                object actualValue = item.Value;
                if ((indexInList == -1 && valueInSet.Equals(actualValue)) || pos == indexInList)
                {
                    if (isSpecializationType)
                    {
                        item.DataType = (StandardDataType)valueToApply;
                    }
                    else
                    {
                        item.NullFlavor = (Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor)valueToApply;
                    }
                    result = true;
                    break;
                }
            }

            if (!result) {
			    log.Error(string.Format("Could not find the specified entry in the field/collection %s.%s. Value not set.", this.GetType().Name, propertyName));
            }
        
            return result;
        }

		private ICollection<ANY<object>> ObtainFieldInCollection(string propertyName, int indexInList)
		{
			ICollection<ANY<object>> value = null;
			object rawField = GetField(propertyName);
			if (rawField == null)
			{
				log.Error(string.Format("The field %s.%s was not found", this.GetType().Name, propertyName));
				return null;
			}
			// the rawField will either be an ANY type or a List
			if (rawField is ANY<object>)
			{
				ANY<object> field = (ANY<object>)rawField;
				if (field.Value is ICollection<object>)
				{
					value = (ICollection<ANY<object>>)field.Value;
				}
				else
				{
					log.Error(string.Format("The field %s.%s was expected to be of type LIST/SET/COLLECTION. Cannot process.", this.GetType
						().Name, propertyName));
					return null;
				}
			}
			else
			{
				if (rawField is ICollection<object>)
				{
					value = (ICollection<ANY<object>>)rawField;
				}
				else
				{
					log.Error(string.Format("The field %s.%s was expected to be a Collection type (typically List). Cannot process.", this
						.GetType().Name, propertyName));
					return null;
				}
			}
			if (indexInList >= value.Count)
			{
				log.Error("Property " + propertyName + " has " + value.Count + " elements, but trying to access element " + indexInList
					 + ". Cannot process.");
				return null;
			}
			return value;
		}

    }
}



public static class StringExtensions
{
    public static String ReplaceAll(this String str, string regex, string substitution)
    {
        return Regex.Replace(str, regex, substitution);
    }

}
