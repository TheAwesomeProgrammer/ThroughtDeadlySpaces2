﻿using Assets.Scripts.Managers;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Add money. Amount specified in xml.")]
    public sealed class StatueMoneyLoader : StatueAttribute, XmlLoadable
    {
        private int _moneyToLoad = 100;

        public StatueMoneyLoader()
        {
            LoadXml();
        }

        public void DoFunction()
        {
            MoneyManager.Money += _moneyToLoad;
        }

        public void LoadXml()
        {

        }
    }
}