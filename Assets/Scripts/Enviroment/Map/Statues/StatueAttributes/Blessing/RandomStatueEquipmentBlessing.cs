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
        public override void DoFunction(StatuePick statuePick)
        {
            AddRandomBlessing(RandomEquipmentType());
        }

        protected void AddRandomBlessing(EquipmentType equipmentType)
        {
           AddRandomAttribute(item => item.EquipmentAttributeType == EquipmentAttributeType.Blessing &&
                    item.EquipmentType == equipmentType);
        }
    }
}