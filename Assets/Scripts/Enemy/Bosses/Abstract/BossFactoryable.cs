using System;

namespace Assets.Scripts.Bosses.Harbinger_of_death
{
    public interface BossFactoryable
    {
        BossStateExecuter GetBossStateExecuter(Enum bossState);
    }
}