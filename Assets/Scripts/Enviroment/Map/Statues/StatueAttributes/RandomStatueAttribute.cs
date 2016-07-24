using Assets.Scripts.Extensions.Enums;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;

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

        public abstract void DoFunction();

        protected EquipmentType RandomEquipmentType()
        {
            EquipmentType equipmentType = EquipmentType.Armor;
            return (EquipmentType) Random.Range(0, equipmentType.Length());
        }
    }
}