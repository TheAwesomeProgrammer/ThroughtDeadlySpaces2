using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordAttacker : Attacker
    {
        protected Sword _sword;

        protected override void Start()
        {
            base.Start();
            _sword = GetComponent<Sword>();
        }
    }
}