using System;
using System.Collections.Generic;
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
        public float Duration = 0.25f;

        public Transform BeamSpawnPoint;

        private Action _callbackAction;
        private ProjectileSpawner _projectileSpawner;

        void Start()
        {
            _projectileSpawner = GetComponent<ProjectileSpawner>();
        }

        public void StartAttack(int damage, float startDelay, Action callbackAction = null)
        {
            _callbackAction = callbackAction;
            GameObject beamProjectileObject = _projectileSpawner.Spawn(BeamSpawnPoint.position,
                new List<SetableData>() { new BossSetExtraBaseDamage(), new BeamSetStartDelay() }, new BeamData(damage, startDelay));

            Destroy(beamProjectileObject, Duration + startDelay);
            Timer.Start(Duration + startDelay, EndAttack);
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