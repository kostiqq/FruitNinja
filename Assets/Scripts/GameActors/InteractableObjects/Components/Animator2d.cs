using Physics;
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
        
        private bool _isRotateAnimationActive;
        private float _rotationSpeed;

        private bool _isSizeAnimationActive;

        private void OnValidate()
        {
            rigidObject = GetComponent<Physic>();
        }

        private void Start()
        {
            if(Random.value > 0.5f)
                StartRotateAnimation();
            if(Random.value < 0.5f)
                StartSizeAnimation();
        }

        private void StartSizeAnimation()=>
            _isSizeAnimationActive = rigidObject != null;
        
        private void StartRotateAnimation()
        {
            var randomValue = Random.Range(-maxRotationAngle, maxRotationAngle);
            _rotationSpeed = randomValue * Time.deltaTime;
            _isRotateAnimationActive = true;
        }
        
        private void Update()
        {
            if(_isRotateAnimationActive)
                RotateObject();

            if (_isSizeAnimationActive)
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