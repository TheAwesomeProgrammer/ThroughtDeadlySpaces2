using Assets.Scripts.Combat;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Armors
{
    public class ArmorXmlLoader : EquipmentXmlLoader
    {
        public ArmorXmlLoader(AttributeManager armorAttributeManager, AttributeManager swordAttributeManager,
            int xmlId, string xmlArrayName) : base(armorAttributeManager, xmlId, xmlArrayName)
        {
            XmlLocation = Location.Armor;
            _attributeAdder = new ArmorAttributeAdder(armorAttributeManager, swordAttributeManager);
        }

        public override void Load()
        {
            base.Load();
            AddAttributes<ArmorAttribute>();
        }
    }
}