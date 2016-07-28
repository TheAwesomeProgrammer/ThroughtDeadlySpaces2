using System;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Equipments
{
    public class EquipmentAttributeMetaData : Attribute
    {
        public EquipmentType? EquipmentType;
        public EquipmentAttributeType EquipmentAttributeType;
        public Type Type;

        public EquipmentAttributeMetaData(EquipmentType equipmentType, EquipmentAttributeType equipmentAttributeType)
        {
            EquipmentType = equipmentType;
            EquipmentAttributeType = equipmentAttributeType;
        }

        public EquipmentAttributeMetaData(EquipmentAttributeType equipmentAttributeType)
        {
            EquipmentType = null;
            EquipmentAttributeType = equipmentAttributeType;
        }
    }
}