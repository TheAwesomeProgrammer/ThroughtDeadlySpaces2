using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop.BlackSmith;
using Assets.Scripts.Shop.BlackSmith.MoneyLoaders;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.Shop.BlackSmith
{
    public class RepairCostSetter : RepairUiElement
    {
        private RepairItem _repairItem;
        private Text _text;

        public RepairCostSetter(RepairItem repairItem, Text text)
        {
            _repairItem = repairItem;
            _text = text;
        }

        public void Set()
        {
            Equipment equipment = _equipmentFactory.GetEquipment(_repairItem.EquipmentType);
            MoneyLoadable moneyLoadable = _moneyLoaderFactory.GetRarityMoneyLoader(_repairItem.EquipmentType);
            _text.text = moneyLoadable.GetMoney(equipment.Specs.EquipmentRarity).ToString();
        }
    }
}