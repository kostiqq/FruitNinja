using GameActors.InteractableObjects;

using UnityEngine;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string InteractableObjectPath = "InteractableObject";
        private const string InputTrailPath = "InputTrail";
        
        private InteractableObjectsPool _interactableObjectsPool;

        public InteractableObject LoadInteractableObject()=> 
            Resources.Load<InteractableObject>(InteractableObjectPath);

        public GameObject LoadInputTrail()
        {
            var trail = Resources.Load<GameObject>(InputTrailPath);
            return Object.Instantiate(trail);
        }
            
    }
}