using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [EquipmentAttributeMetaData(EquipmentAttributeType.Blessing)]
    public class RandomRepairBlessing : RandomStatueAttribute
    {
        private List<Type> _equipmentTypes;

        public RandomRepairBlessing()
        {
            _equipmentTypes = new List<Type>();
        }

        public override void DoFunction(StatuePick statuePick)
        {
            _equipmentTypes.Add(typeof(Sword));
            _equipmentTypes.Add(typeof(Armor));
            if (!Repair())
            {
                statuePick.Pick();
            }
        }

        private bool Repair()
        {
            bool repairedEquipment = false;
            for (int i = 0; i < _equipmentTypes.Count; i++)
            {
                Type equipmentType = _equipmentTypes.Random();
                if (RepairEquipment(equipmentType))
                {
                    repairedEquipment = true;
                    break;
                }
                _equipmentTypes.Remove(equipmentType);
            }
            return repairedEquipment;
        }

        private bool RepairEquipment(Type equipmentType)
        {
            GameObject player = GameObject.FindGameObjectWithTag(Tag.Player);
            Equipment equipment = player.GetComponent(equipmentType) as Equipment;
            if (equipment != null && equipment.Damaged)
            {
                equipment.Repair();
                return true;
            }
            return false;
        }
    }
}