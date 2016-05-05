using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack.Projectile.DataSetters
{
    public interface SetableData
    {
        void Execute(GameObject projectileObject, ProjectileData projectileData);
    }
}