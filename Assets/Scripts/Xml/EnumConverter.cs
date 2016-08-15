using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Scripts.Extensions.Enums;

namespace Assets.Scripts.Xml
{
	public class Result<T>
	{
		public T Value;
		public bool Succes;

		public Result(T value, bool succes)
		{
			Value = value;
			Succes = succes;
		}

		public void Set(T value, bool succes)
		{
			Succes = succes;
			Value = value;
		}
	}

    public class EnumConverter
    {
        public Dictionary<int, Result<T>> Convert<T>(string[] xmlEnumStrings) where T : IConvertible
        {
            Dictionary<int, Result<T>> enumsSet = new Dictionary<int, Result<T>>();

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            for (int i = 0; i < xmlEnumStrings.Length; i++)
            {
                if (xmlEnumStrings[i].Length > 0)
                {
	                enumsSet.Add(Convert<T>(i, xmlEnumStrings[i]));
                }
            }

            return enumsSet;
        }

	    public KeyValuePair<int, Result<T>> Convert<T>(int index, string xmlEnumString) where T : IConvertible
	    {
		    KeyValuePair<int, Result<T>> enumSet = new KeyValuePair<int, Result<T>>();

			enumSet = new KeyValuePair<int, Result<T>>(index, Convert<T>(xmlEnumString));

		    return enumSet;
	    }

	    public Result<T> Convert<T>(string xmlEnumString) where T : IConvertible
	    {
		    Result<T> result = new Result<T>(default(T), false);
		    xmlEnumString = xmlEnumString.Replace(" ", "");
			UnityEngine.Debug.Log("Enum string name"+xmlEnumString);
		    if (Enum.IsDefined(typeof(T), xmlEnumString))
		    {
			    result.Set((T) Enum.Parse(typeof(T), xmlEnumString), true);
		    }

		    return result;
	    }
    }
}