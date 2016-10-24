using System;
using System.Collections.Generic;
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
    public abstract class RandomStatueAttribute : StatueAttribute
    {
        protected EquipmentAttributeAdder _equipmentAttributeAdder;
        protected Sword _sword;
        protected Armor _armor;
        protected StatuePick _statuePick;
        private EquipmentAttributeManager _equipmentAttributeManager;

        protected RandomStatueAttribute()
        {
            _equipmentAttributeManager =
                GameObject.FindGameObjectWithTag(Tag.Player)
                    .GetComponentInChildren<EquipmentAttributeManager>();
            _equipmentAttributeAdder = new EquipmentAttributeAdder(_equipmentAttributeManager, EquipmentType.SwordOrArmor);
            _sword = GameObject.FindGameObjectWithTag(Tag.Player).GetComponentInChildren<Sword>();
            _armor = GameObject.FindGameObjectWithTag(Tag.Player).GetComponentInChildren<Armor>();
        }

        public void DoFunction(StatuePick statuePick)
        {
            _statuePick = statuePick;
            ChoseRandomStatueAttribute();
        }

        protected abstract void ChoseRandomStatueAttribute();

        protected EquipmentType RandomEquipmentType()
        {
            EquipmentType equipmentType = EquipmentType.Armor;
            return (EquipmentType) Random.Range(0, equipmentType.Length());
        }

        protected void TryAddRandomAttribute(Predicate<AttributeInfo> predicate)
        {
            AttributeInfo randomAttributeInfo = GetRandomAttributeInfo(predicate);
            if (DoesAttributeExist(randomAttributeInfo))
            {
                ChoseRandomStatueAttribute();
            }
            else
            {
                _equipmentAttributeAdder.EquipmentType = randomAttributeInfo.EquipmentType;
                AddRandomAttribute(randomAttributeInfo.Type);
            }
            
        }

        private void AddRandomAttribute(Type attributeType)
        {
            _equipmentAttributeAdder.AddAttribute(attributeType);
        }

        private AttributeInfo GetRandomAttributeInfo(Predicate<AttributeInfo> predicate)
        {
            List<AttributeInfo> attributes =
               _equipmentAttributeAdder.GetAttributeInfos(predicate);

            return attributes.Random();
        }



        protected bool DoesAttributeExist(AttributeInfo attributeInfo)
        {
            Type attributeType = attributeInfo.Type;
            switch (attributeInfo.EquipmentType)
            {
                case EquipmentType.Sword:
                    return DoesAttributeExistOn(_sword.gameObject, attributeType);
                case EquipmentType.Armor:
                    return DoesAttributeExistOn(_armor.gameObject, attributeType);
                default:
                    throw new ArgumentOutOfRangeException("equipmentType", attributeInfo.EquipmentType, null);
            }
        }

        private bool DoesAttributeExistOn(GameObject gameObject, Type typeToCheck)
        {
            return gameObject.GetComponent(typeToCheck) != null;
        }
    }
}