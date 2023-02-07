using Physics;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    public class Slice : MonoBehaviour
    {
        [SerializeField]private Physic _physicComponent;
        [SerializeField]private Renderer _renderer;
        
        private void OnValidate()
        {
            _physicComponent = GetComponent<Physic>();
            _renderer = GetComponent<Renderer>();
        }

        public void AddForce(Vector3 force)
        {
            _physicComponent.AddForce(force / 1000);
        }

        public void SetSprite(Sprite sprite)
        {
            _renderer.SetSprite(sprite);
        }
    }
}