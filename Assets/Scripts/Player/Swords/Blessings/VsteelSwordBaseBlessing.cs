using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class VsteelSwordBaseBlessing : SwordBaseDamageModifier
    {
        public int ProcentChanceOfCriticalHit = 10;
        public int CriticalHitDamageProcent = 50;

        private XmlSearcher _xmlSearcher;

        protected override void Start()
        {
            base.Start();
            LoadSpecs();

        }

        public void LoadSpecs()
        {
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Blessing));
            int[] specs = _xmlSearcher.GetSpecsWithId(0, "Blessings");
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