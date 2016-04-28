using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Shop.Merchant
{
    public abstract class ShopItem : MonoBehaviour, XmlLoadable
    {
        public int ShopId;
        public string XmlShopName = "Merchant";

        public int Money { get; set; }

        private XmlSearcher _xmlSearcher;

        void Start()
        {
            _xmlSearcher = new XmlSearcher(Location.Shop);
            LoadXml();
        }

        public void LoadXml()
        {
            int[] specs = _xmlSearcher.GetSpecsInChildren("Shop", XmlShopName);
            Money = specs[ShopId];
        }
    }
}