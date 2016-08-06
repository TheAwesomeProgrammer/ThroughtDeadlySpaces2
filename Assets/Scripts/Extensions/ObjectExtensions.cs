using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsList(this object objectToCheck)
        {
            if (objectToCheck != null)
            {
                Type objectType = objectToCheck.GetType();
                return objectToCheck is IList &&
                   objectType.IsGenericType &&
                   objectType.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
            }
            return false;
        }
    }
}