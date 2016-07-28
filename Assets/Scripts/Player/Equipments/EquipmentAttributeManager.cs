﻿using System;
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
    [Serializable]
    public class AttributeData
    {
        public EquipmentAttributeType EquipmentAttributeType;
        public MonoBehaviour Attribute;
        public int Id;

        public AttributeData(int id, EquipmentAttributeType equipmentAttributeType, MonoBehaviour attribute)
        {
            Id = id;
            EquipmentAttributeType = equipmentAttributeType;
            Attribute = attribute;
        }
    }

    public class EquipmentAttributeManager : ComponentManager<MonoBehaviour>
    {
        private List<AttributeData> _attributes = new List<AttributeData>();

        private Sword _mySword
        {
            get { return _sword ?? (_sword = GetComponentInChildren<Sword>()); }
        }

        private Armor _myArmor
        {
            get
            {
                if (_armor == null)
                {
                    _armor = GetComponentInChildren<Armor>();
                }
                return _armor;
            }
        }

        private Sword _sword;
        private Armor _armor;

        public void AddExistingAttribute(int id, EquipmentAttributeType equipmentAttributeType, MonoBehaviour attribute)
        {
            _attributes.Add(new AttributeData(id, equipmentAttributeType, attribute));
            AddExistingComponent(attribute);
        }

        public virtual T AddNewAttribute<T>(int id, EquipmentAttributeType equipmentAttributeType) where T : MonoBehaviour
        {
            var attribute = AddNewComponent<T>();
            AddExistingAttribute(id, equipmentAttributeType, attribute);
            return attribute;
        }

        public T AddNewAttribute<T>(int id, AttributeInfo attributeInfo) where T : MonoBehaviour
        {
            T attribute;
            var equipmentAttributeType = attributeInfo.EquipmentAttributeType;

            switch (attributeInfo.EquipmentType)
            {
                case EquipmentType.Sword:
                    attribute = AddNewComponent<T>(_mySword.gameObject);
                    _attributes.Add(new AttributeData(id, equipmentAttributeType, attribute));
                    break;
                case EquipmentType.Armor:
                    attribute = AddNewComponent<T>(_myArmor.gameObject);
                    _attributes.Add(new AttributeData(id, equipmentAttributeType, attribute));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("equipmentType", attributeInfo.EquipmentType, null);
            }
            return attribute;
        }

        public AttributeData GetAttribute(EquipmentAttributeType equipmentAttributeType)
        {
            return _attributes.ToLookup(attribute => attribute.EquipmentAttributeType).Cast<AttributeData>().First();
        }

        public List<AttributeData> GetAttributes(EquipmentAttributeType equipmentAttributeType)
        {
            return _attributes.ToLookup(attribute => attribute.EquipmentAttributeType).Cast<AttributeData>().ToList();
        }

        public List<AttributeData> GetAttributesById(int id)
        {
            return _attributes.ToLookup(attribute => attribute.Id == id).Cast<AttributeData>().ToList();
        }

        public void RemoveAllWithId(int id)
        {
            _attributes.RemoveAll(item => item.Id == id);
        }

        public void EnableAllWithId(int id)
        {
            SetActiveWithId(id, true);
        }

        public void DisableAllWithId(int id)
        {
            SetActiveWithId(id, false);
        }

        private void SetActiveWithId(int id, bool active)
        {
            List<AttributeData> attributesWithId = _attributes.FindAll(item => item.Id == id);
            attributesWithId.ForEach(item => item.Attribute.enabled = active);
        }
    }
}