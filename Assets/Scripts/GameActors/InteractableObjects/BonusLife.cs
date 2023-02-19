using System;
using GameActors.InteractableObjects.Components;
using Services.Progress;
using StaticData;
using UnityEngine;
using Zenject;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Effects))]
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(ColliderComponent))]    
    [RequireComponent(typeof(Visability))]
    [RequireComponent(typeof(HealthAffector))]
    public class BonusLife : InteractableObject
    {
        [SerializeField] private Effects effects;
        [SerializeField] private HealthAffector healthAffector;
        [SerializeField] private float forceMultiplyer = 1.5f;

        private int _points;
        public Action<BonusLife, Vector3> OnLifeEarned;
        
        public void Construct(ProgressService progress)
        {
            healthAffector.Construct(progress);
        }

        public override void Initialize(InteractableObjectConfig objectConfig)
        {
            base.Initialize(objectConfig);
            effects.Construct(objectConfig.FruitEffectSprite, objectConfig.EffectColor);
            visability.IsEnbled = true;
        }
        
        protected override void Interact()
        {
            OnLifeEarned?.Invoke(this, transform.position);
            healthAffector.UpdateHealth();
            effects.PlayEffects(_points);
            ClearState();
            gameObject.SetActive(false);
        }

        protected override void ClearState()
        {
            visability.IsEnbled = false;
            base.ClearState();
        }

        public override void StartMoving(Vector3 direction, float force)
        {
            base.StartMoving(direction, force + forceMultiplyer);
        }
    }
}