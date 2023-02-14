using GameActors.InteractableObjects.Components;
using Services.Progress;
using StaticData;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(ColliderComponent))]
    [RequireComponent(typeof(Shadow))]
	[RequireComponent(typeof(Effects))]
    [RequireComponent(typeof(PointerIncreaser))]
    [RequireComponent(typeof(Visability))]
    public class Fruit : InteractableObject
    {
        [SerializeField] private Shadow shadow;
        [SerializeField] private Effects effects;
        [SerializeField] private PointerIncreaser pointIncreaser;

        private int _points;
        
        public void Construct(ProgressService progress)
        {
            pointIncreaser.Construct(progress);
        }

        public override void Initialize(InteractableObjectConfig objectConfig)
        {
            base.Initialize(objectConfig);
            pointIncreaser.AddPoints(objectConfig.points);
            effects.Construct(objectConfig.FruitEffectSprite, objectConfig.EffectColor, objectConfig.points);
            visability.OnFruitOutOfScreen += pointIncreaser.RemoveHealth;
            visability.IsEnbled = true;
        }
        
        protected override void Interact()
        {
            effects.PlayEffects(_points);
            pointIncreaser.IncreasePoints();
            ClearState();
            gameObject.SetActive(false);
        }

        protected override void ClearState()
        {
            visability.IsEnbled = false;
            base.ClearState();
            visability.OnFruitOutOfScreen -= pointIncreaser.RemoveHealth;
        }
    }
}