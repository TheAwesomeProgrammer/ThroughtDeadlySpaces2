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
        private CapsuleCollider _capsuleCollider;

        private void Start()
        {
            GetComponents();
            _setCapsuleCollider.Start(); // Called before target player, because some stuff needs to be loaded.
            TargetPlayer();

            Timer.Start(gameObject, StartDelay, DelayedStart);
        }

        private void TargetPlayer()
        {
            _fxDirectionSetter.SetPositonToTarget(GameObject.FindWithTag(Tag.PlayerCollision).transform.position);
            _setCapsuleCollider.TargetPlayer();
            _followTarget.target = GameObject.FindWithTag(Tag.BeamSpawn).transform;
        }

        private void GetComponents()
        {
            _pkfxFx = GetComponent<PKFxFX>();
            _setCapsuleCollider = GetComponentInChildren<SetCapsuleCollider>();
            _capsuleCollider = GetComponentInChildren<CapsuleCollider>();
            _bossAttack = GetComponentInChildren<BossAttack>();
            _fxDirectionSetter = GetComponent<FxDirectionSetter>();
            _followTarget = GetComponent<FollowTarget>();
        }

        private void DelayedStart()
        {
            _capsuleCollider.enabled = true;
            _pkfxFx.StartEffect();
            _bossAttack.StartAttack();
            _followTarget.target = null;
        }
    }
}