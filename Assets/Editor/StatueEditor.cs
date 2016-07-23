using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEditor;
using Assets.Scripts.Enviroment.Map.Statues;


namespace Test
{
    [CustomEditor(typeof(Statue))]
    [CanEditMultipleObjects]
    public class StatueEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            Show(serializedObject.FindProperty("StatueDatas"), ShowPopupBox);
            serializedObject.ApplyModifiedProperties();
        }

        public void ShowPopupBox(SerializedProperty statue, int index)
        {
            if (statue.isExpanded)
            {
                EditorGUI.indentLevel += 1;
                SerializedProperty statueAttributeNamesProperty = statue.FindPropertyRelative("StatueAttributeNames");
                List<string> statueAttributes = new List<string>();
                for (int i = 0; i < statueAttributeNamesProperty.arraySize; i++)
                {
                    statueAttributes.Add(statueAttributeNamesProperty.GetArrayElementAtIndex(i).stringValue);
                }
                SerializedProperty statueIndexProperty = statue.FindPropertyRelative("AttributeIndex");
                statueIndexProperty.intValue = EditorGUILayout.Popup(statueIndexProperty.intValue, statueAttributes.ToArray());
                EditorGUI.indentLevel -= 1;
            }
        }

        public static void Show(SerializedProperty list, Action<SerializedProperty, int> onShowArrayElement = null)
        {
            EditorGUILayout.PropertyField(list);
            EditorGUI.indentLevel += 1;
            if (list.isExpanded)
            {
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
                for (int i = 0; i < list.arraySize; i++)
                {
                    SerializedProperty arrayElement = list.GetArrayElementAtIndex(i);
                    EditorGUILayout.PropertyField(arrayElement,  true);
                    if (onShowArrayElement != null)
                    {
                        onShowArrayElement(arrayElement, i);
                    }
                }
            }
            EditorGUI.indentLevel -= 1;
        }
    }
}

