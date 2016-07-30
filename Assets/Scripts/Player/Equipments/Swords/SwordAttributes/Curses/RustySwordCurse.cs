using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class RustySwordCurse : BaseDamageModifier, XmlAttributeLoadable
    {
        public int MinusProcentDamage = -20;
        public int ProcentToBreakSword = 8;
        public const int CurseId = 2;

        private EquipmentAttributeLoader _equipmentAttributeLoader;

        protected override void Start()
        {
            base.Start();
            transform.root.GetComponentInChildren<SwordAttack>().AttackStarted += OnAttacking;
        }

        public void LoadXml(int level)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(XmlFileLocations.GetLocation(Location.Curse));
            int[] specs = _equipmentAttributeLoader.LoadSpecs(CurseId, level, XmlName.Curses);
            MinusProcentDamage = specs[0];
            ProcentToBreakSword = specs[1];
        }

        public override DamageData ModifydamageData(DamageData damageData)
        {
            return new BaseDamageData(MathHelper.GetValueMultipliedWithProcent(damageData.Damage, MinusProcentDamage));
        }

        void OnAttacking()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(ProcentToBreakSword) && !_swordEquipmentAttributeManager.HasComponent<BrokenSwordCurse>())
            {
                _swordEquipmentAttributeManager.AddNewComponent<BrokenSwordCurse>();
            }
        }

    }
}