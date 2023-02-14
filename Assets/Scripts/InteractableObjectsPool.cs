using GameActors.InteractableObjects;
using UnityEngine;

namespace Services.Factory
{
    public class InteractableObjectsPool : ObjectPool<InteractableObject>
    {
        private Transform _container;
        private IGameFactory _gameFactory;

        public InteractableObjectsPool(Transform container, IGameFactory factory, int startCount = 10) : base(container, factory, startCount)
        {
            _gameFactory = factory;
            _container = container;
            CreatePool(startCount);
        }

        protected override InteractableObject GetNewObject()=>
            _gameFactory.CreateFruit(_container);
    }
}