using Assets.Scripts.Enemy.AI.Mind.Abstact;

namespace Assets.Scripts.Enemy
{
    public interface State
    {
        bool ExitOnReEntry { get; }
        StateType StateType { get; }

        void OnEnterState();
        void OnExitState();
    }
}