﻿using Physics;
using StaticData;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField] protected Renderer renderer;
        [SerializeField] protected ColliderComponent collider;
        [SerializeField] protected Physic physicComponent;
        
        public Sprite GetSprite =>
            renderer.GetSprite;

        public Vector2 GetVelocity =>
            physicComponent.Velocity;
        
        public virtual void Initialize(InteractableObjectConfig objectConfig)
        {
            renderer.Initialize(objectConfig.FruitSprite, objectConfig.FruitEffectSprite, objectConfig.isHaveShadow);
            collider.Enable();
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

        public void StartMoving(Vector3 normalVectorWithRandomAngleOffset)=>
            physicComponent.AddForce(normalVectorWithRandomAngleOffset);
        
    }
}