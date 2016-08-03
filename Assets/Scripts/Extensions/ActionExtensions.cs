using System;

namespace Assets.Scripts.Extensions
{
    public static class ActionExtensions
    {
        public static void CallIfNotNull(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public static void CallIfNotNull<T>(this Action<T> action, T parameter)
        {
            if (action != null)
            {
                action(parameter);
            }
        }
    }
}