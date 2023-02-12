using System;
using GameActors.InteractableObjects.Components;
using StaticData;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField] protected Renderer renderer;
        [SerializeField] protected ColliderComponent collider;
        [SerializeField] protected Physic physicComponent;
        [SerializeField] protected Visability visability;
        
        public Action<InteractableObject> OnObjectHide;
        
        public Sprite GetSprite =>
            renderer.GetSprite;

        public Vector2 GetVelocity =>
            physicComponent.Velocity;
        
        public virtual void Initialize(InteractableObjectConfig objectConfig)
        {
            visability.OnFruitOutOfScreen += HideFruit;
            renderer.Initialize(objectConfig.FruitSprite, objectConfig.isHaveShadow);
            collider.Enable();
            gameObject.SetActive(true);
        }

        protected void HideFruit()
        {
            HideObject();
            OnObjectHide?.Invoke(this);
        }

        protected virtual void Interact()
        {
        }

        protected void Awake()
        {
            collider.OnColliderEnter += Interact;
        }

        public void HideObject()
        {
           gameObject.SetActive(false);
           ClearState();
        }

        protected virtual void ClearState()
        {
            var objectTransform = transform;
            objectTransform.localScale = Vector3.one;
            objectTransform.rotation = Quaternion.identity;
            renderer.Clear();
            physicComponent.Clear();
        }

        public void StartMoving(Vector3 direction, float force)=>
            physicComponent.AddForce(direction, force);
        
    }
}