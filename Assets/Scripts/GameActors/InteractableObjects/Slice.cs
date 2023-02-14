using GameActors.InteractableObjects.Components;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    public class Slice : MonoBehaviour
    {
        [SerializeField] private Physic _physicComponent;
        [SerializeField] private Renderer _renderer;
        private const float force = 6f;
        
        private void OnValidate()
        {
            _physicComponent = GetComponent<Physic>();
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            CreateShadow();
        }

        public void AddForce(Vector3 direction)=>
            _physicComponent.SetForce(direction, force);

        public void SetSprite(Sprite sprite)=>
            _renderer.SetSprite(sprite);

        private void OnBecameInvisible()=>
            Destroy(gameObject);
        
        private void CreateShadow()
        {
            var shadow = gameObject.AddComponent<Shadow>();
            shadow.InitializeShadow(_renderer);
        }
    }
}