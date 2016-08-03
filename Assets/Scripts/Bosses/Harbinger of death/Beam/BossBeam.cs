using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using Assets.Scripts.Combat.Attack.Projectile;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossBeam : MonoBehaviour
    {
        public const float Duration = 0.5f;

        public Transform BeamSpawnPoint;

        private Action _callbackAction;
        private BossProjectileSpawner _projectileSpawner;

        void Start()
        {
            _projectileSpawner = GetComponent<BossProjectileSpawner>();
        }

        public void StartAttack(int damage, float startDelay, Action callbackAction = null)
        {
            _callbackAction = callbackAction;
            GameObject beamProjectileObject = _projectileSpawner.Spawn(BeamSpawnPoint.position, new BeamData(damage, startDelay),
                new BeamSetStartDelay());

            Destroy(beamProjectileObject, Duration + startDelay);
            Timer.Start(gameObject, Duration + startDelay, EndAttack);
        }

        public void EndAttack()
        {
            if (_callbackAction != null)
            {
                _callbackAction();
            }
        }
    }
}