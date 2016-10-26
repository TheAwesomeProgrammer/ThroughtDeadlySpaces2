using Assets.Scripts.Enemy.AI.Mind.Abstact;

namespace Assets.Scripts.Enemy.AI
{
    public interface StateTypeChooser
    {
        StateType GetStateType();
    }
}