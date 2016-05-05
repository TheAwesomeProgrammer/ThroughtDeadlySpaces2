using System.Collections.Generic;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack.Projectile
{
    public class ProjectileSpawner : MonoBehaviour
    {
        public GameObject Projectile;

        public GameObject Spawn(Vector3 spawnPosition, List<SetableData> setableDatas, ProjectileData projectileData)
        {
            GameObject spawnedProjectile = Spawn(spawnPosition);

            foreach (var setableData in setableDatas)
            {
                SetData(setableData, spawnedProjectile, projectileData);
            }
            
            return spawnedProjectile;
        }

        public GameObject Spawn(Vector3 spawnPosition, SetableData setableData, ProjectileData projectileData)
        {
            GameObject spawnedProjectile = Spawn(spawnPosition);
            SetData(setableData, spawnedProjectile, projectileData);
            return spawnedProjectile;
        }

        private GameObject Spawn(Vector3 spawnPosition)
        {
            return Object.Instantiate(Projectile, spawnPosition, Quaternion.identity) as GameObject;
        }

        private void SetData(SetableData setableData,GameObject spawnedProjectile, ProjectileData projectileData)
        {
            setableData.Execute(spawnedProjectile, projectileData);
        }
    }
}