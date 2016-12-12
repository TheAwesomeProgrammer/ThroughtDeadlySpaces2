using System.Collections.Generic;
using UnityEditor;

namespace Assets.Editor
{
    public static class SerializedPropertyExtensions
    {
        public static List<string> GetStringList(this SerializedProperty serializedProperty)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < serializedProperty.arraySize; i++)
            {
                strings.Add(serializedProperty.GetArrayElementAtIndex(i).stringValue);
            }

            return strings;
        }
    }
}