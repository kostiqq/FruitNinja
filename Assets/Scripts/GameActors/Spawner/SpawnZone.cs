using GameActor;
using Services.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnZone : MonoBehaviour
{
   private Color _gizmosColor;
   
   private InteractableObjectsPool _pool;
   private Transform _leftPoint;
   private Transform _rightPoint;

   private const float shootAngle = 15;

   private void Awake()
   {
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
      
      spawnedObject.transform.position = GetPointAtSegment(_rightPoint, _leftPoint, Random.Range(0,1f));
   }

   private Vector2 GetDirection()
   {
      var angle = 20f;
      var zoneDirection = (_leftPoint.position - _rightPoint.position).normalized;
      return (Quaternion.Euler(0, 0, angle) * zoneDirection);
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
