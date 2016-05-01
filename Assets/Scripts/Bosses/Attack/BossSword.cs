using Assets.Scripts.Player.Equipments;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossSword : Sword
    {
        public override void Awake()
        {
            _bossAttributeManager = GetComponent<AttributeManager>();
        }
    }
}