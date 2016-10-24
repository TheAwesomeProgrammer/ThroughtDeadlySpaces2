using Assets.Scripts.Camera_ll_UI;
using UnityEngine;
using XmlLibrary;

namespace Assets.Scripts.Shop.Merchant
{
    public abstract class ShopItem : MonoBehaviour, XmlLoadable
    {
        public int MoneySpecId;
        public string XmlShopName = "Merchant";

        public int Money { get; set; }

        private XmlPath _merchantPath;

        void Start()
        {
            _merchantPath = new DefaultXmlPath(XmlLocation.Shop, new XmlPathData(XmlShopName));
            LoadXml();
        }

        public void LoadXml()
        {
            int[] specs = _merchantPath.GetSpecs();
            Money = specs[MoneySpecId];
        }
    }
}