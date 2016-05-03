using Assets.Scripts.Bosses.Abstract;

namespace Assets.Scripts.Bosses.Harbinger_of_death
{
    public class HarbingerSpecsLoader : BossSpecsLoader
    {
        protected override void Awake()
        {
            base.Awake();
            LoadXml();
        }

        public override void LoadXml()
        {
            base.LoadXml();
            BossSpecs.SpecialSpecs = _xmlSearcher.GetSpecsInChildrenWithIdFloat(BossId, _xmlArrayNodeName, "Beam");
        }
    }
}