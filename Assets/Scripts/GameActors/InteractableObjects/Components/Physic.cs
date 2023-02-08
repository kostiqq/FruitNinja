using UnityEngine;

namespace GameActors.InteractableObjects.Components
{
    public class Physic : MonoBehaviour
    {
        private float Gravity = -9.81f;
        private Vector3 _direction;

        public Vector3 Velocity => _direction;

        public void AddForce(Vector3 direction, float f)=>
            _direction = direction.normalized * f;
        
        public void Clear()=>
            _direction = Vector3.zero;
        
        private void Update()
        {
            UseGravity();
            transform.position += _direction * Time.deltaTime;
        }

        private void UseGravity()=>
            _direction += Vector3.up * (Gravity * Time.deltaTime);
    }
}
