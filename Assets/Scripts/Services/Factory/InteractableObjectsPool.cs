using System.Collections.Generic;
using GameActors.InteractableObjects;
using UnityEngine;
using Zenject;

namespace Services.Factory
{
    public class InteractableObjectsPool
    {
        private Transform _container;
        private IGameFactory _gameFactory;
        
        private Stack<InteractableObject> _pool;

        public InteractableObjectsPool(int count, Transform container, IGameFactory factory)
        {
            _gameFactory = factory;
            _container = container;
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new Stack<InteractableObject>();
            for (int i = 0; i < count; i++)
                _pool.Push(_gameFactory.CreateFruit(_container));
        }

        public InteractableObject GetFreeElement()
        {
            if (_pool.Count > 0)
                return _pool.Pop();
            
            var newObject = _gameFactory.CreateFruit(_container);
            return newObject;
        }

        public void Return(InteractableObject obj)=>
            _pool.Push(obj);
    }
}