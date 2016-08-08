using System;

namespace Assets.Scripts.Extensions
{
    public static class Null
    {
        public static void OnNot(object checkObject, Action notNullAction)
        {
            if (checkObject != null)
            {
                notNullAction.CallIfNotNull();
            }
        }

        public static T OnNot<T>(object checkObject, Func<T> notNullFunction)
        {
            if (checkObject != null && notNullFunction != null)
            {
                return notNullFunction();
            }
            return default(T);
        }

        public static void On(object checkObject, Action nullAction)
        {
            if (checkObject == null)
            {
                nullAction.CallIfNotNull();
            }
        }
    }
}