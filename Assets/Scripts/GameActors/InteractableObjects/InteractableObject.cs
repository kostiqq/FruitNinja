using UnityEngine;

namespace GameActor
{
    [RequireComponent(typeof(Physic))]
    public class InteractableObject : MonoBehaviour, IInteract
    {
        private Physic _physicComponent;
        
        public void Interact()
        {
            
        }
        
        private void Awake()
        {
            _physicComponent = GetComponent<Physic>();
        }

        public void StartMove(Vector3 point)
        {
            _physicComponent.SetPointWhereToFly(point);
        }
    }
}