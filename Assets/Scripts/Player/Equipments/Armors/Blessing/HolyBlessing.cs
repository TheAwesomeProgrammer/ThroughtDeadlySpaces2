using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Armors.Blessing
{
    [EquipmentAttributeMetaData(EquipmentType.Armor, EquipmentAttributeType.Blessing)]
    public class HolyBlessing : EquipmentAttribute
    {
        private DexterityFiller _dexterityFiller;
        private float _interval;
        private float _dexterityPerInterval;

        void Start()
        {
            _dexterityFiller = GameObject.FindGameObjectWithTag(Tag.Player).GetComponentInChildren<DexterityFiller>();
        }

        protected override void Activate()
        {
            Timer.Start(gameObject, _interval, AddDexterity);
        }

        private void AddDexterity()
        {
            if (enabled)
            {
                Timer.Start(gameObject, _interval, AddDexterity);
                _dexterityFiller.Dexterity += _dexterityPerInterval;
            }
        }
    }
}