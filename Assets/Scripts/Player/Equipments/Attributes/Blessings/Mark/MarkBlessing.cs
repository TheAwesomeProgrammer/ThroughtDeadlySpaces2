using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    public class MarkBlessing : EquipmentAttribute, XmlAttributeLoadable
    {
        public CombatType CombatType;

        private DamageTrigger _damageTrigger;
        private CombatDamage _combatDamage;
        private Weakness _weakness;
        private int _count;
        private int _timesToAttackEnemy = 5;
        private bool _activated;

        public override AttributeXmlData AttributeXmlData
        {
            get {
                return _attributeXmlData = _attributeXmlData ??
                                          new AttributeXmlData(XmlFileLocations.GetLocation(Location.Blessing), _attributeId,
                                              XmlName.Blessing);
            }
        }

        public override void Init()
        {
            base.Init();
            _attributeId = 9;
            _weakness = GameObject.FindGameObjectWithTag(Tag.Map).GetComponentInChildren<Weakness>();
            _damageTrigger = GetComponent<DamageTrigger>();
            _damageTrigger._newEnemyAdded += OnNewEnemyFound;
        }

        private void OnNewEnemyFound(CombatDamage combatDamage)
        {
            combatDamage.Attacked += OnEnemyAttacked;
        }

        private void OnEnemyAttacked(CombatDamage combatDamage)
        {
            if (enabled)
            {
                if (Equals(combatDamage, _combatDamage))
                {
                    _count++;
                }
                else
                {
                    _count = 0;
                }
                _combatDamage = combatDamage;
                ShouldAddMark();
            }
        }

        private void ShouldAddMark()
        {
            if (_count >= _timesToAttackEnemy && _activated)
            {
                _weakness.Weaknesses.Add(CombatType);
                _activated = false;
            }
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
            _timesToAttackEnemy = specs[0];
        }
    }
}