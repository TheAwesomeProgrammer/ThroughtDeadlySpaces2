using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack.Projectile.DataSetters
{
    public class BossSetExtraBaseDamage : SetableData
    {
        public void Execute(GameObject projectileObject, ProjectileData projectileData)
        {
            BossAttack bossAttack = projectileObject.GetComponentInChildren<BossAttack>();
            bossAttack.SetExtraBaseDamage(projectileData.Damage);
        }
    }
}