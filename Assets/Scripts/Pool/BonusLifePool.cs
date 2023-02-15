using GameActors.InteractableObjects;
using UnityEngine;

namespace Services.Factory
{
    public class BonusLifePool : ObjectPool<BonusLife>
    {
        public BonusLifePool(Transform container, IGameFactory factory, int startCount = 10) : base(container, factory, startCount)
        {
            _container = container;
            _gameFactory = factory;
            CreatePool(startCount);
        }
        
        protected override BonusLife GetNewObject()=>
            _gameFactory.CreateBonusLife(_container);
    }
}