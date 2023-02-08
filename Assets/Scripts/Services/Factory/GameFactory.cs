using System;
using GameActors.InteractableObjects;
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

        public InteractableObject LoadInteractableObject(Transform container)
        {
           var resource = Resources.Load<InteractableObject>(InteractableObjectPath);
           var interactableObject = Object.Instantiate(resource, container);
           OnInteractableObjectCreate?.Invoke(interactableObject);
           return interactableObject;
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