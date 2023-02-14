using System;
using GameActors.InteractableObjects.Components;
using Services.Progress;
using StaticData;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Effects))]
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(ColliderComponent))]    
    [RequireComponent(typeof(Visability))]
    public class Bomb : InteractableObject
    {
        [SerializeField] private Effects effects;
        [SerializeField] private HealthAffector healthAffector;
        
        private int _points;

        public Action<Vector3> OnExplode; 
        public void Construct(ProgressService progress)
        {
            healthAffector.Construct(progress);
        }

        public override void Initialize(InteractableObjectConfig objectConfig)
        {
            base.Initialize(objectConfig);
            effects.Construct(objectConfig.FruitEffectSprite, objectConfig.EffectColor, objectConfig.points);
            visability.IsEnbled = true;
        }
        
        protected override void Interact()
        {
            effects.PlayEffects(_points);
            OnExplode?.Invoke(transform.position);
            healthAffector.UpdateHealth();
            ClearState();
            gameObject.SetActive(false);
        }

        protected override void ClearState()
        {
            visability.IsEnbled = false;
            base.ClearState();
        }
    }
}