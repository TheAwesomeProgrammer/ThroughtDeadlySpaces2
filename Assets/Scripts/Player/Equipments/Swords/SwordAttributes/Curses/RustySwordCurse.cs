using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Shop;
using XmlLibrary;
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


        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlLocation.Curse, CurseId);
            }
        }

        public override void Init()
        {
            base.Init();
            ModifierType = ModifierType.Base;
            transform.root.GetComponentInChildren<SwordAttack>().AttackStarted += OnAttacking;
            _equipmentAttributeManager = GetComponent<EquipmentAttributeManager>();
        }
        
        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
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