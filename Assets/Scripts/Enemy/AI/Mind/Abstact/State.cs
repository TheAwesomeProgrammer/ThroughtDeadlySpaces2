namespace Assets.Scripts.Enemy
{
    public interface State
    {
        bool ExitOnReEntry { get; }

        void OnEnterState();
        void OnExitState();
    }
}