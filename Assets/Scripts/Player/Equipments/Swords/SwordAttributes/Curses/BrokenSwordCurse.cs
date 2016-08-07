using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class BrokenSwordCurse : EquipmentAttribute, XmlAttributeLoadable, CombatModifier
    {
        public int BrokenSwordMinusProcentDamage = -40;
        public const int CurseId = 0;

        private EquipmentAttributeLoader _equipmentAttributeLoader;

        public override void Init()
        {
            base.Init();
            ModifierType = ModifierType.Base;
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(XmlFileLocations.GetLocation(Location.Curse), CurseId, level, XmlName.Curses);
            BrokenSwordMinusProcentDamage = specs[0];
        }

        public CombatData GetModifiedCombatData(CombatData damageData)
        {
            damageData.CombatValue = MathHelper.GetValueMultipliedWithProcent(damageData.CombatValue,
                BrokenSwordMinusProcentDamage);
            return damageData;
        }
    }
}