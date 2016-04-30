using System;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Shop.BlackSmith
{
    public class EquipmentFactory
    {
        public Equipment GetEquipment(EquipmentType equipmentType)
        {
            GameObject player = GameObject.FindWithTag("Player");

            switch (equipmentType)
            {
                case EquipmentType.Sword:
                    return player.GetComponentInChildren<Sword>();
                case EquipmentType.Armor:
                    return player.GetComponentInChildren<Armor>();
                default:
                    throw new ArgumentOutOfRangeException("equipmentType", equipmentType, null);
            }
        }
    }
}