using System.Collections;
using System.Collections.Generic;
using GameActors.InteractableObjects;
using Services.Factory;
using Services.Factory.GameActors;
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
        [SerializeField] private ObjectContainer activeObjects;
        [SerializeField] private BlastWave blast;
        
        private FruitPool _fruitsPool;
        private BombsPool _bombsPool;
        
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
            _fruitsPool = new FruitPool(transform, factory);
            _bombsPool = new BombsPool(transform, factory);
            
            activeObjects.Pool = _fruitsPool;
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
            int bombsCount = GetBombsWithProb();
            int fruitCount = GetRandomFruitCount();
            SpawnZone selectedSpawnZone = GetRandomSpawnZone();
            for(int i = 0; i < fruitCount; i++)
            {
                Vector2 spawnPoint = selectedSpawnZone.GetPointAtSegment();

                InteractableObject spawnedObject = _fruitsPool.GetFreeElement();
                activeObjects.AddObject(spawnedObject);
                
                spawnedObject.Initialize(_objectConfigs.GetRandomFruitConfig());
                spawnedObject.transform.position = spawnPoint;
                spawnedObject.StartMoving(selectedSpawnZone.NormalWithRandomAngleOffset, selectedSpawnZone.GetRandomForce());
                yield return new WaitForSeconds(_cooldownBetweenFruitsSpawn);
            }

            for (int i = 0; i < 10; i++)
            {
                Vector2 spawnPoint = selectedSpawnZone.GetPointAtSegment();
                Bomb bomb = _bombsPool.GetFreeElement();
                activeObjects.AddObject(bomb);
                bomb.OnExplode += blast.CreateBlast;
                bomb.Initialize(_objectConfigs.GetBombConfig());
                bomb.transform.position = spawnPoint;
                bomb.StartMoving(selectedSpawnZone.NormalWithRandomAngleOffset, selectedSpawnZone.GetRandomForce());
                yield return new WaitForSeconds(_cooldownBetweenFruitsSpawn);
            }
        }

            //todo calculate bombs count
        private int GetBombsWithProb()
        {
            if (Random.value < _complicator.GetBombProb)
                return 1;

            return 0;
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

        public void StopSpawn()=>
            StopAllCoroutines();

        public void Restart()
        {
            _complicator.Reset();
            StartCoroutine(SpawnCycle());
        }
    }
}