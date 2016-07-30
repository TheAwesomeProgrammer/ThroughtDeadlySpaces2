using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class BrokenSwordCurse : BaseDamageModifier, XmlAttributeLoadable
    {
        public int BrokenSwordMinusProcentDamage = -40;
        public const int CurseId = 0;

        private EquipmentAttributeLoader _equipmentAttributeLoader;

        public override DamageData ModifydamageData(DamageData damageData)
        {
            return new BaseDamageData(MathHelper.GetValueMultipliedWithProcent(damageData.Damage, BrokenSwordMinusProcentDamage));
        }

        public void LoadXml(int level)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(XmlFileLocations.GetLocation(Location.Curse));
            int[] specs = _equipmentAttributeLoader.LoadSpecs(CurseId, level, XmlName.Curses);
            BrokenSwordMinusProcentDamage = specs[0];
        }
    }
}