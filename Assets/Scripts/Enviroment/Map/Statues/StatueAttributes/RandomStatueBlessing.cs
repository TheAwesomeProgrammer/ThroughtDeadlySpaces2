using System.Collections.Generic;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Receiving random blessing(Among all blessings) on sword or armor.")]
    public class RandomStatueBlessing : RandomStatueAttribute
    {
        public override void DoFunction()
        {
            AddRandomBlessing(RandomEquipmentType());
        }

        protected void AddRandomBlessing(EquipmentType equipmentType)
        {
            List<AttributeInfo> curses =
                _equipmentAttributeAdder.GetAttributeInfos(
                    item => item.EquipmentAttributeType == EquipmentAttributeType.Blessing &&
                    item.EquipmentType == equipmentType);

            _equipmentAttributeAdder.AddAttribute(curses.Random().Type);
        }
    }
}