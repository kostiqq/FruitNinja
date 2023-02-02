using System.Collections;
using System.Collections.Generic;
using GameActors.Spawner;
using Infrastructure;
using Services.Factory;
using StaticData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameActor
{
    public class SpawnerController : MonoBehaviour
    {
        private const int PoolCapacity = 50;
        private const float PointOffset = 1.5f;
        
        private SpawnerSettings _spawnerSettings;
        private List<SpawnZone> _spawnZones;
        private InteractableObjectsPool _pool;
        private Camera _mainCamera;
        private Coroutine _spawnCoroutine;

        private Vector2 leftBotCamera;
        private Vector2 rightTopCamera;
        
        public void Construct(InteractableObject loadInteractableObject)
        {
            _mainCamera = Camera.main;
            CalculateScreenBounds();
            
            _pool = new InteractableObjectsPool(loadInteractableObject, PoolCapacity, new GameObject("ObjectPool").transform);
            _spawnerSettings = Bootstrapper.Instance.GetSpawnerSettings;
            _spawnZones = new List<SpawnZone>();

            foreach (var SpawnerParameters in _spawnerSettings.Spawners)
                CreateSpawner(SpawnerParameters);
            
            _spawnCoroutine = StartCoroutine(Spawn());
        }

        private void CreateSpawner(SpawnerParameters spawnerParameters)
        {
            GameObject spawnerObject = new GameObject($"{spawnerParameters.Position} Spawner");
            spawnerObject.transform.SetParent(transform);
            spawnerObject.transform.position = CalculateSpawnerPosition(spawnerParameters, out Vector2 leftBound, out Vector2 rightBound);
            
            SpawnZone spawnerComponent = spawnerObject.AddComponent<SpawnZone>();
            spawnerComponent.Initialize(leftBound, rightBound, _pool);
            _spawnZones.Add(spawnerComponent);
        }

        //todo refactor this
        private Vector3 CalculateSpawnerPosition(SpawnerParameters spawnerParameters, out Vector2 leftBound, out Vector2 rightBound)
        {
            leftBound = Vector2.zero;
            rightBound = Vector2.zero;
            
            switch (spawnerParameters.Position)
            {
                case SpawnerPosition.Bottom:
                    leftBound = new Vector2(GetPointInGame(leftBotCamera.x,rightTopCamera.x, leftBotCamera.x, spawnerParameters.LeftPoint), leftBotCamera.y - PointOffset);
                    rightBound = new Vector2(GetPointInGame(leftBotCamera.x,rightTopCamera.x, leftBotCamera.x,spawnerParameters.RightPoint), leftBotCamera.y - PointOffset);
                    return new Vector3((leftBound.x + rightBound.x)/2, leftBotCamera.y,0);
                case SpawnerPosition.Left:
                    leftBound = new Vector2(leftBotCamera.x - PointOffset, GetPointInGame(leftBotCamera.y, rightTopCamera.y ,leftBotCamera.y , spawnerParameters.LeftPoint));
                    rightBound = new Vector2(leftBotCamera.x - PointOffset, GetPointInGame(leftBotCamera.y, rightTopCamera.y, leftBotCamera.y , spawnerParameters.RightPoint));
                    return new Vector3(leftBotCamera.x,(leftBound.y + rightBound.y)/2,0);
                case SpawnerPosition.LeftAngle:
                    leftBound = new Vector2(leftBotCamera.x - PointOffset, GetPointInGame(leftBotCamera.y, rightTopCamera.y, leftBotCamera.y, spawnerParameters.LeftPoint));
                    rightBound = new Vector2(GetPointInGame(leftBotCamera.x,rightTopCamera.x, leftBotCamera.x, spawnerParameters.RightPoint), leftBotCamera.y - PointOffset);
                    return new Vector3(leftBotCamera.x,0,0);
                case SpawnerPosition.Right:
                    leftBound = new Vector2(rightTopCamera.x + PointOffset, GetPointInGame(leftBotCamera.y, rightTopCamera.y, leftBotCamera.y, spawnerParameters.LeftPoint));
                    rightBound = new Vector2(rightTopCamera.x + PointOffset,GetPointInGame(leftBotCamera.y, rightTopCamera.y, leftBotCamera.y, spawnerParameters.RightPoint));
                    return new Vector3(rightTopCamera.x,(leftBound.y + rightBound.y)/2,0);
                case SpawnerPosition.RightAngle:
                    leftBound = new Vector2(rightTopCamera.x - PointOffset, GetPointInGame(leftBotCamera.y,rightTopCamera.y, leftBotCamera.y, spawnerParameters.LeftPoint));
                    rightBound = new Vector2(rightTopCamera.x - (rightTopCamera.x - leftBotCamera.x) * spawnerParameters.RightPoint, leftBotCamera.y - PointOffset);
                    return new Vector3(rightTopCamera.x,leftBotCamera.y,0);
                default:
                    Debug.LogError($"Incorrect spawner position on screen {spawnerParameters.Position}");
                    return Vector3.zero;
            }
        }

        private float GetPointInGame(float startPoint, float x, float y, float precent)=> 
            startPoint + (x - y) * precent;
        

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
            int RandomSpawnIndex = Random.Range(0, _spawnZones.Count);
            _spawnZones[RandomSpawnIndex].SpawnWave();
        }
        
        private void CalculateScreenBounds()
        {
            leftBotCamera = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, _mainCamera.nearClipPlane));
            rightTopCamera = _mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, _mainCamera.nearClipPlane));
        }
    }
}