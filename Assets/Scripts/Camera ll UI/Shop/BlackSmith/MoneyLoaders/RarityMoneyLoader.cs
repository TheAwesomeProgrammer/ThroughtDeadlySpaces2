using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Shop.BlackSmith.MoneyLoaders
{
    public abstract class RarityMoneyLoader : XmlLoadable, MoneyLoadable
    {
        public int SpecStartId = 0;

        private XmlSearcher _xmlSearcher;

        protected int[] _specs;

        protected RarityMoneyLoader()
        {
            _xmlSearcher = new XmlSearcher(Location.Shop);
            LoadXml();
        }

        public void LoadXml()
        {
            _specs = _xmlSearcher.GetSpecsInChildren("Shop", "BlackSmith");
        }

        public int GetMoney(EquipmentRarity equipmentRarity)
        {
            return _specs[SpecStartId + ((int) equipmentRarity - 1)]; // Minus one to go from equipmentRarity enums 1,2,3 system to array 0,1,2,3 system.
        }
    }
}