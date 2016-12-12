using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;

namespace Assets.Scripts.Enemy
{
    public interface State
    {
        bool ExitOnReEntry { get; }
        StateType StateType { get; }
        BehaviourType BehaviourType { get; set; }
    }
}