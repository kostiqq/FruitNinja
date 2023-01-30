using GameActor;
using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject LoadInteractableObject();
        void CreateSpawners();
    }
}