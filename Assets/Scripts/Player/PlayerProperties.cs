using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerProperties : MonoBehaviour
    {
        public int MaxHealth = 3;
        public int StartHealth = 3;
        public float Speed = 5;
        public float Gravity = 9.82f;
        public int Strength = 0;
        public float MaxDexterity = 2;

        private Life _life;
        private DexterityFiller _dexterityFiller;

        void Start()
        {
            _life = GetComponentInChildren<Life>();
            _life.MaxHealth = MaxHealth;
            _life.Health = StartHealth;
            _dexterityFiller = GetComponent<DexterityFiller>();
            _dexterityFiller.MaxDexterity = MaxDexterity;

        }
    }
}