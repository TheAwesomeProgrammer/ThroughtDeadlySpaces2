using Assets.Scripts.Bosses.Harbinger_of_death;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BeamProjectile : MonoBehaviour
    {
        public float StartDelay { get; set; }

        private SetCapsuleCollider _setCapsuleCollider;
        private BossAttack _bossAttack;
        private PKFxFX _pkfxFx;
        private FxDirectionSetter _fxDirectionSetter;
        private FollowTarget _followTarget;

        private void Start()
        {
            _pkfxFx = GetComponent<PKFxFX>();
            _setCapsuleCollider = GetComponentInChildren<SetCapsuleCollider>();
            _bossAttack = GetComponentInChildren<BossAttack>();
            _fxDirectionSetter = GetComponent<FxDirectionSetter>();
            _followTarget = GetComponent<FollowTarget>();
           
            Timer.Start(0.0001f, VerySmallDelayedStart);
            Timer.Start(StartDelay, DelayedStart);
        }

        private void VerySmallDelayedStart()
        {
            _fxDirectionSetter.SetPositonToTarget(GameObject.FindWithTag("Player").transform.position);
            _setCapsuleCollider.TargetPlayer();
            _followTarget.target = GameObject.FindWithTag("BeamSpawn").transform;

        }

        private void DelayedStart()
        {
            _pkfxFx.StartEffect();
            _bossAttack.StartAttack();
            _followTarget.target = null;
        }
    }
}