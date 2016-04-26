﻿using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordBrokenState : MonoBehaviour
    {
        public int SwordHitsForBrokenSword = 50;

        protected int _swordState;

        void Start()
        {
            _swordState = SwordHitsForBrokenSword;
        }

        void OnSwordHit()
        {
            _swordState--;
        }
    }
}