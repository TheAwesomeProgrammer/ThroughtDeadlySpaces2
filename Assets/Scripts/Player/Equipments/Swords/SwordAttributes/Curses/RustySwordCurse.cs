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
    public class RustySwordCurse : EquipmentAttribute, XmlAttributeLoadable, CombatModifier
    {
        public int MinusProcentDamage = -20;
        public int ProcentToBreakSword = 8;
        public const int CurseId = 2;

        private EquipmentAttributeManager _equipmentAttributeManager;

        public override void Init()
        {
            base.Init();
            ModifierType = ModifierType.Base;
            transform.root.GetComponentInChildren<SwordAttack>().AttackStarted += OnAttacking;
            _equipmentAttributeManager = GetComponent<EquipmentAttributeManager>();
        }
        
        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(XmlFileLocations.GetLocation(Location.Curse), CurseId, level, XmlName.Curses);
            MinusProcentDamage = specs[0];
            ProcentToBreakSword = specs[1];
        }

        void OnAttacking()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(ProcentToBreakSword) && !_equipmentAttributeManager.HasComponent<BrokenSwordCurse>())
            {
                _equipmentAttributeManager.AddNewComponent<BrokenSwordCurse>();
            }
        }

        public CombatData GetModifiedCombatData(CombatData damageData)
        {
            damageData.CombatValue = MathHelper.GetValueMultipliedWithProcent(damageData.CombatValue, MinusProcentDamage);
            return damageData;
        }
    }
}