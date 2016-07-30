using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class VsteelSwordBaseBlessing : BaseDamageModifier, XmlAttributeLoadable
    {
        public int ProcentChanceOfCriticalHit = 10;
        public int CriticalHitDamageProcent = 50;
        public int BlessingId = 0;

        private EquipmentAttributeLoader _equipmentAttributeLoader;

        public virtual void LoadXml(int level)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(XmlFileLocations.GetLocation(Location.Blessing));
            int[] specs = _equipmentAttributeLoader.LoadSpecs(BlessingId, level, XmlName.Blessing);
            ProcentChanceOfCriticalHit = specs[0];
            CriticalHitDamageProcent = specs[1];
        }

        public override DamageData ModifydamageData(DamageData damageData)
        {
            if (IsCriticalHit())
            {
                return  new BaseDamageData(CalculateCriticalHit(damageData.Damage));
            }

            return damageData;
        }


        private int CalculateCriticalHit(int currentDamage)
        {
            return Mathf.Abs(MathHelper.GetValueMultipliedWithProcent(currentDamage, CriticalHitDamageProcent));
        }

        private bool IsCriticalHit()
        {
            return MathHelper.IsBetweenRandomProcentFrom0To100(ProcentChanceOfCriticalHit);
        }
    }
}