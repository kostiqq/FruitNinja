using System;
using GameActors.InteractableObjects;
using Services.Progress;
using Services.ServiceLocator;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private FruitPool _interactableObjectsPool;
        private ServiceLocator<IService> _serviceLocator;

        private Fruit _fruitPrefab;
        private Slice _slicePrefab;
        private Bomb _bombPrefab;
        private BonusLife _bonusLifePrefab;
        private IceBlock _iceBlock;
        
        [Inject] private ProgressService _progressService;
        [Inject] private IComboTimer _comboTimer;

        public GameFactory(Fruit fruitPrefab, Slice slicePrefab, Bomb bomb, BonusLife bonusLife, IceBlock iceBlock)
        {
            _fruitPrefab = fruitPrefab;
            _slicePrefab = slicePrefab;
            _bombPrefab = bomb;
            _bonusLifePrefab = bonusLife;
            _iceBlock = iceBlock;
        }
        
        public Action<Fruit> OnInteractableObjectCreate { get; set; }

        public Fruit CreateFruit(Transform container)
        { 
            var fruit = Object.Instantiate(_fruitPrefab, container);
            fruit.Construct(_progressService, _comboTimer);
            OnInteractableObjectCreate?.Invoke(fruit);
            return fruit;
        }

        public Slice CreateSlice(Transform container)=> 
            Object.Instantiate(_slicePrefab);

        public Bomb CreateBomb(Transform container)
        {
            var bomb = Object.Instantiate(_bombPrefab, container);
            bomb.Construct(_progressService);
            return bomb;
        }

        public BonusLife CreateBonusLife(Transform container)
        {
            var bonusLife = Object.Instantiate(_bonusLifePrefab, container);
            bonusLife.Construct(_progressService);
            return bonusLife;
        }

        public IceBlock CreateIceBlock(Transform container)
        {
            var ice = Object.Instantiate(_iceBlock, container);
            return ice;
        }
    }
}