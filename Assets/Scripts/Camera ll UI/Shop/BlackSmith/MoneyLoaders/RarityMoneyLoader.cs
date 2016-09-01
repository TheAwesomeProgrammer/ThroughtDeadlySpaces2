using Assets.Scripts.Player.Equipments;
using XmlLibrary;

namespace Assets.Scripts.Shop.BlackSmith.MoneyLoaders
{
    public abstract class RarityMoneyLoader : XmlLoadable, MoneyLoadable
    {
        public int SpecStartId = 0;

        private XmlPath _blackSmithPath;

        protected int[] _specs;

        protected RarityMoneyLoader()
        {
            _blackSmithPath = new DefaultXmlPath(XmlLocation.Shop, new XmlPathData("BlackSmith"));
            LoadXml();
        }

        public void LoadXml()
        {
            _specs = _blackSmithPath.GetSpecs();
        }

        public int GetMoney(EquipmentRarity equipmentRarity)
        {
            return _specs[SpecStartId + ((int) equipmentRarity - 1)]; // Minus one to go from equipmentRarity enums 1,2,3 system to array 0,1,2,3 system.
        }
    }
}