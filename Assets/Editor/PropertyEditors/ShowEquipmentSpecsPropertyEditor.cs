using Assets.Scripts.Camera_ll_UI.HUD;
using UnityEditor;

namespace Test
{
    [CustomEditor(typeof(EquipmentPropertiesStat))]
    [CanEditMultipleObjects]
    public class ShowEquipmentSpecsPropertyEditor : ShowPropertyStatEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("EquipmentType"));
            base.OnInspectorGUI();
        }
    }
}