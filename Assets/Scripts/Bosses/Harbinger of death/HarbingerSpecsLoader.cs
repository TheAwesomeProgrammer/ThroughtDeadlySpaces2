using Assets.Scripts.Bosses.Abstract;
using XmlLibrary;

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
            XmlPath beamPath = new DefaultXmlPath(_bossPath, new XmlPathData("Beam"));
            BossSpecs.SpecialSpecs = beamPath.GetSpecsFloat();
        }
    }
}