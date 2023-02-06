using System.Collections.Generic;
using GameActors.InteractableObjects;
using StaticData;
using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory : IService
    {
        public InteractableObject LoadInteractableObject();
        GameObject LoadInputTrail();
        FruitConfig[] LoadFruitConfigs();
    }
}