using Services.Factory;
using UnityEngine;

namespace GameActor
{
    public class Spawner : MonoBehaviour
    {
        private InteractableObjectsPool _pool;
        public void Initialize(InteractableObjectsPool pool)
        {
            _pool = pool;
        }

        public void SpawnWave()
        {
            GameObject spawnedObject = _pool.GetFreeElement();
            spawnedObject.transform.position = transform.position;
            
            
        }
    }
}