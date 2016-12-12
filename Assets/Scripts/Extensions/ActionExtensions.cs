using System;

namespace Assets.Scripts.Extensions
{
    public static class ActionExtensions
    {
        public static void InvokeIfNotNull(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public static void InvokeIfNotNull<T>(this Action<T> action, T parameter)
        {
            if (action != null)
            {
                action(parameter);
            }
        }
    }
}