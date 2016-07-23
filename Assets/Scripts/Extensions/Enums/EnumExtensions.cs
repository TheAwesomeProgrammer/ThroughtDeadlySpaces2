using System;

namespace Assets.Scripts.Extensions.Enums
{
    public static class EnumExtensions
    {
        public static int Length(this Enum theEnum)
        {
            return System.Enum.GetNames(theEnum.GetType()).Length;
        }
    }
}