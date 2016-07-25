using System;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    public class RandomRepairBlessing : RandomStatueAttribute
    {
        public override void DoFunction()
        {
            Repair(RandomEquipmentType());   
        }

        private void Repair(EquipmentType equipmentType)
        {
            GameObject player = GameObject.FindGameObjectWithTag(Tag.Player);

            switch (equipmentType)
            {
                case EquipmentType.Sword:
                    player.GetComponent<Sword>().Repair();
                    break;
                case EquipmentType.Armor:
                    player.GetComponent<Armor>().Repair();
                    break;
                case EquipmentType.Nothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("equipmentType", equipmentType, null);
            }
        }
    }
}