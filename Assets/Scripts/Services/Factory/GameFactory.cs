using UnityEngine;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string SpawnerPath = "Spawner";
        private const string InteractableObjectPath = "InteractableObject";

        private int _spawnersCount = 3;
        
        public GameObject CreateSpawner(Transform position)
        {
            var spawner = Resources.Load<GameObject>(SpawnerPath);
            return Object.Instantiate(spawner);
        }

        public GameObject CreateInteractableObject(Transform position)
        {
            var interactableObject = Resources.Load<GameObject>(InteractableObjectPath);
            return Object.Instantiate(interactableObject);
        }

        public void CreateSpawners()
        {
                
        }
    }
}