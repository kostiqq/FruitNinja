using GameActors.InteractableObjects;
using UnityEngine;

namespace Services.Factory
{
    public class FruitPool : ObjectPool<Fruit>
    {
        public FruitPool(Transform container, IGameFactory factory, int startCount = 10) : base(container, factory, startCount)
        {
            _gameFactory = factory;
            _container = container;
            CreatePool(startCount);
        }

        protected override Fruit GetNewObject()=>
            _gameFactory.CreateFruit(_container);
    }
}