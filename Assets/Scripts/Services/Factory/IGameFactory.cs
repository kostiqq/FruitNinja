using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreateSpawner(Transform position);
        public GameObject CreateInteractableObject(Transform position);
    }
}