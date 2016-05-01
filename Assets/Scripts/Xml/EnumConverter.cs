using System;

namespace Assets.Scripts.Xml
{
    public class EnumConverter
    {
        public T[] Convert<T>(string[] xmlEnumStrings) where T : IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            T[] convertedEnums = new T[xmlEnumStrings.Length];

            for (int i = 0; i < xmlEnumStrings.Length; i++)
            {
                if (xmlEnumStrings[i].Length > 0)
                {
                    convertedEnums[i] = (T)Enum.Parse(typeof(T), xmlEnumStrings[i]);
                }                
            }

            return convertedEnums;
        }

    }
}