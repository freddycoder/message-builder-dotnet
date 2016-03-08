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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Terminology;
using NUnit;
using System.Threading;

namespace Ca.Infoway.Messagebuilder.Resolver
{
    [NUnit.Framework.TestFixture]
    public class CodeResolverRegistryTest
	{
		private readonly GenericCodeResolverRegistry registry1 = new GenericCodeResolverRegistryImpl();

		private readonly GenericCodeResolverRegistry registry2 = new GenericCodeResolverRegistryImpl();

		private readonly GenericCodeResolverRegistry registry3 = new GenericCodeResolverRegistryImpl();

		private readonly GenericCodeResolverRegistry registry4 = new GenericCodeResolverRegistryImpl();

		private readonly GenericCodeResolverRegistry registry5 = new GenericCodeResolverRegistryImpl();

		private readonly GenericCodeResolverRegistry registry6 = new GenericCodeResolverRegistryImpl();

        [NUnit.Framework.SetUp]
        public virtual void Startup()
		{
			CodeResolverRegistry.ClearThreadLocalVersion();
			CodeResolverRegistry.RemoveAllRegistries();
			CodeResolverRegistry.UnregisterAll();
		}

        [NUnit.Framework.TearDown]
        public virtual void Teardown()
		{
			CodeResolverRegistry.ClearThreadLocalVersion();
			CodeResolverRegistry.RemoveAllRegistries();
			CodeResolverRegistry.UnregisterAll();
		}

        [NUnit.Framework.Test]
        public virtual void TestRegistryRegistration()
		{
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02, registry1);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03, registry2);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03_AB, registry3);
            NUnit.Framework.Assert.AreEqual(registry1, CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02));
            NUnit.Framework.Assert.AreEqual(registry2, CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03));
            NUnit.Framework.Assert.AreEqual(registry3, CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03_AB));
            NUnit.Framework.Assert.IsNull(CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.V01R04_3));
		}

        [NUnit.Framework.Test]
        public virtual void TestRegistryRetrieval()
		{
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02, registry1);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03, registry2);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03_AB, registry3);
			CodeResolverRegistry.SetThreadLocalVersion(SpecificationVersion.R02_04_02);
            NUnit.Framework.Assert.AreEqual(registry1, CodeResolverRegistry.GetRegistry());
			CodeResolverRegistry.SetThreadLocalVersion(SpecificationVersion.R02_04_03);
            NUnit.Framework.Assert.AreEqual(registry2, CodeResolverRegistry.GetRegistry());
			CodeResolverRegistry.SetThreadLocalVersion(SpecificationVersion.R02_04_03_AB);
            NUnit.Framework.Assert.AreEqual(registry3, CodeResolverRegistry.GetRegistry());
			CodeResolverRegistry.ClearThreadLocalVersion();
            NUnit.Framework.Assert.AreEqual(CodeResolverRegistry.GetDefaultRegistry(), CodeResolverRegistry.GetRegistry());
		}

        [NUnit.Framework.Test]
        public virtual void TestRegistryRemoval()
		{
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02, registry1);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03, registry2);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03_AB, registry3);
            NUnit.Framework.Assert.AreEqual(registry1, CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02));
            NUnit.Framework.Assert.AreEqual(registry2, CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03));
            NUnit.Framework.Assert.AreEqual(registry3, CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03_AB));
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02, null);
            NUnit.Framework.Assert.IsNull(CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02));
			CodeResolverRegistry.RemoveAllRegistries();
            NUnit.Framework.Assert.IsNull(CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02));
            NUnit.Framework.Assert.IsNull(CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03));
            NUnit.Framework.Assert.IsNull(CodeResolverRegistry.GetCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03_AB));
		}

		/// <exception cref="System.Exception"></exception>
        [NUnit.Framework.Test]
        public virtual void TestThreadSafety()
		{
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_02, registry1);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03, registry2);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.R02_04_03_AB, registry3);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.V01R04_2_SK, registry4);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.V01R04_3, registry5);
			CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.V01R04_3_ON, registry6);
			IList<CodeResolverRegistryTest.ThreadTest> testList = new List<CodeResolverRegistryTest.ThreadTest>();
			for (int i = 0; i < 100; i++)
			{
				testList.Add(new CodeResolverRegistryTest.ThreadTest(this, i * 6, SpecificationVersion.R02_04_02, registry1));
				testList.Add(new CodeResolverRegistryTest.ThreadTest(this, i * 6 + 1, SpecificationVersion.R02_04_03, registry2));
				testList.Add(new CodeResolverRegistryTest.ThreadTest(this, i * 6 + 2, SpecificationVersion.R02_04_03_AB, registry3));
				testList.Add(new CodeResolverRegistryTest.ThreadTest(this, i * 6 + 3, SpecificationVersion.V01R04_2_SK, registry4));
				testList.Add(new CodeResolverRegistryTest.ThreadTest(this, i * 6 + 4, SpecificationVersion.V01R04_3, registry5));
				testList.Add(new CodeResolverRegistryTest.ThreadTest(this, i * 6 + 5, SpecificationVersion.V01R04_3_ON, registry6));
			}
			foreach (CodeResolverRegistryTest.ThreadTest threadTest in testList)
			{
				threadTest.Start();
			}
			foreach (CodeResolverRegistryTest.ThreadTest threadTest in testList)
			{
				threadTest.Join();
			}
			foreach (CodeResolverRegistryTest.ThreadTest threadTest in testList)
			{
                // "thread " + threadTest.GetThreadId(), 
                NUnit.Framework.Assert.IsTrue(threadTest.HasPassedTest());
			}
		}

		private class ThreadTest
		{
			private readonly VersionNumber version;

			private readonly GenericCodeResolverRegistry registry;

			private bool passedTest = false;

			private readonly int threadId;
            private readonly Thread thread;

			public virtual int GetThreadId()
			{
				return this.threadId;
			}

			public ThreadTest(CodeResolverRegistryTest _enclosing, int threadId, VersionNumber version, GenericCodeResolverRegistry registry
				)
			{
				this._enclosing = _enclosing;
				this.threadId = threadId;
				this.version = version;
				this.registry = registry;
                this.thread = new Thread(this.Run);
            }

            public void Start() {
                this.thread.Start();
            }

            public void Join() {
                this.thread.Join();
            }

			public void Run()
			{
				CodeResolverRegistry.SetThreadLocalVersion(this.version);
				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception)
				{
				}
				this.passedTest = (CodeResolverRegistry.GetRegistry() == this.registry);
			}

			public virtual bool HasPassedTest()
			{
				return this.passedTest;
			}

			private readonly CodeResolverRegistryTest _enclosing;
		}
	}
}
