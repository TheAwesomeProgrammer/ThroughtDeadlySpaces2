using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentAttributeType.Curse)]
    public class MinusHpCurse : PlayerAttribute
    {
        public const int HpToLose = 1;

        public override void OnActivate()
        {
            PlayerProperties playerProperties = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<PlayerProperties>();
            playerProperties.SetHealth(playerProperties.Health - HpToLose);
            Destroy(this);
        }
    }
}