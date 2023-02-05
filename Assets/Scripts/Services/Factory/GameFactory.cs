using GameActors.InteractableObjects;
using GameActors.Spawner;
using UnityEngine;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string InteractableObjectPath = "InteractableObject";
        
        private InteractableObjectsPool _interactableObjectsPool;

        public InteractableObject LoadInteractableObject()=> 
            Resources.Load<InteractableObject>(InteractableObjectPath);
    }
}