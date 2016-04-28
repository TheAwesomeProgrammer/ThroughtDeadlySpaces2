using System;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop.BlackSmith.MoneyLoaders;
using Assets.Scripts.Shop.Merchant;
using Assets.Scripts.Xml;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Shop.BlackSmith
{
    public class EquipmentRepairer : RepairUiElement
    {
        public void ShouldRepair(RepairItem repairItem)
        {
            MoneyLoadable moneyLoadable = _moneyLoaderFactory.GetRarityMoneyLoader(repairItem.EquipmentType);
            Equipment equipment = _equipmentFactory.GetEquipment(repairItem.EquipmentType);
            if (equipment != null && CanRepair(equipment, moneyLoadable.GetMoney(equipment.Specs.EquipmentRarity)))
            {
                Repair(equipment);
            }
        }

        private bool CanRepair(Equipment equipment, int money)
        {
            return equipment.Broken && MoneyManager.Money >= money;
        }

        private void Repair(Equipment equipment)
        {
            equipment.ResetBrokenState();
            AttributeManager attributeManager = equipment.GetComponent<AttributeManager>();
            foreach (var attributeData in attributeManager.GetAttributes(EquipmentAttributeType.Curse))
            {
                Object.Destroy(attributeData.Attribute);
            }
        }
    }
}