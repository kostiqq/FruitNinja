using GameActor;
using Physics;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Physic))]
    public class InteractableObject : MonoBehaviour, IInteract
    {
        [SerializeField] private Physic _physicComponent;

        private Vector3 _spawnPos;
        public void Interact()
        {
            
        }
        
        private void Awake()
        {
            _spawnPos = transform.position;
        }

        public void StartMove(Vector3 direction, float force)
        {
            _physicComponent.AddForce(direction, force);
        }

        public void HideObject()
        {
           gameObject.SetActive(false);
           transform.position = _spawnPos;
        }

    }
}