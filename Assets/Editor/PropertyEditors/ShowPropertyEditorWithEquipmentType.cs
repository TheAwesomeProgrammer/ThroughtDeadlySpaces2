using UnityEditor;

namespace Test
{
    public abstract class ShowPropertyEditorWithEquipmentType : ShowPropertyStatEditor
    {
        public override void OnInspectorGUI()
        {
            ShowEquipmentType();
            base.OnInspectorGUI();
        }

        protected virtual void ShowEquipmentType()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("EquipmentType"));
        }
    }
}