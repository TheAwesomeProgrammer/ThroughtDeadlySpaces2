using System;
using System.Runtime.Remoting.Messaging;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords;
using UnityEngine;
using Vexe.Runtime.Types;

namespace Assets.Scripts.Player
{
    public class PlayerProperties : MonoBehaviour
    {
        public int StartMaxHealth;
        public int StartHealth;
        public float StartSpeed;
        public float StartGravity;
        public int StartStrength;
        public float StartMaxDexterity;
        public float StartDexterity;
        public float StartAttackSpeed;

        public int MaxHealth
        {
            get { return _life.MaxHealth; }
            set
            {
                _life.MaxHealth = value;
            }
        }

        public int Health
        {
            get { return _life.Health; }
            set
            {
                _life.Health = value;
            }
        }

        public float Speed
        {
            get { return Null.OnNot(_playerMovement, () => _playerMovement.Speed); }
            set { Null.OnNot(_playerMovement, () => _playerMovement.Speed = value); }
        }

        public float Gravity
        {
            get { return StartGravity; }
            set
            {
                StartGravity = value;
            }
        }

        public int Strength
        {
            get { return StartStrength; }
            set
            {
                StartStrength = value;
            }
        }

        public float MaxDexterity
        {
            get { return _dexterityFiller.MaxDexterity; }
            set
            {
                _dexterityFiller.MaxDexterity = value;
            }
        }

        public float AttackSpeed
        {
            get
            {
                return Null.OnNot(_swordAttack, () => _swordAttack.AttackSpeed);
            }
            set { Null.OnNot(_swordAttack, () => _swordAttack.AttackSpeed = value); }
        }

        public float Dexterity
        {
            get { return _dexterityFiller.Dexterity; }
            set
            {
                _dexterityFiller.Dexterity = value;
            }
        }

        private Life _life;
        private DexterityFiller _dexterityFiller;
        private PlayerMovement _playerMovement;
        private SwordAttack _swordAttack;

        public void Start()
        {
            _playerMovement = GetComponentInChildren<PlayerMovement>();
            _life = GetComponentInChildren<Life>();
            _dexterityFiller = GetComponent<DexterityFiller>();
            _swordAttack = GetComponentInChildren<SwordAttack>();
            AttackSpeed = StartAttackSpeed;
            MaxHealth = StartMaxHealth;
            Health = StartHealth;
            Dexterity = StartDexterity;
            MaxDexterity = StartMaxDexterity;
            Speed = StartSpeed;
            Strength = StartStrength;
            Gravity = StartGravity;
        }
    }
}