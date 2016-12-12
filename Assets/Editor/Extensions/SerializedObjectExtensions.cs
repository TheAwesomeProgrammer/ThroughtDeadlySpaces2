using System.Collections.Generic;
using UnityEditor;

namespace Assets.Editor
{
    public static class SerializedObjectExtensions
    {
        public static List<string> GetStringList(this SerializedObject serializedProperty, string propertyName)
        {
            SerializedProperty stringArray = serializedProperty.FindProperty(propertyName);
            List<string> strings = new List<string>();
            for (int i = 0; i < stringArray.arraySize; i++)
            {
                strings.Add(stringArray.GetArrayElementAtIndex(i).stringValue);
            }

            return strings;
        }
    }
}