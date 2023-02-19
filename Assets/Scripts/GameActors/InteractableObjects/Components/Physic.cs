using Services;
using UnityEngine;

namespace GameActors.InteractableObjects.Components
{
    public class Physic : MonoBehaviour
    {
        [SerializeField] private float speed = 1.1f;
        private float Gravity = -9.81f;
        private Vector3 _direction;

        private TimeScaler gameTime;
        
        private void Start()
        {
            gameTime = TimeScaler.Instance;
        }

        public Vector3 Velocity => _direction;

        public void SetForce(Vector3 direction, float f)=>
            _direction = direction.normalized * f;

        public void AddForce(Vector3 direction, float f)=>
            _direction += direction.normalized * f;
        
        public void Clear()=>
            _direction = Vector3.zero;
        
        private void Update()
        {
            UseGravity();
            transform.position += _direction * (gameTime.TimeScale * speed);
        }

        private void UseGravity()=>
            _direction += Vector3.up * (Gravity * gameTime.TimeScale * speed);
    }
}
