using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    public class MarkBlessing : MonoBehaviour
    {
        private const int TimesToAttackEnemy = 5;

        public CombatType CombatType;

        private DamageTrigger _damageTrigger;
        private CombatDamage _combatDamage;
        private Weakness _weakness;
        private int _count;
        private bool _activated;

        public virtual void Start()
        {
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
            if (_count >= TimesToAttackEnemy && _activated)
            {
                _weakness.Weaknesses.Add(CombatType);
                _activated = false;
            }
        }
    }
}