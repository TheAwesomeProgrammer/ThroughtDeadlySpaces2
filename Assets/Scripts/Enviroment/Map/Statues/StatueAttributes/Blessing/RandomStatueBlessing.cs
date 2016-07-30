using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Receiving random blessing(Chosen among all blessings)")]
    public class RandomStatueBlessing : RandomStatueAttribute
    {
        protected override void ChoseRandomStatueAttribute()
        {
            AddRandomBlessing();
        }

        protected void AddRandomBlessing()
        {
            TryAddRandomAttribute(item => item.EquipmentAttributeType == EquipmentAttributeType.Blessing);
        }
    }
}