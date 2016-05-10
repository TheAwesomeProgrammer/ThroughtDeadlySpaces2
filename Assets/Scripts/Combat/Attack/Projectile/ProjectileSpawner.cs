using System.Collections.Generic;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack.Projectile
{
    public class ProjectileSpawner : MonoBehaviour
    {
        public GameObject Projectile;

        protected List<SetableData> _setableDatas = new List<SetableData>();

        public GameObject Spawn(Vector3 spawnPosition, ProjectileData projectileData, params SetableData[] setableDatas)
        {
            GameObject spawnedProjectile = Spawn(spawnPosition);
            _setableDatas.AddRange(setableDatas);

            foreach (var setableData in _setableDatas)
            {
                SetData(setableData, spawnedProjectile, projectileData);
            }
            
            return spawnedProjectile;
        }

        public virtual GameObject Spawn(Vector3 spawnPosition, SetableData setableData, ProjectileData projectileData)
        {
            GameObject spawnedProjectile = Spawn(spawnPosition);
            SetData(setableData, spawnedProjectile, projectileData);
            return spawnedProjectile;
        }

        protected virtual GameObject Spawn(Vector3 spawnPosition)
        {
            return Instantiate(Projectile, spawnPosition, Quaternion.identity) as GameObject;
        }

        private void SetData(SetableData setableData,GameObject spawnedProjectile, ProjectileData projectileData)
        {
            setableData.Execute(spawnedProjectile, projectileData);
        }
    }
}