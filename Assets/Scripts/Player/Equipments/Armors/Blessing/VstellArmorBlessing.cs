using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using XmlLibrary;

namespace Assets.Scripts.Player.Armors.Blessing
{
    [EquipmentAttributeMetaData(EquipmentType.Armor, EquipmentAttributeType.Blessing)]
    public class VstellArmorBlessing : EquipmentAttribute, XmlAttributeLoadable, CombatModifier
    {
        private const int BlessingId = 4;

        private int _changeOfPreventingAllDamage;
        private Resistance _resistance;
        private bool _preventAllDamage;


        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlLocation.Blessing, BlessingId);
            }
        }

        public override void Init()
        {
            base.Init();
            ModifierType = ModifierType.All;
            _resistance = GetComponent<Resistance>();
            _resistance.Defending += OnDefending;
        }

        void OnDefending()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(_changeOfPreventingAllDamage))
            {
                _preventAllDamage = true;
            }
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
            _changeOfPreventingAllDamage = specs[0];
        }

        public CombatData GetModifiedCombatData(CombatData damageData)
        {
            if (_preventAllDamage)
            {
                damageData.CombatValue = int.MaxValue;
            }
            return damageData;
        }
    }
}