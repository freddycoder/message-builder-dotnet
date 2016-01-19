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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A class that models the annotation documentation.</summary>
	/// <remarks>A class that models the annotation documentation.</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class Annotation
	{
		[ElementAttribute(Required = false, Data = true)]
		private string text;

		[XmlAttributeAttribute(Required = false)]
		private string annotationType;

		[XmlAttributeAttribute(Required = false)]
		private string sourceName;

		[XmlAttributeAttribute(Required = false)]
		private string otherAnnotationType;

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		public Annotation()
		{
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="text">- The text description of the annotation.</param>
		public Annotation(string text)
		{
			this.text = text;
		}

		/// <summary>Get the text.</summary>
		/// <remarks>Get the text.</remarks>
		/// <returns>- the text.</returns>
		/// <summary>Set the text</summary>
		/// <value></value>
		public virtual string Text
		{
			get
			{
				return text;
			}
			set
			{
				string text = value;
				this.text = text;
			}
		}

		/// <summary>Get the annotation Type</summary>
		/// <returns>annotation Type</returns>
		/// <summary>Set the annotation Type</summary>
		/// <value></value>
		public virtual string AnnotationType
		{
			get
			{
				return this.annotationType;
			}
			set
			{
				string annotationType = value;
				this.annotationType = annotationType;
			}
		}

		/// <summary>Get the annotation Type</summary>
		/// <returns>annotation Type</returns>
		public virtual Ca.Infoway.Messagebuilder.Xml.AnnotationType GetAnnotationTypeAsEnum()
		{
			if (this.annotationType != null)
			{
				return EnumPattern.ValueOf<Ca.Infoway.Messagebuilder.Xml.AnnotationType>(this.annotationType);
			}
			return null;
		}

		/// <summary>Set the annotation Type</summary>
		/// <param name="annotationType"></param>
		public virtual void SetAnnotationTypeAsEnum(Ca.Infoway.Messagebuilder.Xml.AnnotationType annotationType)
		{
			this.annotationType = annotationType == null ? null : annotationType.Name;
		}

		public virtual string SourceName
		{
			get
			{
				return sourceName;
			}
			set
			{
				string sourceName = value;
				this.sourceName = sourceName;
			}
		}

		public virtual string OtherAnnotationType
		{
			get
			{
				return otherAnnotationType;
			}
			set
			{
				string otherAnnotationType = value;
				this.otherAnnotationType = otherAnnotationType;
			}
		}

		/// <summary>Standard equals implementation.</summary>
		/// <remarks>Standard equals implementation.</remarks>
		/// <param name="obj">- the other object</param>
		/// <returns>true if the objects are equal; false otherwise</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else
			{
				if (GetType() != obj.GetType())
				{
					return false;
				}
				else
				{
					Ca.Infoway.Messagebuilder.Xml.Annotation that = (Ca.Infoway.Messagebuilder.Xml.Annotation)obj;
					return new EqualsBuilder().Append(this.text, that.text).Append(this.annotationType, that.annotationType).Append(this.otherAnnotationType
						, that.otherAnnotationType).Append(this.sourceName, that.sourceName).IsEquals();
				}
			}
		}

		/// <summary>Standard hash code method.</summary>
		/// <remarks>Standard hash code method.</remarks>
		/// <returns>the hash code</returns>
		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.text).Append(this.annotationType).Append(this.otherAnnotationType).Append(this.sourceName
				).ToHashCode();
		}
	}
}
