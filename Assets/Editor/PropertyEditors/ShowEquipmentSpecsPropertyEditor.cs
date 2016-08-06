using Assets.Scripts.Camera_ll_UI.HUD;
using UnityEditor;

namespace Test
{
    [CustomEditor(typeof(EquipmentSpecsPropertiesStat))]
    [CanEditMultipleObjects]
    public class ShowEquipmentSpecsPropertyEditor : ShowPropertyEditorWithEquipmentType
    {
       
    }
}