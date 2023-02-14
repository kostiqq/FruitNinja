using GameActors.InteractableObjects;
using UnityEngine;

namespace Services.Factory
{
    public class BombsPool : ObjectPool<Bomb>
    {
        public BombsPool(Transform container, IGameFactory factory, int startCount = 10) : base(container, factory, startCount)
        {
            _gameFactory = factory;
            _container = container;
            CreatePool(startCount);
        }

        protected override Bomb GetNewObject()=>
            _gameFactory.CreateBomb(_container);
    }
}