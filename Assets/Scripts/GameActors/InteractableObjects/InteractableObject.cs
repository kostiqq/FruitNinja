using GameActor;
using Physics;
using StaticData;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(ColliderComponent))]
    public class InteractableObject : MonoBehaviour, IInteract
    {
        [SerializeField] private Physic physicComponent;
        [SerializeField] private Renderer renderer;
        [SerializeField] private ColliderComponent collider;
        
        private Vector3 _spawnPos;

        private void OnValidate()
        {
            physicComponent = GetComponent<Physic>();
            renderer = GetComponent<Renderer>();
            collider = GetComponent<ColliderComponent>();
        }

        public void Interact()
        {
            renderer.PlayEffect();
            gameObject.SetActive(false);
        }
        
        private void Awake()
        {
            collider.OnColliderEnter += Interact;
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

        public void BuildFruit(FruitConfig fruitConfig)
        {
            renderer.Initialize(fruitConfig.FruitSprite, fruitConfig.FruitEffectSprite);
            collider.Initialize();
        }
    }
}