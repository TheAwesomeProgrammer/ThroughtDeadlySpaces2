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
        public SwordXmlLoader(EquipmentAttributeManager equipmentAttributeManager, int xmlId, string xmlArrayName,
            int equipmentId) : 
            base(equipmentAttributeManager, xmlId, xmlArrayName, equipmentId)
        {
            XmlId = xmlId;
            XmlLocation = Location.Sword;
            XmlArrayName = xmlArrayName;
        }

        public override void Load()
        {
            base.Load();
            AddAttributes<SwordAttribute>();
        }
    }
}