using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

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

        /// <summary>
        /// Only use with properties(for now)
        /// </summary>
        /// <param name="aObject"></param>
        /// <returns>Name of property</returns>
        public static string NameOf<T>(this object aObject, Expression<Func<T>> memberExpression)
        {
            return MemberInfoGetting.GetMemberName(memberExpression);
        }
    }
}