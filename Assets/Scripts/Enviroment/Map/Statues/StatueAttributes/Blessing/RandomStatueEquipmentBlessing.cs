using System.Collections.Generic;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Receiving random blessing on sword or armor.")]
    public class RandomStatueEquipmentBlessing : RandomStatueAttribute
    {
        protected override void ChoseRandomStatueAttribute()
        {
            AddRandomBlessing(RandomEquipmentType());
        }

        protected void AddRandomBlessing(EquipmentType equipmentType)
        {
           TryAddRandomAttribute(item => item.EquipmentAttributeType == EquipmentAttributeType.Blessing &&
                    item.EquipmentType == equipmentType);
        }
    }
}