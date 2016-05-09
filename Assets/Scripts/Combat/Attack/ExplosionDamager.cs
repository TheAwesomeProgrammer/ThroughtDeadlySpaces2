using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack
{
    public class ExplosionDamager : MonoBehaviour
    {
        private RadiusPusher _radiusPusher;
        private BossAttack _bossAttack;

        void Awake()
        {
            _bossAttack = GetComponent<BossAttack>();
            _radiusPusher = GetComponent<RadiusPusher>();
            _radiusPusher.Pushing += _bossAttack.StartAttack;
        }
    }
}