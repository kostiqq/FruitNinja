using GameActor;
using Physics;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    public class InteractableObject : MonoBehaviour, IInteract
    {
        [SerializeField] private Physic physicComponent;
        [SerializeField] private Renderer renderer;

        private Vector3 _spawnPos;

        private void OnValidate()
        {
            physicComponent = GetComponent<Physic>();
            renderer = GetComponent<Renderer>();
        }

        public void Interact()
        {
            
        }
        
        private void Awake()
        {
            _spawnPos = transform.position;
        }

        public void HideObject()
        {
           gameObject.SetActive(false);
           ClearState();
        }

        private void ClearState()
        {
            var objectTransform = transform;
            objectTransform.position = _spawnPos;
            objectTransform.localScale = Vector3.one;
            objectTransform.rotation = Quaternion.identity;
            renderer.Clear();
            physicComponent.Clear();
        }

        public void StartMoving(Vector3 normalVectorWithRandomAngleOffset)=>
            physicComponent.AddForce(normalVectorWithRandomAngleOffset);
        
        public void SetSprite(Sprite objectImage)=>
            renderer.Initialize(objectImage);
    }
}