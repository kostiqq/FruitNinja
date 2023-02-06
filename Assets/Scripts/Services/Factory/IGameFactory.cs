using GameActors.InteractableObjects;
using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory : IService
    {
        public InteractableObject LoadInteractableObject();
        GameObject LoadInputTrail();
    }
}