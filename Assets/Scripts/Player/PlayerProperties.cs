﻿using System;
using System.Runtime.Remoting.Messaging;
using Assets.Scripts.Extensions;
using Assets.Scripts.Extensions.StaticClasses;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Player.Swords;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts.Player
{
    public class PlayerProperties : MonoBehaviour
    {
        public int StartMaxHealth;
        public int StartHealth;
        public float StartWalkSpeed;
        public float StartRunSpeed;
        public float StartGravity;
        public int StartStrength;
        public float StartMaxDexterity;
        public float StartDexterity;
        public float StartAttackSpeed;

        private PlayerPropertiesSetter _attackSpeedSetter;
        private PlayerPropertiesSetter _speedSetter;
        private Life _life;
        private DexterityFiller _dexterityFiller;
        private FirstPersonController _firstPersonController;
        private SwordAttack _swordAttack;

        public PlayerPropertiesSetter AttackSpeedSetter
        {
            get
            {
                Null.On(_attackSpeedSetter,
                    () => _attackSpeedSetter = transform.FindComponentInChildWithName<PlayerPropertiesSetter>("AttackSpeedSetter"));
                return _attackSpeedSetter;
            }
        }

        public PlayerPropertiesSetter SpeedSetter
        {
            get
            {
                Null.On(_speedSetter,
                    () => _speedSetter = transform.FindComponentInChildWithName<PlayerPropertiesSetter>("SpeedSetter"));
                return _speedSetter;
            }
        }

        public int MaxHealth
        {
            get
            {
                return Null.OnNot(_life, () => _life.MaxHealth);
            }
            set
            {
                Null.OnNot(_life, () => _life.MaxHealth = value);
            }
        }

        public int Health
        {
            get { return Null.OnNot(_life, () => _life.Health); }
            set
            {
                Null.OnNot(_life, () => _life.Health = value);
            }
        }

        public float WalkSpeed
        {
            get { return Null.OnNot(_firstPersonController, () => _firstPersonController.WalkSpeed); }
            set { Null.OnNot(_firstPersonController, () => _firstPersonController.WalkSpeed = value); }
        }

        public float RunSpeed
        {
            get { return Null.OnNot(_firstPersonController, () => _firstPersonController.RunSpeed); }
            set { Null.OnNot(_firstPersonController, () => _firstPersonController.RunSpeed = value); }
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
            get { return Null.OnNot(_dexterityFiller, () => _dexterityFiller.MaxDexterity); }
            set
            {
                Null.OnNot(_dexterityFiller, () => _dexterityFiller.MaxDexterity = value);
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

        public void Awake()
        {
            _firstPersonController = GetComponentInChildren<FirstPersonController>();
            _life = GetComponentInChildren<Life>();
            _dexterityFiller = GetComponent<DexterityFiller>();
            _swordAttack = GetComponentInChildren<SwordAttack>();
            _swordAttack = GetComponentInChildren<SwordAttack>();
            AttackSpeed = StartAttackSpeed;
            MaxHealth = StartMaxHealth;
            Health = StartHealth;
            Dexterity = StartDexterity;
            MaxDexterity = StartMaxDexterity;
            WalkSpeed = StartWalkSpeed;
            RunSpeed = StartRunSpeed;
            Strength = StartStrength;
            Gravity = StartGravity;
        }
    }
}