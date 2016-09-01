using Assets.Scripts.Combat;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using XmlLibrary;

namespace Assets.Scripts.Player.Armors
{
    public class ArmorXmlLoader : EquipmentXmlLoader
    {
        public ArmorXmlLoader(EquipmentAttributeManager equipmentAttributeManager,int xmlId,
            int equipmentId) : base(equipmentAttributeManager, xmlId, equipmentId)
        {
            XmlLocation = XmlLocation.Armor;
            _attributeAdder = new EquipmentAttributeAdder(equipmentAttributeManager, EquipmentType.Armor, equipmentId);
        }

        public override void Load()
        {
            base.Load();
            AddAttributes<ArmorAttribute>();
        }
    }
}