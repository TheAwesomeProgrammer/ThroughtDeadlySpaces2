using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class Range
    {
        public float Max;
        public float Min;

        public Range(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public int GetRandomRounded()
        {
            return Mathf.RoundToInt(Random.Range(Min, Max));
        }
    }

    public class PossibleAttacks
    {
        public Range MeleeStateRange;
        public Range RangedStateRange;

        public PossibleAttacks()
        {
            RangedStateRange = new Range(6, 7);
            MeleeStateRange = new Range(4, 5);
        }

        public HarbingerOfDeathState GetRandomMeleeAttackState()
        {
            return (HarbingerOfDeathState)MeleeStateRange.GetRandomRounded();
        }

        public HarbingerOfDeathState GetRandomRangedAttackState()
        {
            return (HarbingerOfDeathState)RangedStateRange.GetRandomRounded();
        }
    }
}