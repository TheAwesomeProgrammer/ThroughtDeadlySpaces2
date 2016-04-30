using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Shop.Merchant
{
    public abstract class ShopItem : UiItem, XmlLoadable
    {
        public int SpecId;
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
            Money = specs[SpecId];
        }
    }
}