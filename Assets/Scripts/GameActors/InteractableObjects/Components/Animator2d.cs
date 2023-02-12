using GameActors.InteractableObjects.Components;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Physic))]
    public class Animator2d : MonoBehaviour
    {
        
        [Header("Rotation parameters")]
        [SerializeField] private float maxRotationAngle;
        [Space(5)] 
        [Header("Size parameters")]
        [SerializeField] private float sizeParameter;
        [SerializeField] private Physic rigidObject;
        
        private float _rotationSpeed;

        private bool _isSizeAnimationActive;

        private void Start()
        {
            StartRotateAnimation();
            StartSizeAnimation();
        }

        private void StartSizeAnimation()=>
            _isSizeAnimationActive = rigidObject != null;
        
        private void StartRotateAnimation()
        {
            var randomValue = Random.Range(-maxRotationAngle, maxRotationAngle);
            _rotationSpeed = randomValue * Time.deltaTime;
        }
        
        private void Update()
        {
            RotateObject();
            ChangeObjectSizeByMotion();
        }

        private void ChangeObjectSizeByMotion()
        {
            var velocity = rigidObject.Velocity;
            transform.localScale += Vector3.one * (sizeParameter * (velocity.y > 0 ? 1f : -1f) * Time.deltaTime);
        }

        private void RotateObject()=>
            transform.Rotate(Vector3.forward, _rotationSpeed);
    }
}