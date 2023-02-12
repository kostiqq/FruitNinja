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
        private const string SlicePath = "Slice";

        private InteractableObjectsPool _interactableObjectsPool;
        public Action<InteractableObject> OnInteractableObjectCreate;

        private ServiceLocator<IService> _serviceLocator;

        private Fruit _fruitPrefab;
        private Slice _slicePrefab;
        [Inject] private ProgressService _progressService; 

        public GameFactory(Fruit fruitPrefab, Slice slicePrefab)
        {
            _fruitPrefab = fruitPrefab;
            _slicePrefab = slicePrefab;
        }
        
        public Fruit LoadInteractableObject(Transform container)
        {
            var fruit = Object.Instantiate(_fruitPrefab, container);
           fruit.Construct(_progressService);
           OnInteractableObjectCreate?.Invoke(fruit);
           return fruit;
        }

        public InteractableObject LoadInteractableObject()
        {
            return null;
        }
        

        public Slice CreateSlice()
        {
            var resource = Resources.Load<Slice>(SlicePath);
            return Object.Instantiate(resource);
        }
            
    }
}