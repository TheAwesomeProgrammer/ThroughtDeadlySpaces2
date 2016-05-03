using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Abstract
{
    public abstract class BossSpecsLoader : MonoBehaviour,XmlLoadable
    {
        public BossSpecs BossSpecs;
        public int BossId;

        protected string _xmlArrayNodeName = "Bosses";
        protected XmlSearcher _xmlSearcher;

        protected virtual void Awake()
        {
            _xmlSearcher = new XmlSearcher(Location.Boss);
        }

        public virtual void LoadXml()
        {
            float[] movementSpecs = _xmlSearcher.GetSpecsInChildrenWithIdFloat(BossId, _xmlArrayNodeName, "Movement");
            int[] damageSpecs = _xmlSearcher.GetSpecsInChildrenWithId(BossId, _xmlArrayNodeName, "Damage");
            float[] pauseTimeSpecs = _xmlSearcher.GetSpecsInChildrenWithIdFloat(BossId, _xmlArrayNodeName, "PauseTime");
            BossSpecs = new BossSpecs(movementSpecs, damageSpecs, pauseTimeSpecs);
        }
    }
}