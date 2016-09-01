using XmlLibrary;
using UnityEngine;
using XmlLibrary;

namespace Assets.Scripts.Bosses.Abstract
{
    public abstract class BossSpecsLoader : MonoBehaviour,XmlLoadable
    {
        public BossSpecs BossSpecs;
        public int BossId;

        protected XmlPath _bossPath;
        protected XmlPath _movementPath;
        protected XmlPath _damagePath;
        protected XmlPath _pauseTimePath;

        protected virtual void Awake()
        {
            _bossPath = new DefaultXmlPath(XmlLocation.Boss, new XmlPathData(BossId));
            _movementPath = new DefaultXmlPath(_bossPath);
            _movementPath.AddPathData(new XmlPathData("Movement"));
            _damagePath = new DefaultXmlPath(_bossPath);
            _damagePath.AddPathData(new XmlPathData("Damage"));
            _pauseTimePath = new DefaultXmlPath(_bossPath);
            _pauseTimePath.AddPathData(new XmlPathData("PauseTime"));
        }

        public virtual void LoadXml()
        {
            BossSpecs = new BossSpecs(_movementPath.GetSpecsFloat(), _movementPath.GetSpecs(), _damagePath.GetSpecsFloat());
        }
    }
}