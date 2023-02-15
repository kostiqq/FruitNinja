using System;
using GameActors.InteractableObjects.Components;
using StaticData;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField] protected Renderer objectRenderer;
        [SerializeField] protected ColliderComponent objectCollider;
        [SerializeField] protected Physic physicComponent;
        [SerializeField] protected Visability visability;
        
        public Action<InteractableObject> OnObjectHide;
        
        public Sprite GetSprite =>
            objectRenderer.GetSprite;

        public Vector2 GetVelocity =>
            physicComponent.Velocity;
        
        public virtual void Initialize(InteractableObjectConfig objectConfig)
        {
            physicComponent.Clear();
            visability.OnFruitOutOfScreen += HideFruit;
            objectRenderer.Initialize(objectConfig.FruitSprite, objectConfig.isHaveShadow);
            objectCollider.Enable();
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
            objectCollider.OnColliderEnter += Interact;
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
            objectRenderer.Clear();
        }

        public virtual void StartMoving(Vector3 direction, float force)=>
            physicComponent.SetForce(direction, force);

        public void AddForce(Vector3 direction, float force)=>
            physicComponent.AddForce(direction, force);
        
    }
}