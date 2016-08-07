using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Armors.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Armor, EquipmentAttributeType.Curse)]
    public class ArmorRustyCurse : EquipmentAttribute, XmlAttributeLoadable
    {
        private const int CurseId = 3;

        private Resistance _resistance;
        private EquipmentAttributeLoader _equipmentAttributeLoader;
        private int _procentChanceToBreak;

        public override void Init()
        {
            base.Init();
            _resistance = GetComponent<Resistance>();
            _resistance.Defending += OnDefending;
        }

        void OnDefending()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(_procentChanceToBreak))
            {
                gameObject.AddComponentIfNotExist<ArmorBrokenCurse>();
                Destroy(this);
            }
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(XmlFileLocations.GetLocation(Location.Curse), CurseId, level, XmlName.Curses);
            _procentChanceToBreak = specs[0];
        }
    }
}