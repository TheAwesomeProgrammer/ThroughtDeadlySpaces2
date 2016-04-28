using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Player.Swords.Abstract;
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

    public class AttributeManager : ComponentManager<MonoBehaviour>
    {
        private List<AttributeData> Attributes = new List<AttributeData>();

        public void AddExistingAttribute(EquipmentAttributeType equipmentAttributeType,MonoBehaviour attribute)
        {
            Attributes.Add(new AttributeData(equipmentAttributeType, attribute));
            AddExistingComponent(attribute);
        }

        public T AddNewAttribute<T>(EquipmentAttributeType equipmentAttributeType) where T : MonoBehaviour
        {
            T attribute = AddNewComponent<T>();
            Attributes.Add(new AttributeData(equipmentAttributeType, attribute));
            return attribute;
        }

        public AttributeData GetAttribute(EquipmentAttributeType equipmentAttributeType)
        {
            return Attributes.ToLookup(attribute => attribute.EquipmentAttributeType)[equipmentAttributeType].First();
        }

        public List<AttributeData> GetAttributes(EquipmentAttributeType equipmentAttributeType)
        {
            return Attributes.ToLookup(attribute => attribute.EquipmentAttributeType)[equipmentAttributeType].ToList();
        }
    }
}