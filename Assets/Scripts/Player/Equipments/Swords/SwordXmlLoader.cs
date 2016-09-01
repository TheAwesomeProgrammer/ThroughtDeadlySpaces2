using System.Xml;
using Assets.Scripts.Player.Swords.Abstract;
using XmlLibrary;
using UnityEngine;
using Assets.Scripts.Combat;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Swords
{
    public sealed class SwordXmlLoader : EquipmentXmlLoader
    {
        public SwordXmlLoader(EquipmentAttributeManager equipmentAttributeManager, int xmlId,
            int equipmentId) : 
            base(equipmentAttributeManager, xmlId, equipmentId)
        {
            XmlId = xmlId;
            XmlLocation = XmlLocation.Sword;
            _attributeAdder = new EquipmentAttributeAdder(equipmentAttributeManager, EquipmentType.Sword, equipmentId);
        }

        public override void Load()
        {
            base.Load();
            AddAttributes<SwordAttribute>();
        }
    }
}