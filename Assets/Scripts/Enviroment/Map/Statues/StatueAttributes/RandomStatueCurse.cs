using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Extensions;
using Assets.Scripts.Extensions.Enums;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Receiving random curse(Among all curses) on sword or armor.")]
    public class RandomStatueCurse : RandomStatueAttribute
    {
        public override void DoFunction()
        {
            AddRandomCurse(RandomEquipmentType());
        }

        protected void AddRandomCurse(EquipmentType equipmentType)
        {
            List<AttributeInfo> curses =
                _equipmentAttributeAdder.GetAttributeInfos(
                    item => item.EquipmentAttributeType == EquipmentAttributeType.Curse && 
                    item.EquipmentType == equipmentType);

            _equipmentAttributeAdder.AddAttribute(curses.Random().Type);
        }
    }
}
