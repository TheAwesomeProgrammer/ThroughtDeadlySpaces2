using System;
using UnityEngine;

namespace Assets.Scripts.Extensions.StaticClasses
{
    [Serializable]
    public class LazyLoading<TObject> where TObject : class 
    {
        private TObject _lazyLoadingObject;
        private Func<TObject> _loadingFunction;

        public LazyLoading(Func<TObject> loadingFunction)
        {
            _loadingFunction = loadingFunction;
            _lazyLoadingObject = null;
        }

        public TObject TryGet()
        {
            _lazyLoadingObject = _lazyLoadingObject ?? _loadingFunction();

            return _lazyLoadingObject;
        }
    }
}