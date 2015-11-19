using System;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class BridgeContext
	{
		private readonly bool collapsed;

		private readonly Int32? index;

		internal BridgeContext() : this(false)
		{
		}

		internal BridgeContext(bool collapsed)
		{
			this.collapsed = collapsed;
			this.index = null;
		}

		internal BridgeContext(bool collapsed, Int32? index)
		{
			this.collapsed = collapsed;
			this.index = index;
		}

		public virtual bool IsCollapsed()
		{
			return this.collapsed;
		}

		public virtual Int32? GetOriginalIndex()
		{
			return this.index;
		}

		public virtual int GetIndex()
		{
			if (this.index == null)
			{
				throw new InvalidOperationException("index is null");
			}
			else
			{
				return this.index.Value;
			}
		}

		public virtual bool IsIndexed()
		{
			return this.index != null;
		}
	}
}
