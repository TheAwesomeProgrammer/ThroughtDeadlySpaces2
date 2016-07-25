using System;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    public class StatueSacrifice : MonoBehaviour
    {
        public int AmountToSacrifice;
        public StatueSacrificeType StatueSacrificeType;

        private PlayerProperties _playerProperties;

        void Start()
        {
            _playerProperties = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<PlayerProperties>();
        }

        public void Sacrifice()
        {
            switch (StatueSacrificeType)
            {
                case StatueSacrificeType.Nothing:
                    break;
                case StatueSacrificeType.Dexterity:
                    _playerProperties.SetMaxDexterity(_playerProperties.MaxDexterity - AmountToSacrifice);
                    break;
                case StatueSacrificeType.Speed:
                    _playerProperties.SetSpeed(_playerProperties.Speed - AmountToSacrifice);
                    break;
                case StatueSacrificeType.Health:
                    _playerProperties.SetMaxHealth(_playerProperties.MaxHealth - AmountToSacrifice);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}