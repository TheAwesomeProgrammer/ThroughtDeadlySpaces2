using System.Xml;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Xml;
using UnityEngine;
using Assets.Scripts.Combat;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Equipments;

namespace Assets.Scripts.Player.Swords
{
    public sealed class SwordXmlLoader : EquipmentXmlLoader
    {
        public SwordXmlLoader(EquipmentAttributeManager equipmentAttributeManager, int xmlId, string xmlArrayName) : base(equipmentAttributeManager, xmlId, xmlArrayName)
        {
            XmlId = xmlId;
            XmlLocation = Location.Sword;
            XmlArrayName = xmlArrayName;
            _attributeAdder = new EquipmentAttributeAdder(equipmentAttributeManager);
        }

        public override void Load()
        {
            base.Load();
            AddAttributes<SwordAttribute>();
        }
    }
}