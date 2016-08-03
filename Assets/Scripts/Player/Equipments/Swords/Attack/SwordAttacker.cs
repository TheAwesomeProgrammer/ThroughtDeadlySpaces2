using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordAttacker : Attacker
    {
        private const float MaxAttackSpeed = 1;
        private const float MinAttackSpeed = 0.276f;

        protected Sword _sword;

        private float _attackSpeed;
        private Animator _animator;

        public float AttackSpeed
        {
            get { return _attackSpeed; }
            set
            {
                _attackSpeed = Mathf.Clamp(value, MinAttackSpeed, MaxAttackSpeed);

                Null.OnNot(_damageTrigger, () => _damageTrigger.AttackSpeed = _attackSpeed);
                Null.OnNot(_animator, () => _animator.SetFloat(_animatorAttackSpeedName, _attackSpeed));
            }
        }

        protected override void Start()
        {
            base.Start();
            _animator = GetComponent<AnimatorTrigger>().Animator;
            _sword = GetComponent<Sword>();
        }
    }
}