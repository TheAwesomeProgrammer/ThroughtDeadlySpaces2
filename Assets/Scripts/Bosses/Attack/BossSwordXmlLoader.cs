using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossSwordXmlLoader : EquipmentXmlLoader
    {
        public BossSwordXmlLoader(AttributeManager armorAttributeManager, int xmlId, string xmlArrayName) : base(armorAttributeManager, xmlId, xmlArrayName)
        {
            XmlId = xmlId;
            XmlLocation = Location.Sword;
            XmlArrayName = xmlArrayName;
            _attributeAdder = new SwordAttributeAdder(armorAttributeManager);
        }
    }
}