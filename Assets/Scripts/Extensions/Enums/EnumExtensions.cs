using System;
using System.Collections.Generic;

namespace Assets.Scripts.Extensions.Enums
{
    public static class EnumExtensions
    {
        public static int Length(this Enum theEnum)
        {
            return System.Enum.GetNames(theEnum.GetType()).Length;
        }

	    public static void Add<TKey,TValue>(this Dictionary<TKey, TValue> dictionary, KeyValuePair<TKey,TValue> set)
	    {
			dictionary.Add(set.Key, set.Value);
	    }
    }
}