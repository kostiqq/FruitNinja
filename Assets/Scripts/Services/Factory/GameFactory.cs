using GameActor;
using UnityEngine;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string InteractableObjectPath = "InteractableObject";
        
        private InteractableObjectsPool _interactableObjectsPool;

        public InteractableObject LoadInteractableObject()=> 
            Resources.Load<InteractableObject>(InteractableObjectPath);

        public void CreateSpawnerController()
        {
            GameObject spawnerControllerParent = new GameObject("SpawnerController");
            SpawnerController controller = spawnerControllerParent.AddComponent<SpawnerController>();
            
            controller.Construct(LoadInteractableObject());
        }
    }
}