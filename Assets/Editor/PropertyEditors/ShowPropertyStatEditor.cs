using System.Collections.Generic;
using Assets.Editor;
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
            index.intValue = EditorGUILayout.Popup(index.intValue, serializedObject.GetStringList("Properties").ToArray());
        }
    }
}