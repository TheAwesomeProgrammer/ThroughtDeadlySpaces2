using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Player.Curses;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Attributes.Blessings.Mark
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class MarkDeathBlessing : MarkBlessing
    {
        public override void Init()
        {
            base.Init();
            CombatType = CombatType.Death;
        }
    }
}