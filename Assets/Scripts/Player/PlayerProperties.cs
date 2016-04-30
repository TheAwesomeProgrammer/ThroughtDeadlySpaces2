using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerProperties : MonoBehaviour
    {
        public int MaxHealth = 3;
        public int StartHealth = 3;
        public float Speed = 0;
        public float Gravity = 9.82f;
        public int Strength = 0;
        public float Dexterity = 0;

        private Life _life;
        private SwordAttack _swordAttack;

        void Start()
        {
            _life = GetComponent<Life>();
            _life.MaxHealth = MaxHealth;
            _life.Health = StartHealth;
            _swordAttack = GetComponentInChildren<SwordAttack>();
            _swordAttack.
        }
    }
}