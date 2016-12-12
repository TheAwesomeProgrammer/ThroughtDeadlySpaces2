using XmlLibrary;
using UnityEngine;
using XmlLibrary;

namespace Assets.Scripts.Bosses.Abstract
{
    public abstract class EnemySpecsLoader : MonoBehaviour, XmlLoadable
    {
        public EnemySpecs EnemySpecs;
        public int EnemyId;

        protected XmlPath _enemyPath;
        protected XmlPath _movementPath;
        protected XmlPath _damagePath;
        protected XmlPath _pauseTimePath;

        protected virtual void Awake()
        {
            _enemyPath = new DefaultXmlPath(XmlLocation.Boss, new XmlPathData(EnemyId));
            _movementPath = new DefaultXmlPath(_enemyPath);
            _movementPath.AddPathData(new XmlPathData("Movement"));
            _damagePath = new DefaultXmlPath(_enemyPath);
            _damagePath.AddPathData(new XmlPathData("Damage"));
            _pauseTimePath = new DefaultXmlPath(_enemyPath);
            _pauseTimePath.AddPathData(new XmlPathData("PauseTime"));
        }

        public virtual void LoadXml()
        {
            EnemySpecs = new EnemySpecs(_movementPath.GetSpecsFloat(), _movementPath.GetSpecs(), _damagePath.GetSpecsFloat());
        }
    }
}