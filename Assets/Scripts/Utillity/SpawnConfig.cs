using UnityEngine;

namespace Assets.Scripts.Utillity
{
    [System.Serializable]
    public class SpawnConfig
    {
        public Vector3 Offset
        {
            get
            {
                Collider collider = SpawnObject.GetComponentInChildren<Collider>();
                return collider.bounds.size;
            }
        }

        public GameObject SpawnObject;
        public int NumberOfObjectsToSpawn;
        public bool SpawnOnStart;
        public Transform StartSpawnPos;
        public Transform Parent;

        public GameObject Spawn(Vector3 position, Transform currentParent = null)
        {
            return GetSpawnedObject(position, Parent ?? currentParent);
        }

        private GameObject GetSpawnedObject(Vector3 position, Transform parent)
        {
            return Parent != null ? SpawnWithParent(position, parent) : SpawnWithoutParent(position);
        }

        private GameObject SpawnWithParent(Vector3 position, Transform parent)
        {
            GameObject spawnedObject = Object.Instantiate(SpawnObject, parent, false) as GameObject;
            spawnedObject.transform.position = position;
            return spawnedObject;
        }

        private GameObject SpawnWithoutParent(Vector3 position)
        {
            return Object.Instantiate(SpawnObject, position, Quaternion.identity) as GameObject;
        }
    }
}