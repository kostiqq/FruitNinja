using UnityEngine;

namespace GameActors.InteractableObjects
{
    public class ColliderComponent : MonoBehaviour
    {
        public Vector3 Position => transform.position;
        public float Radius = 1f;

        public void CollisionEnter()
        {
            Debug.LogError("OnCollisitionEnter");
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}