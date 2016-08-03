using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Camera_ll_UI.Shop.BlackSmith;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop.Merchant;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop.BlackSmith
{
    public class RepairItem : UiItemActive
    {
        public EquipmentType EquipmentType;

        private RepairCostSetter _repairCostSetter;

        void Start()
        {
            _repairCostSetter = new RepairCostSetter(GetComponent<RepairItem>(), transform.FindComponentInChildWithName<Text>("Cost"));
            _repairCostSetter.Set();
        }
    }
}