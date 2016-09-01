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
    public class ArmorEnchantedBlessing : EquipmentAttribute, XmlAttributeLoadable, CombatModifier
    {
        private int _enchantedChance = 0;
        private int _chantedDefense = 0;
        private const int XmlId = 3;

        private Resistance _resistance;
        private DoubleEnchantChecker _doubleEnchantChecker;

        private bool _enchant;

        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlLocation.Blessing, XmlId);
            }
        }

        public override void Init()
        {
            base.Init();
            ModifierType = ModifierType.All;
            _resistance = GetComponent<Resistance>();
            _resistance.Defending += OnDefending;
            _doubleEnchantChecker = new DoubleEnchantChecker(this);
            _doubleEnchantChecker.Check();
        }

        void OnDefending()
        {
            _enchant = MathHelper.IsBetweenRandomProcentFrom0To100(_enchantedChance);
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
            _enchantedChance = specs[0];
            _chantedDefense = specs[1];
        }

        public CombatData GetModifiedCombatData(CombatData damageData)
        {
            if (_enchant)
            {
                damageData.CombatValue += _chantedDefense;
            }
            return damageData;
        }
    }
}