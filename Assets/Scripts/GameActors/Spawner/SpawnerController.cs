using System.Collections;
using System.Collections.Generic;
using GameActors.InteractableObjects;
using Services;
using Services.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameActors.Spawner
{
    public class SpawnerController : MonoBehaviour
    {
        private const int PoolCapacity = 15;

        [SerializeField] private GameComplicator complicator;
        [SerializeField] private List<SpawnZone> spawnZones;
        [SerializeField] private InteractableObject prefab;
        
        private InteractableObjectsPool _pool;
        private FruitBuilder _fruitBuilder;
        
        private float _waveCooldown;
        private float _cooldownBetweenFruitsSpawn;
        private int _minFruitCount;
        private int _maxFruitCount;
        
        public void Start()
        {
            _fruitBuilder = new FruitBuilder(AllServices.Container.GetSingle<IGameFactory>());    
            InitializeObjectPool();
            InitializeComplexitySettings();
            StartCoroutine(SpawnCycle());
        }

        private void InitializeObjectPool()
        {
            var poolParent = new GameObject("Pool").transform;
            poolParent.transform.SetParent(transform);
            _pool = new InteractableObjectsPool(prefab, PoolCapacity, poolParent);
        }

        private void InitializeComplexitySettings()
        {
            _minFruitCount = complicator.complexityConfig.MinFruitsCount;
            _maxFruitCount = complicator.complexityConfig.MaxFruitsCount;

            _waveCooldown = complicator.complexityConfig.TimeBetweenWaves;
            _cooldownBetweenFruitsSpawn = complicator.complexityConfig.TimeBetweenFruitSpawn;
        }
        
        private IEnumerator SpawnCycle()
        {
            while (true)
            {
                StartCoroutine(SpawnWave());
                yield return new WaitForSeconds(_waveCooldown -  (-1+complicator.CurrentWaveComplexityCoefficient) );     
            }
        }

        private IEnumerator SpawnWave()
        {
            int objectsCount = GetRandomFruitCount();
            SpawnZone selectedSpawnZone = GetRandomSpawnZone();
            for(int i = 0; i < objectsCount; i++)
            {
                Vector2 spawnPoint = selectedSpawnZone.GetPointAtSegment();

                InteractableObject spawnedObject = _pool.GetFreeElement();
                _fruitBuilder.GetRandomFruit(spawnedObject);
                spawnedObject.transform.position = spawnPoint;
                
                spawnedObject.StartMoving(selectedSpawnZone.NormalVectorWithRandomAngleOffset);
                yield return new WaitForSeconds(_cooldownBetweenFruitsSpawn);
            }
        }
        
        private int GetRandomFruitCount()
        {
            int complexityCoef = complicator.CurrentObjectComplexityCoefficient;
            return Random.Range(_minFruitCount + complexityCoef, _maxFruitCount + complexityCoef);
        }
        
        private SpawnZone GetRandomSpawnZone()
        {
            float totalSpawnProbability = 0f;
            
            foreach (var spawnZone in spawnZones)
                totalSpawnProbability += spawnZone.SpawnProbability;

            float passedSpawnProbability = 0;
            float targetSpawnProbability = Random.Range(0f, totalSpawnProbability);
            
            foreach (var spawnZone in spawnZones)
            {
                passedSpawnProbability += spawnZone.SpawnProbability;
                if (passedSpawnProbability >= targetSpawnProbability)
                    return spawnZone;
            }

            return null;
        }
     
    }
}