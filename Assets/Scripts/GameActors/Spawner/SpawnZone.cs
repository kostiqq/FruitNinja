using UnityEngine;
using Random = UnityEngine.Random;

namespace GameActors.Spawner
{
    public class SpawnZone : MonoBehaviour
    {
        [Header("Gizmos")] 
        [SerializeField] private Color color = Color.clear;
        [SerializeField] private float drawPointRadius = 0.1f;

        [Header("Points")] 
        [SerializeField] private Transform firstPoint;
        [SerializeField] private Transform secondPoint;
        [SerializeField] [Range(-90f, 90f)] private float maxAngleOffset;
        [SerializeField] [Range(-90f, 90f)] private float minAngleOffset;
        [SerializeField] private Vector2 positionOnScreen;
        [SerializeField] private Vector2 ForceRange;

        public Vector2 GetPositionOnScreen => positionOnScreen;
        [Header("Angles")] 
        [SerializeField] private bool mirrorAngles;

        [Range(0f, 1f)] 
        public float SpawnProbability;


        public Vector3 NormalWithRandomAngleOffset =>
            Vector3.Lerp(NormalWithMinAngleOffset, NormalWithMaxAngleOffset, Random.value);

        private Vector3 Normal =>
            Vector3.Cross(secondPoint.position - firstPoint.position, AngleDirection);

        private Vector3 AngleDirection => mirrorAngles ? Vector3.back : Vector3.forward;

        private Vector3 NormalWithMinAngleOffset =>
            Quaternion.AngleAxis(minAngleOffset, AxisVector) * Normal;

        private Vector3 NormalWithMaxAngleOffset =>
            Quaternion.AngleAxis(maxAngleOffset, AxisVector) * Normal;

        private Vector3 AxisVector => mirrorAngles ? Vector3.forward : Vector3.back;

        public Vector3 GetPointAtSegment()
        {
            var length = Random.Range(0, 1f);
            return (1 - length) * firstPoint.position + length * secondPoint.position;
        }

        public float GetRandomForce() =>
            Random.Range(ForceRange.x, ForceRange.y);
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

            
            if (minAngleOffset > maxAngleOffset) maxAngleOffset = minAngleOffset;
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
            Gizmos.DrawRay(centerPosition, NormalWithMinAngleOffset);
            Gizmos.DrawRay(centerPosition, NormalWithMaxAngleOffset);
        }

        #endregion
    }
}