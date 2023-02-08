using System;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    public class ColliderComponent : MonoBehaviour
    {
        public Vector3 Position => transform.position;
        public bool IsEnabled { get; set; }

        public float Radius = 1f;

        public Action OnColliderEnter;

        public void Enable()=>
            IsEnabled = true;
        
        public void CollisionEnter()
        {
            IsEnabled = false;
            OnColliderEnter?.Invoke();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}