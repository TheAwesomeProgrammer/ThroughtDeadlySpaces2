using UnityEngine;

namespace Assets.Scripts.Extensions.Math
{
    public class MathHelper
    {
        public static int GetValueMultipliedWithProcent(int value, int procent)
        {
            return (int)(value * (1 + ((float)procent / 100)));
        }

        public static bool IsBetweenRandomProcentFrom0To100(int procentValue)
        {
            return Random.Range(0, 100f) <= procentValue;
        }
    }
}