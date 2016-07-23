using Assets.Scripts.Combat;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Armors
{
    public class ArmorXmlLoader : EquipmentXmlLoader
    {
        public ArmorXmlLoader(EquipmentAttributeManager equipmentAttributeManager, EquipmentAttributeManager swordEquipmentAttributeManager,
            int xmlId, string xmlArrayName) : base(equipmentAttributeManager, xmlId, xmlArrayName)
        {
            XmlLocation = Location.Armor;
            _attributeAdder = new EquipmentAttributeAdder(equipmentAttributeManager);
        }

        public override void Load()
        {
            base.Load();
            AddAttributes<ArmorAttribute>();
        }
    }
}