using System;
using System.Collections.Generic;
using Assets.Scripts.Enviroment.Map.Statues;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class AttributeInfo
    {
        public Type Type;
        public EquipmentType EquipmentType;
        public EquipmentAttributeType EquipmentAttributeType;

        public AttributeInfo(Type type, EquipmentType equipmentType, EquipmentAttributeType equipmentAttributeType)
        {
            Type = type;
            EquipmentType = equipmentType;
            EquipmentAttributeType = equipmentAttributeType;
        }

        public AttributeInfo(EquipmentAttributeMetaData equipmentAttributeMetaData, Type type)
        {
            Type = type;
            EquipmentAttributeType = equipmentAttributeMetaData.EquipmentAttributeType;
        }
    }

    public abstract class AttributeAdder
    {
        public List<AttributeInfo> Attributes;

        public abstract MonoBehaviour AddAttribute(Type equipmentAttribute, int level = 1);
        public abstract MonoBehaviour AddAttribute(Enum theEnum, int level = 1);

        protected AttributeAdder()
        {
            Attributes = new List<AttributeInfo>();
        }

        public virtual List<EquipmentAttributeMetaData> GetTypesMatchingCriteria(Predicate<EquipmentAttributeMetaData> predicate)
        {
            List<EquipmentAttributeMetaData> equipmentAttributeMetaDatas = new List<EquipmentAttributeMetaData>();

            foreach (var type in typeof(ScriptAssembly).Assembly.GetTypes())
            {
                if (type.IsDefined(typeof(EquipmentAttributeMetaData), false))
                {
                    foreach (var attributeMetaData in type.GetCustomAttributes(typeof(EquipmentAttributeMetaData), false))
                    {
                        EquipmentAttributeMetaData equipmentAttributeMetaData = attributeMetaData as EquipmentAttributeMetaData;
                        if (predicate(equipmentAttributeMetaData))
                        {
                            equipmentAttributeMetaData.Type = type;
                            equipmentAttributeMetaDatas.Add(equipmentAttributeMetaData);
                        }
                    }
                }
            }

            return equipmentAttributeMetaDatas;
        }

        protected virtual AttributeInfo GetEquipmentAttributeInfo(Type type)
        {
            AttributeInfo attributeInfo = null;

            if ((attributeInfo = GetEquipmentAttributeInfo(type, Attributes)) != null)
            {
                return attributeInfo;
            }

            return attributeInfo;
        }

        private AttributeInfo GetEquipmentAttributeInfo(Type type, List<AttributeInfo> list)
        {
            AttributeInfo attributeInfo = null;

            attributeInfo = list.Find(item => item.Type == type);

            return attributeInfo;
        }

        protected virtual void LoadAttributes(Predicate<EquipmentAttributeMetaData> predicate, List<AttributeInfo> list)
        {
            foreach (var equipmentAttributeMetaData in GetTypesMatchingCriteria(predicate))
            {
                list.Add(new AttributeInfo(equipmentAttributeMetaData, equipmentAttributeMetaData.Type));
            }
        }
    }
}