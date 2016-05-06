using Assets.Scripts.Bosses.Bobo_the_mighty.Attacks;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack.Projectile.DataSetters
{
    public class SetMinionBoboDamage : SetableData
    {
        public void Execute(GameObject projectileObject, ProjectileData projectileData)
        {
            BoboMinionExplodeSpawner boboMinionExplodeSpawner = projectileObject.GetComponentInChildren<BoboMinionExplodeSpawner>();
            boboMinionExplodeSpawner.Damage = projectileData.Damage;
        }
    }
}