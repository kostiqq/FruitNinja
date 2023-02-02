using GameActors.InteractableObjects;
using Services.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameActors.Spawner
{
   public class SpawnZone : MonoBehaviour
   {
      private const float MaxForce = 6;
      private const float MinForce = 5f;
      
      private Color _gizmosColor;
      private InteractableObjectsPool _pool;
      private Transform _leftPoint;
      private Transform _rightPoint;
      private Camera _mainCamera;

      private void Awake()
      {
         _mainCamera = Camera.main;
         _gizmosColor = Random.ColorHSV();
      }

      public void Initialize(Vector2 leftPoint, Vector2 rightPoint, InteractableObjectsPool pool)
      {
         _leftPoint = new GameObject("Left Point").transform;
         _leftPoint.SetParent(transform);
         _leftPoint.position = leftPoint;
      
         _rightPoint = new GameObject("Right Point").transform;
         _rightPoint.SetParent(transform);
         _rightPoint.position = rightPoint;
         _pool = pool;
      }
   
      public void SpawnWave()
      {
         InteractableObject spawnedObject = _pool.GetFreeElement();
         var point = GetPointAtSegment(_rightPoint, _leftPoint, Random.Range(0, 1f));
      
         spawnedObject.transform.position = point;
         var targetPosition =
            _mainCamera.ScreenToWorldPoint(new Vector3(_mainCamera.pixelWidth / 2, _mainCamera.pixelHeight * 1.5f));
         var throwVector = targetPosition - spawnedObject.transform.position;

         spawnedObject.StartMove(throwVector, Random.Range(MinForce,MaxForce));
      }
   
      private Vector3 GetPointAtSegment(Transform firstPoint, Transform secondPoint, float length)
      {
         Vector3 pointPosition = (1 - length) * firstPoint.position + length * secondPoint.position;
      
         return pointPosition;
      }

      private void OnDrawGizmos()
      {
         Gizmos.color = _gizmosColor;
         Gizmos.DrawLine(_leftPoint.position, _rightPoint.position);
      }
   }
}
