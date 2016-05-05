﻿using Assets.Scripts.Bosses.Abstract;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty
{
    public class BoboSpecsLoader : BossSpecsLoader
    {
        protected override void Awake()
        {
            base.Awake();
            LoadXml();
        }
    }
}