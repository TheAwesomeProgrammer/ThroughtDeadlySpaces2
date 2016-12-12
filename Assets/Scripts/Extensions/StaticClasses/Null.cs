using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class Null
    {
        public static void OnNot(object checkObject, Action notNullAction)
        {
            if (checkObject != null)
            {
                notNullAction.InvokeIfNotNull();
            }
        }

        public static T OnNot<T>(object checkObject, Func<T> notNullFunction)
        {
            if (checkObject == null || notNullFunction == null  || (checkObject as UnityEngine.Object) == null)
            {
                return default(T);
            }
            return notNullFunction();
        }

        public static void On(object checkObject, Action nullAction)
        {
            if (checkObject == null)
            {
                nullAction.InvokeIfNotNull();
            }
        }

        public static void Call<T>(T item, Action<T> callAction)
        {
            if (item != null && callAction != null)
            {
                callAction.Invoke(item);
            }
        }
    }
}