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
 * Last modified: $LastChangedDate: 2011-10-13 11:51:35 -0400 (Thu, 13 Oct 2011) $
 * Revision:      $LastChangedRevision: 3059 $
 */

using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.J5goodies;
using log4net;

namespace Ca.Infoway.Messagebuilder.Model
{
    [Serializable]
    public class MessagePartBean : NullFlavorSupport
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(MessagePartBean));

        private const long serialVersionUID = -850542695451569891L;

        private NullFlavor nullFlavor;

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
		
		
		public StandardDataType GetSpecializationType(String propertyName) {
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
    }
}



public static class StringExtensions
{
    public static String ReplaceAll(this String str, string regex, string substitution)
    {
        return Regex.Replace(str, regex, substitution);
    }

}