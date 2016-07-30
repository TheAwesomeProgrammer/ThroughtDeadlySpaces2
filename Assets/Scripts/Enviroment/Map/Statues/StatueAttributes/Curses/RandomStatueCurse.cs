using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Receiving random curse(Chosen among all curses)")]
    public class RandomStatueCurse : RandomStatueAttribute
    {
        protected override void ChoseRandomStatueAttribute()
        {
            AddRandomCurse();
        }

        protected void AddRandomCurse()
        {
            TryAddRandomAttribute(item => item.EquipmentAttributeType == EquipmentAttributeType.Curse);
        }
    }
}