using UnityEngine;
using Random = UnityEngine.Random;

namespace GameActors.Spawner
{
   public class SpawnZone : MonoBehaviour
   {
     [field: SerializeField, Range(0f, 1f)] public float SpawnProbability { get; private set; } = 0.5f;
    
    [Header("Points")]
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform secondPoint;

    [Header("Angles")]
    [SerializeField] private bool mirrorAngles;
    [SerializeField, Range(-90f, 90f)] private float minAngleOffset;
    [SerializeField, Range(-90f, 90f)] private float maxAngleOffset;

    [Header("Gizmos")]
    [SerializeField] private Color color = Color.clear;
    [SerializeField] private float drawPointRadius = 0.1f;

    public Vector3 NormalVectorWithRandomAngleOffset =>
        Vector3.Lerp(NormalVectorWithMinAngleOffset, NormalVectorWithMaxAngleOffset, Random.value);
    
    private Vector3 NormalVector =>
        Vector3.Cross(secondPoint.position - firstPoint.position, RHSVector);
    private Vector3 RHSVector => mirrorAngles ? Vector3.back : Vector3.forward;
    
    private Vector3 NormalVectorWithMinAngleOffset =>
        Quaternion.AngleAxis(minAngleOffset, AxisVector) * NormalVector;
    private Vector3 NormalVectorWithMaxAngleOffset =>
        Quaternion.AngleAxis(maxAngleOffset, AxisVector) * NormalVector;
    private Vector3 AxisVector => mirrorAngles ? Vector3.forward : Vector3.back;

    public Vector3 GetPointAtSegment()
    {
        float length = Random.Range(0, 1f);
        return (1 - length) * firstPoint.position + length * secondPoint.position;
    }
    
    // TODO Move to editor script.
    #region Editor
    [ContextMenu(nameof(OnValidate))]
    private void OnValidate()
    {
        firstPoint = firstPoint == null
            ? CreateChildTransform("FirstPoint")
            : firstPoint;
        secondPoint = secondPoint == null
            ? CreateChildTransform("SecondPoint")
            : secondPoint;
        
        color = color == Color.clear
            ? Random.ColorHSV()
            : color;

        if (minAngleOffset > maxAngleOffset)
        {
            maxAngleOffset = minAngleOffset;
        }
    }

    private Transform CreateChildTransform(string name)
    {
        var point = new GameObject(name).transform;
        point.parent = transform;
        return point;
    }

    private void OnDrawGizmos()
    {
        var firstPosition = firstPoint.position;
        var secondPosition = secondPoint.position;
        
        Gizmos.color = color;
        
        Gizmos.DrawSphere(firstPosition, drawPointRadius);
        Gizmos.DrawLine(firstPosition, secondPosition);
        Gizmos.DrawSphere(secondPosition, drawPointRadius);

        var centerPosition = (firstPosition + secondPosition) / 2;
        //transform.position = centerPosition;
        Gizmos.DrawRay(centerPosition, NormalVectorWithMinAngleOffset);
        Gizmos.DrawRay(centerPosition, NormalVectorWithMaxAngleOffset);
    }
    #endregion
   }
}
