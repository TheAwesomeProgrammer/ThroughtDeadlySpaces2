using System;
using System.Collections.Generic;

namespace Assets.Scripts.Xml
{
    public class EnumConverter
    {
        public Dictionary<int, T> Convert<T>(string[] xmlEnumStrings) where T : IConvertible
        {
            Dictionary<int, T> enumsSet = new Dictionary<int, T>();

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            for (int i = 0; i < xmlEnumStrings.Length; i++)
            {
                if (xmlEnumStrings[i].Length > 0)
                {
                    if (Enum.IsDefined(typeof(T), xmlEnumStrings[i]))
                    {
                        enumsSet.Add(i, (T) Enum.Parse(typeof(T), xmlEnumStrings[i]));
                    }
                }
            }

            return enumsSet;
        }
    }
}