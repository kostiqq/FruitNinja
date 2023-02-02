using UnityEngine;

namespace Physics
{
    public class Physic : MonoBehaviour
    {
        private const float _gravity = -0.1f;
        private const float _speedScaler = 1.2f;
        
        private Vector3 _velocity;
        private Vector3 _nextPoint;
        private Vector3 _gravityForce;
        
        private float _timer;
    
        public void AddForce(Vector3 direction, float force)
        {
            _gravityForce = new Vector3(0,_gravity, 0);
            _timer = 0;
            _velocity = direction.normalized * force;
        }
    
        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _nextPoint, Time.deltaTime);
            _nextPoint = GetNextPoint();
        }

        private Vector3 GetNextPoint()
        {
            _timer += Time.deltaTime;
            var newPos = transform.position + (_velocity + _gravityForce * (Mathf.Pow(_timer, 2) * _speedScaler));
            _velocity += _gravityForce * _timer;
            return newPos;
        }
    }
}
