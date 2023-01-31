using UnityEngine;

namespace GameActor
{
    [RequireComponent(typeof(Physic))]
    public class InteractableObject : MonoBehaviour, IInteract
    {
        public void Interact()
        {
            
        }
    }
}