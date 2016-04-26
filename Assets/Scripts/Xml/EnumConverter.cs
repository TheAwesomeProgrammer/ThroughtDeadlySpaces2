using System;

namespace Assets.Scripts.Xml
{
    public class EnumConverter
    {
        public T[] Convert<T>(string[] xmlEnumStrings)
        {
            T[] convertedEnums = new T[xmlEnumStrings.Length];

            for (int i = 0; i < xmlEnumStrings.Length; i++)
            {
                convertedEnums[i] = (T)Enum.Parse(typeof(T), xmlEnumStrings[i]);
            }

            return convertedEnums;
        }

    }
}