using System;
using GameActors.InteractableObjects;
using Services.Progress;
using Services.ServiceLocator;
using StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string InteractableObjectPath = "Fruit";
        private const string InputTrailPath = "InputTrail";
        private const string SlicePath = "Slice";
        private const string GameViewPath = "UI/GameView";
        

        private InteractableObjectsPool _interactableObjectsPool;
        public Action<InteractableObject> OnInteractableObjectCreate;

        private ServiceLocator<IService> _serviceLocator;

        private Fruit _fruitPrefab;
        private Slice _slicePrefab;
        
        public GameFactory(Fruit fruitPrefab, Slice slicePrefab)
        {
            _fruitPrefab = fruitPrefab;
            _slicePrefab = slicePrefab;
        }
        
        public Fruit LoadInteractableObject(Transform container)
        {
           var resource = Resources.Load<Fruit>(InteractableObjectPath);
           var fruit = Object.Instantiate(resource, container);
           fruit.Construct(_serviceLocator.Get<ProgressService>());
           OnInteractableObjectCreate?.Invoke(fruit);
           return fruit;
        }

        public InteractableObject LoadInteractableObject()
        {
            return null;
        }

        public GameObject LoadInputTrail()
        {
            var trail = Resources.Load<GameObject>(InputTrailPath);
            return Object.Instantiate(trail);
        }

        public InteractableObjectConfig[] LoadFruitConfigs()
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