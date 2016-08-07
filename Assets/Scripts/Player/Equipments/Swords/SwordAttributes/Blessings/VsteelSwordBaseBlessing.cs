using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class VsteelSwordBaseBlessing : EquipmentAttribute, XmlAttributeLoadable, CombatModifier
    {
        public int ProcentChanceOfCriticalHit = 10;
        public int CriticalHitDamageProcent = 50;
        public int BlessingId = 0;

        public override void Init()
        {
            base.Init();
            ModifierType = ModifierType.Base;
        }

        public virtual void LoadXml(int level)
        {
            int[] specs = LoadSpecs(XmlFileLocations.GetLocation(Location.Blessing), BlessingId, level, XmlName.Blessing);
            ProcentChanceOfCriticalHit = specs[0];
            CriticalHitDamageProcent = specs[1];
        }

        private int CalculateCriticalHit(int currentDamage)
        {
            return Mathf.Abs(MathHelper.GetValueMultipliedWithProcent(currentDamage, CriticalHitDamageProcent));
        }

        private bool IsCriticalHit()
        {
            return MathHelper.IsBetweenRandomProcentFrom0To100(ProcentChanceOfCriticalHit);
        }

        public CombatData GetModifiedCombatData(CombatData damageData)
        {
            if (IsCriticalHit())
            {
                damageData.CombatValue = CalculateCriticalHit(damageData.CombatValue);
            }

            return damageData;
        }
    }
}