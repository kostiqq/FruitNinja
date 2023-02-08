using System;
using GameActors.InteractableObjects;
using Services.Progress;
using Services.ServiceLocator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Factory
{
    public class GameFactory : IService
    {
        private const string InteractableObjectPath = "InteractableObject";
        private const string InputTrailPath = "InputTrail";
        private const string SlicePath = "Slice";

        private InteractableObjectsPool _interactableObjectsPool;
        public Action<InteractableObject> OnInteractableObjectCreate;

        private ServiceLocator<IService> _serviceLocator;
        public GameFactory(ServiceLocator<IService> serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public Fruit LoadInteractableObject(Transform container)
        {
           var resource = Resources.Load<Fruit>(InteractableObjectPath);
           var fruit = Object.Instantiate(resource, container);
           fruit.Construct(_serviceLocator.Get<ProgressService>());
           OnInteractableObjectCreate?.Invoke(fruit);
           return fruit;
        }


        public GameObject LoadInputTrail()
        {
            var trail = Resources.Load<GameObject>(InputTrailPath);
            return Object.Instantiate(trail);
        }

        public Slice CreateSlice()
        {
            var resource = Resources.Load<Slice>(SlicePath);
            return Object.Instantiate(resource);
        }
            
    }
}