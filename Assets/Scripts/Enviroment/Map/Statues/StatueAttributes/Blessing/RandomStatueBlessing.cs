using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Receiving random blessing(Chosen among all blessings)")]
    public class RandomStatueBlessing : RandomStatueAttribute
    {
        public override void DoFunction(StatuePick statuePick)
        {
            AddRandomBlessing();
        }

        protected void AddRandomBlessing()
        {
            AddRandomAttribute(item => item.EquipmentAttributeType == EquipmentAttributeType.Blessing);
        }
    }
}