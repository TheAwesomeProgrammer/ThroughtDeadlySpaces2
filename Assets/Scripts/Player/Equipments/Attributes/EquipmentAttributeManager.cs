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
    [Serializable]
    public class AttributeData
    {
        public EquipmentAttributeType EquipmentAttributeType;
        public MonoBehaviour Attribute;
        public int Id;
        public int Level;

        public AttributeData(int id, int level, EquipmentAttributeType equipmentAttributeType, MonoBehaviour attribute)
        {
            Id = id;
            Level = level;
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
            get { return _armor ?? (_armor = GetComponentInChildren<Armor>()); }
        }

        private Sword _sword;
        private Armor _armor;

        public void AddExistingAttribute(int id, EquipmentAttributeType equipmentAttributeType, MonoBehaviour attribute, int level = 1)
        {
            AddAttribute(new AttributeData(id, level, equipmentAttributeType, attribute));
            AddExistingComponent(attribute);
        }

        public virtual T AddNewAttribute<T>(int id, EquipmentAttributeType equipmentAttributeType, int level = 1) where T : MonoBehaviour
        {
            var attribute = AddNewComponent<T>();
            AddExistingAttribute(id, equipmentAttributeType, attribute, level);
            return attribute;
        }

        public T AddNewAttribute<T>(int id, AttributeInfo attributeInfo, int level = 1) where T : MonoBehaviour
        {
            T attribute;
            var equipmentAttributeType = attributeInfo.EquipmentAttributeType;

            switch (attributeInfo.EquipmentType)
            {
                case EquipmentType.Sword:
                    attribute = AddNewComponent<T>(_mySword.gameObject);
                    AddAttribute(new AttributeData(id, level, equipmentAttributeType, attribute));
                    break;
                case EquipmentType.Armor:
                    attribute = AddNewComponent<T>(_myArmor.gameObject);
                    AddAttribute(new AttributeData(id, level, equipmentAttributeType, attribute));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("equipmentType", attributeInfo.EquipmentType, null);
            }
            return attribute;
        }

        public void AddAttribute(AttributeData attributeData)
        {
            XmlAttributeLoadable xmlAttributeLoadable = attributeData.Attribute as XmlAttributeLoadable;
            if (xmlAttributeLoadable != null)
            {
                xmlAttributeLoadable.LoadXml(attributeData.Level);
            }
            _attributes.Add(attributeData);
        }

        public List<AttributeData> GetAllAttributes()
        {
            return _attributes;
        }

        public AttributeData GetAttribute(EquipmentAttributeType equipmentAttributeType)
        {
            return _attributes.ToLookup(attribute => attribute.EquipmentAttributeType)[equipmentAttributeType].First();
        }

        public List<AttributeData> GetAttributes(EquipmentAttributeType equipmentAttributeType)
        {
            return _attributes.ToLookup(attribute => attribute.EquipmentAttributeType)[equipmentAttributeType].ToList();
        }

        public List<AttributeData> GetAttributesById(int id)
        {
            return _attributes.ToLookup(attribute => attribute.Id)[id].ToList();
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