using System;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossBeam : MonoBehaviour
    {
        private const float EndDelay = 0.5f;
        private const float StartDelay = 0.5f;

        private SetCapsuleCollider _setCapsuleCollider;
        private CapsuleCollider _capsuleCollider;
        private BossSwordAttack _bossSwordAttack;
        private Transform _startParent;
        private Action _callbackAction;

        void Start()
        {
            _startParent = transform.parent;
            _setCapsuleCollider = GetComponent<SetCapsuleCollider>();
            _bossSwordAttack = GetComponent<BossSwordAttack>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }

        public void OnAttackStarted(Action callbackAction)
        {
            _callbackAction = callbackAction;
            _bossSwordAttack.OnAttackStarting();
            Invoke("StartBeamWithDelay", StartDelay);
        }

        void StartBeamWithDelay()
        {
            transform.parent = null;
            _capsuleCollider.enabled = true;
            _setCapsuleCollider.TargetPlayer();
            Invoke("OnAttackEnded", EndDelay);
        }

        void OnAttackEnded()
        {
            transform.parent = _startParent;
            _bossSwordAttack.OnAttackEnded();
            _capsuleCollider.enabled = false;
            if (_callbackAction != null)
            {
                _callbackAction();
            }
        }
    }
}