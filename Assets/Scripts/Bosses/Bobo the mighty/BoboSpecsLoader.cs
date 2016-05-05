using Assets.Scripts.Bosses.Abstract;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty
{
    public class BoboSpecsLoader : BossSpecsLoader
    {
        private void Start()
        {
            LoadXml();
        }
    }
}