using System;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossBeam : MonoBehaviour, Attackable
    {
        public float StartDelay = 0.5f;
        public float Duration = 0.5f;

        private SetCapsuleCollider _setCapsuleCollider;
        private CapsuleCollider _capsuleCollider;
        private BossSwordAttack _bossSwordAttack;
        private Transform _startParent;
        private Action _callbackAction;
        private DamageTrigger _damageTrigger;

        public Action CallbackAction
        {
            get { return _callbackAction; }
            set { _callbackAction = value; }
        }

        void Start()
        {
            _startParent = transform.parent;
            _damageTrigger = GetComponent<BossDamageTrigger>();
            _setCapsuleCollider = GetComponent<SetCapsuleCollider>();
            _bossSwordAttack = GetComponent<BossSwordAttack>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }

        public void StartAttack()
        {
            _bossSwordAttack.StartAttack();
            _setCapsuleCollider.TargetPlayer();
            transform.localPosition = Vector3.zero;
            transform.parent = null;
            Invoke("StartBeamWithDelay", StartDelay);
        }

        void StartBeamWithDelay()
        {
            _capsuleCollider.enabled = true;
            Invoke("EndAttack", Duration);
        }

        public void EndAttack()
        {
            transform.parent = _startParent;
            _bossSwordAttack.EndAttack();
            _capsuleCollider.enabled = false;
            if (_callbackAction != null)
            {
                _callbackAction();
            }
        }

        public void IsAttacking()
        {
            
        }

        public void DeativateAttack()
        {
            _damageTrigger.enabled = false;
        }

        public void EnableAttack()
        {
            _damageTrigger.enabled = true;
        }
    }
}