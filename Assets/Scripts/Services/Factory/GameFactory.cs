using UnityEngine;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string SpawnerPath = "Spawner";
        private const string InteractableObjectPath = "InteractableObject";
        
        private Camera _camera;
        private Vector2 _leftBotPosition;
        private Vector2 _rightTopPosition;

        public GameFactory()
        {
            _camera = Camera.main;
            CalculateScreenBounds();
        }

        public GameObject CreateInteractableObject(Transform position)
        {
            var interactableObject = Resources.Load<GameObject>(InteractableObjectPath);
            return Object.Instantiate(interactableObject);
        }

        public void CreateSpawners()
        {
            var spawner = Resources.Load<GameObject>(SpawnerPath);
            Vector2 rightPoint = new Vector2(_rightTopPosition.x, 0);
            Vector2 botPoint = new Vector2(0, _leftBotPosition.y);
            Vector2 leftPoint = new Vector2(_leftBotPosition.x, 0);
            Object.Instantiate(spawner, rightPoint, Quaternion.identity);
            Object.Instantiate(spawner, botPoint, Quaternion.identity);
            Object.Instantiate(spawner, leftPoint, Quaternion.identity);
        }
        
        private void CalculateScreenBounds()
        {
            _leftBotPosition = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
            _rightTopPosition = _camera.ViewportToWorldPoint(new Vector3(1f, 1f, _camera.nearClipPlane));
        }
    }
}