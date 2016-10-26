using System;

namespace Assets.Scripts.Enemy
{
    public interface StateChanger
    {
        bool ShouldStateChange(State currentState, out State newState);
    }
}