using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class SwordComponent : MonoBehaviour
    {
        protected Sword _sword;

        protected virtual void Start()
        {
            _sword = GetComponent<Sword>();
        }

    }
}