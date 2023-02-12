using System.Collections;
using System.Collections.Generic;
using GameActors.InteractableObjects;
using Services.Factory;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace GameActors.Spawner
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private List<SpawnZone> spawnZones;
        [SerializeField] private PlayZone playZone;
        [SerializeField] private GameComplicator _complicator;
        
        private InteractableObjectsPool _pool;
        private float _waveCooldown;
        private float _cooldownBetweenFruitsSpawn;
        private int _minFruitCount;
        private int _maxFruitCount;

        public static SpawnerController Instance;
        
        [Inject] private InteractableObjectConfigHandler _objectConfigs;
        [Inject] private IGameFactory factory;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        public void Start()
        {
            _pool = new InteractableObjectsPool(90, transform, factory);
            InitializeSpawnersPosition();
            InitializeComplexitySettings();
            StartCoroutine(SpawnCycle());
        }

        private void InitializeSpawnersPosition()
        {
            foreach (var spawnZone in spawnZones)
                spawnZone.transform.position = playZone.PositionFromPercentage(spawnZone.GetPositionOnScreen);
        }

        private void InitializeComplexitySettings()
        {
            _minFruitCount = _complicator.complexityConfig.MinFruitsCount;
            _maxFruitCount = _complicator.complexityConfig.MaxFruitsCount;

            _waveCooldown = _complicator.complexityConfig.TimeBetweenWaves;
            _cooldownBetweenFruitsSpawn = _complicator.complexityConfig.TimeBetweenFruitSpawn;
        }
        
        private IEnumerator SpawnCycle()
        {
            while (true)
            {
                StartCoroutine(SpawnWave());
                yield return new WaitForSeconds(_waveCooldown -  (-1+_complicator.CurrentWaveComplexityCoefficient) );     
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
                spawnedObject.Initialize(_objectConfigs.GetRandomFruitConfig());
                spawnedObject.transform.position = spawnPoint;
                spawnedObject.StartMoving(selectedSpawnZone.NormalWithRandomAngleOffset, selectedSpawnZone.GetRandomForce());
                yield return new WaitForSeconds(_cooldownBetweenFruitsSpawn);
            }
        }
        
        private int GetRandomFruitCount()
        {
            int complexityCoef = _complicator.CurrentObjectComplexityCoefficient;
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

        public void StopSpawn()
        {
            StopAllCoroutines();
        }
    }
}