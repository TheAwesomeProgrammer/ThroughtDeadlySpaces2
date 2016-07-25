using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentAttributeType.Curse)]
    public class MinusMaxHpCurse : PlayerAttribute
    {
        public const int MaxHpToLose = 1;

        public override void OnActivate()
        {
            PlayerProperties playerProperties = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<PlayerProperties>();
            playerProperties.SetMaxHealth(playerProperties.MaxHealth - MaxHpToLose);
            Destroy(this);
        }
    }
}