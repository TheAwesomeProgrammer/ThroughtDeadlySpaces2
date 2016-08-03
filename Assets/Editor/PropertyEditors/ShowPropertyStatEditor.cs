using System.Collections.Generic;
using Assets.Scripts.Camera_ll_UI.HUD;
using Assets.Scripts.Enviroment.Map.Statues;
using Assets.Scripts.Player;
using UnityEditor;

namespace Test
{
    [CustomEditor(typeof(PropertyStat), true)]
    [CanEditMultipleObjects]
    public class ShowPropertyStatEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ShowPopupBox();
            serializedObject.ApplyModifiedProperties();
        }

        public void ShowPopupBox()
        {
            SerializedProperty index = serializedObject.FindProperty("Index");
            index.intValue = EditorGUILayout.Popup(index.intValue, GetStringList(serializedObject, "Properties").ToArray());
        }

        protected List<string> GetStringList(SerializedObject serializedProperty, string propertyName)
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