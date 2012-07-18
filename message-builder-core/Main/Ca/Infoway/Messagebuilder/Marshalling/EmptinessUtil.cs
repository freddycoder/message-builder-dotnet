using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class EmptinessUtil
	{
		internal static bool IsEmpty(object value)
		{
			if (value == null)
			{
				return true;
			}
			else
			{
				if (ListElementUtil.IsCollection(value))
				{
					return 0 == ListElementUtil.Count(value);
				}
				else
				{
					return false;
				}
			}
		}
	}
}
