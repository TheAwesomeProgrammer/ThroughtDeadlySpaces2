using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Player.Swords.Curses;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public class AttributeData
    {
        public EquipmentAttributeType EquipmentAttributeType;
        public MonoBehaviour Attribute;

        public AttributeData(EquipmentAttributeType equipmentAttributeType, MonoBehaviour attribute)
        {
            EquipmentAttributeType = equipmentAttributeType;
            Attribute = attribute;
        }
    }

    public class EquipmentAttributeManager : ComponentManager<MonoBehaviour>
    {
        private List<AttributeData> _attributes = new List<AttributeData>();
        private Sword _sword;
        private Armor _armor;

        protected override void Start()
        {
            base.Start();
            _sword = GetComponentInChildren<Sword>();
            _armor = GetComponentInChildren<Armor>();
        }

        public void AddExistingAttribute(EquipmentAttributeType equipmentAttributeType, MonoBehaviour attribute)
        {
            _attributes.Add(new AttributeData(equipmentAttributeType, attribute));
            AddExistingComponent(attribute);
        }

        public virtual T AddNewAttribute<T>(EquipmentAttributeType equipmentAttributeType) where T : MonoBehaviour
        {
            T attribute = AddNewComponent<T>();
            _attributes.Add(new AttributeData(equipmentAttributeType, attribute));
            return attribute;
        }

        public T AddNewAttribute<T>(AttributeInfo attributeInfo) where T : MonoBehaviour
        {
            T attribute;
            EquipmentAttributeType equipmentAttributeType = attributeInfo.EquipmentAttributeType;

            switch (attributeInfo.EquipmentType)
            {
                case EquipmentType.Sword:
                    attribute = AddNewComponent<T>(_sword.gameObject);
                    _attributes.Add(new AttributeData(equipmentAttributeType, attribute));
                    break;
                case EquipmentType.Armor:
                    attribute = AddNewComponent<T>(_armor.gameObject);
                    _attributes.Add(new AttributeData(equipmentAttributeType, attribute));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("equipmentType", attributeInfo.EquipmentType, null);
            }
            return attribute;
        }

        public AttributeData GetAttribute(EquipmentAttributeType equipmentAttributeType)
        {
            return _attributes.ToLookup(attribute => attribute.EquipmentAttributeType)[equipmentAttributeType].First();
        }

        public List<AttributeData> GetAttributes(EquipmentAttributeType equipmentAttributeType)
        {
            return _attributes.ToLookup(attribute => attribute.EquipmentAttributeType)[equipmentAttributeType].ToList();
        }
    }
}