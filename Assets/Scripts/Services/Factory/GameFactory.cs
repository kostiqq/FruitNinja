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
        private InteractableObjectsPool _interactableObjectsPool;
        private ServiceLocator<IService> _serviceLocator;

        private Fruit _fruitPrefab;
        private Slice _slicePrefab;
        
        [Inject] private ProgressService _progressService; 

        public GameFactory(Fruit fruitPrefab, Slice slicePrefab)
        {
            Debug.LogError("createFactory");
            _fruitPrefab = fruitPrefab;
            _slicePrefab = slicePrefab;
        }
        
        public Action<Fruit> OnInteractableObjectCreate { get; set; }

        public Fruit CreateFruit(Transform container)
        { 
            var fruit = Object.Instantiate(_fruitPrefab, container);
            fruit.Construct(_progressService);
            OnInteractableObjectCreate?.Invoke(fruit);
            return fruit;
        }

        public Slice CreateSlice(Transform container)=> 
            Object.Instantiate(_slicePrefab);
    }
}