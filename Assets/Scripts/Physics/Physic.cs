using UnityEngine;

namespace Physics
{
    public class Physic : MonoBehaviour
    {
        private const float Gravity = -9.81f;
        private const float ForceCoef = 9f;
        private const float IncreaseCoef = 1.5f;
        private Vector3 _direction;

        public Vector3 Velocity => _direction;

        public void AddForce(Vector3 direction)
        {
            float forceCoef = ForceCoef;
            if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
                forceCoef *= IncreaseCoef;
            
            _direction += direction.normalized * forceCoef;
        }
            
        
        private void Update()
        {
            UseGravity();
            transform.position += _direction * Time.deltaTime;
        }

        private void UseGravity()=>
            _direction += Vector3.up * (Gravity * Time.deltaTime);
        
        public void Clear()=>
            _direction = Vector3.zero;
    }
}
