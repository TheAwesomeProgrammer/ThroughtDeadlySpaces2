using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack.Projectile.DataSetters
{
    public class BeamSetStartDelay : SetableData
    {
        public void Execute(GameObject projectileObject, ProjectileData projectileData)
        {
            BeamProjectile beamProjectile = projectileObject.GetComponent<BeamProjectile>();
            var beamData = projectileData as BeamData;
            if (beamData != null)
            {
                beamProjectile.StartDelay = beamData.StartDelay;
            }
        }
    }
}