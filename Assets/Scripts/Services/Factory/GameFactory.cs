using System.Collections.Generic;
using GameActor;
using UnityEngine;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string SpawnerPath = "Spawner";
        private const string InteractableObjectPath = "InteractableObject";
        
        private Camera _camera;
        private Vector2 rightPoint;
        private Vector2 botPoint;
        private Vector2 leftPoint;
        
        private List<Spawner> _spawners;
        private InteractableObjectsPool _interactableObjectsPool; 

        public GameFactory()
        {
            _camera = Camera.main;
            CalculateScreenBounds();
        }

        public GameObject LoadInteractableObject()
        {
            var interactableObject = Resources.Load<GameObject>(InteractableObjectPath);
            return interactableObject;
        }
            

        public void CreateSpawners()
        {
            _spawners = new List<Spawner>();
            var spawnerPrefab = Resources.Load<GameObject>(SpawnerPath); 
            
            GameObject spawnersParent = new GameObject("Spawners");
            _spawners.Add(InstantiatePrefab(spawnerPrefab, rightPoint, spawnersParent.transform).GetComponent<Spawner>());
            _spawners.Add(InstantiatePrefab(spawnerPrefab, botPoint, spawnersParent.transform).GetComponent<Spawner>());
            _spawners.Add(InstantiatePrefab(spawnerPrefab, leftPoint, spawnersParent.transform).GetComponent<Spawner>());

            InitializeSpawners();
            CreateInteractableObjectPool();
        }

        private void CreateInteractableObjectPool()
        {
            GameObject interactableObjects = new GameObject("InteractableObjects");
            _interactableObjectsPool = new InteractableObjectsPool(LoadInteractableObject().GetComponent<InteractableObject>(), 50, interactableObjects.transform);
        }

        private void InitializeSpawners()
        {
            foreach (Spawner spawner in _spawners)
                spawner.Initialize(this as IGameFactory);
        }

        private GameObject InstantiatePrefab(GameObject objectToSpawn, Vector2 position, Transform parent = null) =>
            Object.Instantiate(objectToSpawn, rightPoint, Quaternion.identity, parent.transform);
        
        private void CalculateScreenBounds()
        {
            Vector2 leftBotPosition = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
            Vector2 rightTopPosition = _camera.ViewportToWorldPoint(new Vector3(1f, 1f, _camera.nearClipPlane));
            
            rightPoint = new Vector2(rightTopPosition.x, 0);
            botPoint = new Vector2(0, leftBotPosition.y);
            leftPoint = new Vector2(leftBotPosition.x, 0);
        }
    }
}