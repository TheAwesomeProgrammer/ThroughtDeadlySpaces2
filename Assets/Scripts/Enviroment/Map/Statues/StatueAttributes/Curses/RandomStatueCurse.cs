using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Receiving random curse(Chosen among all curses)")]
    public class RandomStatueCurse : RandomStatueAttribute
    {
        public override void DoFunction()
        {
            AddRandomCurse();
        }

        protected void AddRandomCurse()
        {
            AddRandomAttribute(item => item.EquipmentAttributeType == EquipmentAttributeType.Curse);
        }
    }
}