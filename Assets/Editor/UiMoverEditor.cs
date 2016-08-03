using Assets.Scripts.Camera_ll_UI.HUD;
using Assets.Scripts.Enviroment.Map.Statues;
using UnityEditor;

namespace Test
{
    [CustomEditor(typeof(UiMover))]
    [CanEditMultipleObjects]
    public class UiMoverEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SwitchType"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}