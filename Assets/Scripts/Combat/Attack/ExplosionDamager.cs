using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack
{
    public class ExplosionDamager : MonoBehaviour
    {
        private ExplosionPusher _explosionPusher;
        private BossAttack _bossAttack;

        void Awake()
        {
            _bossAttack = GetComponent<BossAttack>();
            _explosionPusher = GetComponent<ExplosionPusher>();
            _explosionPusher.Explosion += _bossAttack.StartAttack;
        }
    }
}