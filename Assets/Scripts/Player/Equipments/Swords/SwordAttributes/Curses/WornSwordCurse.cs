using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class WornSwordCurse : EquipmentAttribute, CombatModifier
    {

        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlFileLocations.GetLocation(Location.Curse), _attributeId,
                                                XmlName.Curses);
            }
        }

        public override void Init()
        {
            base.Init();
            _attributeId = 6;
            ModifierType = ModifierType.Strength;
        }

        public CombatData GetModifiedCombatData(CombatData damageData)
        {
            StrengthDamageData strengthDamageData = damageData as StrengthDamageData;

            Null.OnNot(strengthDamageData, () =>  strengthDamageData.CombatValue = 0);

            return strengthDamageData;
        }
    }
}