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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Model
{
    [TestFixture]
    public class MessagePartBeanTest
    {
        private Bean bean;

        //@SuppressWarnings("serial")
        class BaseBean : MessagePartBean
        {

            private II identifierInBase = new IIImpl();

            public Identifier getIdInBase()
            {
                return this.identifierInBase.Value;
            }
        }

        //@SuppressWarnings("serial")
        class Bean : BaseBean
        {

            private II identifier = new IIImpl();

            private LIST<II, Identifier> ids = new LISTImpl<II, Identifier>(typeof(IIImpl));

            public IList<Identifier> getIds()
            {
                return ids.RawList();
            }

            public II getIdentifier()
            {
                return identifier;
            }
        }

        [SetUp]
        public void setUp()
        {
            bean = new Bean();
        }

        [Test]
        public void getAsHl7DataTypeShouldRetrieveCorrectHl7DataTypeWhenInSuperClass()
        {

            Assert.IsNotNull(bean.GetField("identifierInBase"));

        }

        [Test]
        public void getAsHl7DataTypeShouldRetrieveCorrectHl7DataType()
        {
            Assert.IsNotNull(bean.GetField("identifier"));
        }

        [Test]
        public void getAsHl7DataTypeShouldHandleLISTCorrectly()
        {
                       
            bean.getIds().Add(new Identifier("root", "extension"));

            Assert.IsNotNull(bean.GetField("ids[0]"));
        }

        [Test]
        [Ignore]
        public void getAsHl7DataTypeShouldReturnNullAnyWhenPropertyIsNotFound()
        {
            Object field = bean.GetField("invisible");
            Assert.IsNotNull(field);
        }

        //@Test(expected=IndexOutOfBoundsException.class)
        [Test]
        [Ignore]
        public void getAsHl7DataTypeShouldHandleListIndexOutOfBounds()
        {
            bean.getIds().Add(new Identifier("root", "extension"));
            bean.GetField("ids[1]");
        }
    }
}
