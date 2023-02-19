using UnityEngine;

namespace Services.Factory
{
    public class IceBlockPool : ObjectPool<IceBlock>
    {
        public IceBlockPool(Transform container, IGameFactory factory, int startCount = 10) : base(container, factory, startCount)
        {
            _gameFactory = factory;
            _container = container;
            CreatePool(startCount);
        }

        protected override IceBlock GetNewObject()=>
            _gameFactory.CreateIceBlock(_container);
    }
}