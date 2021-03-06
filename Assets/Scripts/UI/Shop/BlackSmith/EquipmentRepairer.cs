﻿using System;
using Assets.Scripts.Managers;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop.BlackSmith.MoneyLoaders;
using Assets.Scripts.Shop.Merchant;
using XmlLibrary;
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
            equipment.Repair();
            EquipmentAttributeManager equipmentAttributeManager = equipment.GetComponent<EquipmentAttributeManager>();
            foreach (var attributeData in equipmentAttributeManager.GetAttributes(EquipmentAttributeType.Curse))
            {
                Object.Destroy(attributeData.Attribute);
            }
        }
    }
}