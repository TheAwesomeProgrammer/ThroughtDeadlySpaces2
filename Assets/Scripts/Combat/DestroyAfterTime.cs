using UnityEngine;

namespace Assets.Scripts.Combat
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public float AliveTime;

        void Start()
        {
            Destroy(gameObject, AliveTime);
        }
    }
}