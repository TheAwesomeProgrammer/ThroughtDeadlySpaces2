using Assets.Scripts.Managers;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [StatueDescription("Add money. Amount specified in xml.")]
    public class StatueMoneyLoader : MonoBehaviour, StatueAttribute, XmlLoadable
    {
        private int _moneyToLoad;

        public void Start()
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