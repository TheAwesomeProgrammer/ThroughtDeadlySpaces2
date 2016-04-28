using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Armor.ArmorModifier;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Armor.Blessing
{
    public class ArmorEnchantedBlessing : ArmorReduceDefenseDataModifier, XmlLoadable
    {
        private int _enchantedChance = 0;
        private int _chantedDefense = 0;
        private const int XmlId = 3;

        private Resistance _resistance;
        private DoubleEnchantChecker _doubleEnchantChecker;

        private bool _enchant;

        void Start()
        {
            _resistance = GetComponent<Resistance>();
            _resistance.Defending += OnDefending;
            _doubleEnchantChecker = new DoubleEnchantChecker(this);
            _doubleEnchantChecker.Check();
            LoadXml();
        }

        void OnDefending()
        {
            _enchant = MathHelper.IsBetweenRandomProcentFrom0To100(_enchantedChance);
        }

        public override DefenseData ReduceDefenseData(DefenseData defenseData)
        {
            if (_enchant)
            {
                defenseData.Defense += _chantedDefense;
            }
            return defenseData;
        }

        public void LoadXml()
        {
            XmlSearcher xmlSearcher = new XmlSearcher(Location.Blessing);
            int[] specs = xmlSearcher.GetSpecsInChildrenWithId(XmlId, "Blessings");
            _enchantedChance = specs[0];
            _chantedDefense = specs[1];
        }
    }
}