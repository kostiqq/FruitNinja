using System.Collections.Generic;
using Services.Factory;
using UnityEngine;

namespace GameActor
{
    public class SpawnerController : MonoBehaviour
    {
        private const int PoolCapacity = 50;
        private List<Spawner> _spawners;
        private InteractableObjectsPool _pool;

        public void Construct(List<Spawner> spawners, GameObject loadInteractableObject)
        {
            _spawners = new List<Spawner>(spawners);
            
            _pool = new InteractableObjectsPool(loadInteractableObject, PoolCapacity, transform);
            
            
        }
    }
}