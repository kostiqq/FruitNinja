using System.Collections;
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

        private Coroutine _spawnCoroutine;

        public void Construct(List<Spawner> spawners, GameObject loadInteractableObject)
        {
            _pool = new InteractableObjectsPool(loadInteractableObject, PoolCapacity, new GameObject("ObjectPool").transform);
            
            _spawners = new List<Spawner>(spawners);
            foreach (var Spawner in _spawners)
            {
                Spawner.Initialize(_pool);
            }

            _spawnCoroutine = StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                SpawnObjects();
                yield return new WaitForSeconds(3f);
            }
        }

        private void SpawnObjects()
        {
            int RandomSpawnIndex = Random.Range(0, _spawners.Count);
            _spawners[RandomSpawnIndex].SpawnWave();
        }
    }
}