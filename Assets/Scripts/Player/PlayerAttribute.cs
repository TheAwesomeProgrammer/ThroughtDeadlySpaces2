using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    public abstract class PlayerAttribute : MonoBehaviour
    {
        protected virtual void Start()
        {
            OnActivate();
        }

        public abstract void OnActivate();
    }
}