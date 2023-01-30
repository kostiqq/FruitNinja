using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreateInteractableObject(Transform position);
        void CreateSpawners();
    }
}