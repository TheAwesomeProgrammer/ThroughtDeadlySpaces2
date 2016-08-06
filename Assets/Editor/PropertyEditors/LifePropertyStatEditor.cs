using Assets.Scripts.Camera_ll_UI.HUD;
using UnityEditor;

namespace Test
{
    [CustomEditor(typeof(LifePropertyStat))]
    [CanEditMultipleObjects]
    public class LifePropertyStatEditor : ShowPropertyStatEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("LifeTag"));
            base.OnInspectorGUI();
        }
    }
}