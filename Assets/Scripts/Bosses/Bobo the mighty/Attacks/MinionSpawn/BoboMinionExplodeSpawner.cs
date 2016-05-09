﻿using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Attack.Projectile;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboMinionExplodeSpawner : CollisionChecking
    {
        public int Damage { get; set; }

        private const float StartInvinsibleTime = 2;

        private ProjectileSpawner _projectileSpawner;
        private Life _life;
        private bool _canExplode;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
            Tags.Add("EnemyCollision");

            _projectileSpawner = GetComponent<ProjectileSpawner>();
            _life = GetComponent<Life>();
            _life.Death += SpawnExplosion;
            Timer.Start(StartInvinsibleTime, () => _canExplode = true);
        }

        public override void OnEnterWithTag()
        {
            if (_canExplode)
            {
                base.OnEnterWithTag();
                _life.Die();
            }
        }

        public override void OnStayWithTag()
        {
            if (_canExplode)
            {
                base.OnStayWithTag();
                _life.Die();
            }
        }

        void SpawnExplosion()
        {
            _projectileSpawner.Spawn(transform.position, new BossSetExtraBaseDamage(), new ProjectileData(Damage));
        }
    }
}