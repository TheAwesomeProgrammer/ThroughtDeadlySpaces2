using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;

namespace Assets.Scripts.Combat.Defense.Boss
{
    public interface Damageable
    {
        void DoDamage(List<CombatData> damageDatas);
    }
}