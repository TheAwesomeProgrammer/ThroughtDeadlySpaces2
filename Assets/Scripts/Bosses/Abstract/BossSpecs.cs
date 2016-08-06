using UnityEngine;

namespace Assets.Scripts.Bosses.Abstract
{
    [System.Serializable]
    public class BossSpecs
    {
        public float[] MovementSpecs;
        public int[] DamageSpecs;
        public float[] PauseTimeSpecs;
        public float[] SpecialSpecs;

        public BossSpecs(float[] movementSpecs = null, int[] damageSpecs = null, float[] pauseTimeSpecs = null, 
            float[] specialSpecs = null)
        {
            MovementSpecs = movementSpecs ?? new float[0];
            DamageSpecs = damageSpecs ?? new int[0];
            PauseTimeSpecs = pauseTimeSpecs ?? new float[0];
            SpecialSpecs = specialSpecs ?? new float[0];
        }
    }
}