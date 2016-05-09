using System;
using Assets.Scripts.Bosses.Bobo_the_mighty.Attacks.AcidSpit;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class AcidSpitChecker : MonoBehaviour
    {
        private const int BehindAngle = 90;

        private Transform _playerTransform;
        private Transform _bossTransform;
        private float _bossForwardAngle;
        private float _angleToPlayer;
        private BossStateMachine _boboTheMighty;
        private BossAttackChoserBase _boboAttackChoser;
        private float _angleBetween;

        void Start()
        {
            _bossTransform = GameObject.FindWithTag("Monster").transform.FindChildByTag("EnemyCollision");
            _boboTheMighty = GameObject.FindWithTag("Monster").GetComponent<BossStateMachine>();
            _playerTransform = GameObject.FindWithTag("Player").transform;
            _boboAttackChoser = GetComponent<BossAttackChoserBase>();
            _boboTheMighty.ChangingState += OnChangingState;
        }

        void OnChangingState(Enum previusState, Enum newState)
        {
            if (previusState != null)
            {
                if (IsPlayerBehindBoss() && (BoboState)previusState == BoboState.Idle && (BoboState)newState != BoboState.AcidSpit &&
               _boboAttackChoser.PlayerInRange)
                {
                    _boboTheMighty.ChangeState(BoboState.AcidSpit);
                    _boboTheMighty.CancelStateChanging();
                }
            }
        }

        private bool IsPlayerBehindBoss()
        {
            CalculateAngles();
            return _angleBetween > BehindAngle;
        }

        private void CalculateAngles()
        {
            _angleBetween = Vector3.Angle(_bossTransform.forward, _playerTransform.position - _bossTransform.position);
        }
    }
}