using Assets.Scripts.Managers;
using UnityEngine;
using XmlLibrary;

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

        public void DoFunction(StatuePick statuePick)
        {
            MoneyManager.Money += _moneyToLoad;
        }

        public void LoadXml()
        {

        }
    }
}