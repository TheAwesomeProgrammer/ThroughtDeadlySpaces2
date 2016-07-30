using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Swords
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class LethalBlessing : VsteelSwordBaseBlessing
    {
        public override void LoadXml(int level)
        {
            BlessingId = 5;
            base.LoadXml(level);
        }
    }
}