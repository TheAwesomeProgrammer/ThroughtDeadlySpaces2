using System;
using UnityEngine;

/// <summary>
/// Convert to Radians.
/// </summary>
/// <param name="val">The value to convert to radians</param>
/// <returns>The value in radians</returns>
public static class NumericExtensions
{
    public static float ToRadians(this float val)
    {
        return (float)(Math.PI / 180) * val;
    }

    public static Vector2 GetDirectionBasedOnAngle(this float pAngleInDegrees)
    {
        float tAngleInRadians = pAngleInDegrees.ToRadians();

        return new Vector2((float)Mathf.Cos(tAngleInRadians), (float)Mathf.Sin(tAngleInRadians));
    }

    public static float GetAngleBasedOnDirection(this Vector2 pDirection)
    {        
      return (float)Math.Atan2(pDirection.x, -pDirection.y) * Mathf.Rad2Deg;
    }
    public static float GetAngleBasedOnDirection(this Vector3 pDirection)
    {
        return (float)Math.Atan2(pDirection.x, -pDirection.y) * Mathf.Rad2Deg;
    }
}