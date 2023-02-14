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
    public class BonusLife : InteractableObject
    {
        [SerializeField] private Effects effects;

        private int _points;
        
        public void Construct(ProgressService progress)
        {
            //pointIncreaser.Construct(progress);
        }

        public override void Initialize(InteractableObjectConfig objectConfig)
        {
            base.Initialize(objectConfig);
            effects.Construct(objectConfig.FruitEffectSprite, objectConfig.EffectColor, objectConfig.points);
            //visability.OnFruitOutOfScreen += pointIncreaser.RemoveHealth;
            visability.IsEnbled = true;
        }
        
        protected override void Interact()
        {
            effects.PlayEffects(_points);
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