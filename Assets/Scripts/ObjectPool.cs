using System.Collections.Generic;
using UnityEngine;

namespace Services.Factory
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private Transform _container;
        private IGameFactory _gameFactory;

        protected Stack<T> _pool;

        public ObjectPool(Transform container, IGameFactory factory, int startCount = 10)
        {
            _container = container;
            _gameFactory = factory;
            CreatePool(startCount);
        }

        protected void CreatePool(in int startCount)
        {
            _pool = new Stack<T>();
            for (int i = 0; i < startCount; i++)
                _pool.Push(GetNewObject());
        }

        public T GetFreeElement()
        {
            if (_pool.Count > 0)
                return _pool.Pop();
            
            var newObject = GetNewObject();
            return newObject;
        }

        protected virtual T GetNewObject()
        {
            return null;
        }

        public void Return(T obj)
        {
            _pool.Push(obj);
        }
    }
}