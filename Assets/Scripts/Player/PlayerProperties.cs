using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerProperties : MonoBehaviour
    {
        /// <summary>
        /// Is only for setting start values via unity. Use SetMaxHealth to set it.
        /// </summary>
        public int MaxHealth = 3;
        /// <summary>
        /// Is only for setting start values via unity. Use SetHealth to set it.
        /// </summary>
        public int Health = 3;
        /// <summary>
        /// Is only for setting start values via unity. Use SetSpeed to set it.
        /// </summary>
        public float Speed = 5;
        public float Gravity = 9.82f;
        public int Strength = 0;
        /// <summary>
        /// Is only for setting start values via unity. Use SetMaxDexterity to set it.
        /// </summary>
        public float MaxDexterity = 2;
        /// <summary>
        /// Is only for setting start values via unity. Use SetAttackSpeed to set it.
        /// </summary>
        public float AttackSpeed = 1;

        private Life _life;
        private DexterityFiller _dexterityFiller;
        private PlayerMovement _playerMovement;
        private SwordAttack _swordAttack;

        void Start()
        {
            _playerMovement = GetComponentInChildren<PlayerMovement>();
            _life = GetComponentInChildren<Life>();
            _dexterityFiller = GetComponent<DexterityFiller>();
            _swordAttack = GetComponentInChildren<SwordAttack>();
            SetMaxDexterity(MaxDexterity);
            SetMaxHealth(MaxHealth);
            SetHealth(Health);
            SetSpeed(Speed);
            SetAttackSpeed(AttackSpeed);
        }

        public void SetSpeed(float newSpeed)
        {
            Speed = newSpeed;
            _playerMovement.Speed = newSpeed;
        }

        public void SetHealth(int newHealth)
        {
            Health = newHealth;
            _life.Health = newHealth;
        }

        public void SetMaxHealth(int newMaxHealth)
        {
            MaxHealth = newMaxHealth;
            _life.MaxHealth = newMaxHealth;
        }

        public void SetMaxDexterity(float newDexterity)
        {
            MaxDexterity = newDexterity;
            _dexterityFiller.MaxDexterity = newDexterity;
        }

        public void SetAttackSpeed(float newAttackSpeed)
        {
            AttackSpeed = newAttackSpeed;
            _swordAttack.AttackSpeed = AttackSpeed;
        }
    }
}