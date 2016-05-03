namespace Assets.Scripts.Bosses.Harbinger_of_death
{
    public interface BossStateExecuter
    {
        void StartState(BossStateMachine bossStateMachine);
        void EndState(BossStateMachine bossStateMachine);
    }
}