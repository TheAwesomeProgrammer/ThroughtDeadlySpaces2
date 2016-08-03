using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentAttributeType.Curse)]
    public class MinusHpCurse : EquipmentAttribute
    {
        public const int HpToLose = 1;

        protected override void Activate()
        {
            PlayerProperties playerProperties = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<PlayerProperties>();
            playerProperties.Health -= HpToLose;
            Destroy(this);
        }
    }
}