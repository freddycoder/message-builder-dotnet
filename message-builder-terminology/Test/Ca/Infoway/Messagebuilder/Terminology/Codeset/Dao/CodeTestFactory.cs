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
 * Last modified: $LastChangedDate: 2012-01-18 21:43:30 -0500 (Wed, 18 Jan 2012) $
 * Revision:      $LastChangedRevision: 4341 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Terminology.Codeset.Dao {
	
	using Ca.Infoway.Messagebuilder;
	using Ca.Infoway.Messagebuilder.Terminology.Codeset.Domain;
	using ILOG.J2CsMapping.Collections.Generics;
    using Spring.Data.NHibernate.Support; //! using Org.Springframework.Orm.Hibernate3.Support;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	//using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	public class CodeTestFactory : HibernateDaoSupport {
	
		public sealed class Anonymous_C0 : Runnable {
			private readonly CodeTestFactory outer_CodeTestFactory;
			private readonly Object f_object;
	
			public void Run() {
				outer_CodeTestFactory.HibernateTemplate.SaveOrUpdate(f_object);
			}
	
			public Anonymous_C0(Object obj0, CodeTestFactory codeTestFactory) {
				this.outer_CodeTestFactory = codeTestFactory;
				this.f_object = obj0;
			}
		}
	
		private readonly IList<Object> createdObjects;
		private readonly DaoTestSupport testSupport;
	
		public CodeTestFactory(DaoTestSupport testSupport_0) {
			this.createdObjects = new List<Object>();
			this.testSupport = testSupport_0;
			SessionFactory = testSupport_0.SessionFactory;
		}
	
		public ValueSetEntry CreateValueSet(CodedValue codedValue,
				params VocabularyDomain[] vocabularyDomain) {
			ValueSetEntry result = new ValueSetEntry();
			result.CodedValue = codedValue;
			result.Sequence = 1;
			result.Active = ILOG.J2CsMapping.Util.BooleanUtil.TRUE;
			result.Common = ILOG.J2CsMapping.Util.BooleanUtil.TRUE;
			result.ValueSet = new ValueSet();
			/* foreach */
			foreach (VocabularyDomain domain  in  vocabularyDomain) {
				ILOG.J2CsMapping.Collections.Generics.Collections.Add(result.ValueSet.VocabularyDomains,domain);
			}
	
			Save(result);
	
			return result;
		}
	
		public CodedValue CreateCodedValue(CodedValue code, CodedValue parent,
				IList<CodedValue> children) {
			if (code == null) {
				return code;
			}
	
			if (parent != null) {
				ILOG.J2CsMapping.Collections.Generics.Collections.Add(code.Parents,parent);
				ILOG.J2CsMapping.Collections.Generics.Collections.Add(parent.Children,code);
			}
	
			if (children != null) {
				/* foreach */
				foreach (CodedValue child  in  children) {
					ILOG.J2CsMapping.Collections.Generics.Collections.Add(child.Parents,code);
					ILOG.J2CsMapping.Collections.Generics.Collections.Add(code.Children,child);
				}
			}
	
			Save(code);
			if (parent != null) {
				Save(parent);
			}
			if (children != null) {
				/* foreach */
				foreach (CodedValue child_0  in  children) {
					Save(child_0);
				}
			}
	
			return code;
		}
	
		public CodedValue CreateCodedValue(CodeSystem codeSystem, String code) {
			CodedValue result = new CodedValue();
			result.Code = code;
			result.CodeSystem = codeSystem;
			result.CreateUserId = "HWNG";
			result.LastUpdateDatetime = new PlatformDate();
			result.CreateDatetime = new PlatformDate();
			Save(result);
	
			return result;
		}
	
		public CodeSystem CreateCodeSystem(String oid) {
			CodeSystem result = new CodeSystem();
			result.Oid = oid;
			Save(result);
	
			return result;
		}
	
		public VocabularyDomain CreateVocabularyDomain(Type vocabularyDomainType) {
			return CreateVocabularyDomain(vocabularyDomainType, null, null);
		}
	
		public VocabularyDomain CreateVocabularyDomain(
				Type vocabularyDomainType, String businessName,
				String description) {
			VocabularyDomain result = new VocabularyDomain();
			result.Type = vocabularyDomainType.Name;
			result.BusinessName = businessName;
			result.Description = description;
			Save(result);
			return result;
		}
	
		[NUnit.Framework.TearDown]
		public void TearDown() {
			Ca.Infoway.Messagebuilder.CollUtils.Reverse(this.createdObjects);
			for (IIterator<Object> iterator = new ILOG.J2CsMapping.Collections.Generics.IteratorAdapter<System.Object>(this.createdObjects.GetEnumerator()); iterator
					.HasNext();) {
				Object createdObj = iterator.Next();
				HibernateTemplate.Delete(createdObj);
			}
			ILOG.J2CsMapping.Collections.Generics.Collections.Clear(this.createdObjects);
		}
	
		private void Save(Object obj0) {
			this.testSupport.RunInTransaction(new CodeTestFactory.Anonymous_C0(obj0, this));
			ILOG.J2CsMapping.Collections.Generics.Collections.Add(this.createdObjects,obj0);
		}
	}
}
