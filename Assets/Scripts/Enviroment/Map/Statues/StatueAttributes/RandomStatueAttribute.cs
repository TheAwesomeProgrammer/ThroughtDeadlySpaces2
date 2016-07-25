using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using Assets.Scripts.Extensions.Enums;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    public abstract class RandomStatueAttribute : StatueAttribute
    {
        protected EquipmentAttributeAdder _equipmentAttributeAdder;
        private EquipmentAttributeManager _equipmentAttributeManager;

        protected RandomStatueAttribute()
        {
            _equipmentAttributeManager =
                GameObject.FindGameObjectWithTag(Tag.Player)
                    .GetComponent<EquipmentAttributeManager>();
            _equipmentAttributeAdder = new EquipmentAttributeAdder(_equipmentAttributeManager);
        }

        public abstract void DoFunction(StatuePick statuePick);

        protected EquipmentType RandomEquipmentType()
        {
            EquipmentType equipmentType = EquipmentType.Armor;
            return (EquipmentType) Random.Range(0, equipmentType.Length());
        }

        protected void AddRandomAttribute(Predicate<AttributeInfo> predicate)
        {
            List<AttributeInfo> attributes =
                _equipmentAttributeAdder.GetAttributeInfos(predicate);

            _equipmentAttributeAdder.AddAttribute(attributes.Random().Type);
        }
    }
}