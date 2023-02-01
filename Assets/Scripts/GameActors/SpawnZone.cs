using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnZone : MonoBehaviour
{
   private Vector3 leftPoint;
   private Vector3 rightPoint;

   private Color _gizmosColor;
   
   private void Awake()
   {
      _gizmosColor = Random.ColorHSV();
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = _gizmosColor;
      Gizmos.DrawLine(leftPoint, rightPoint);
   }
}
