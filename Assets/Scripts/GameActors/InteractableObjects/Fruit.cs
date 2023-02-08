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
    public class Fruit : InteractableObject
    {
        [SerializeField] private Shadow shadow;
        [SerializeField] private Effects effects;
        [SerializeField] private PointerIncreaser pointIncreaser;
        private int _points;
        
        private void OnValidate()
        {
            shadow = GetComponent<Shadow>();
            physicComponent = GetComponent<Physic>();
            renderer = GetComponent<Renderer>();
            collider = GetComponent<ColliderComponent>();
            effects = GetComponent<Effects>();
            pointIncreaser = GetComponent<PointerIncreaser>();
        }
        
        public void Construct(ProgressService progress)
        {
            pointIncreaser.Construct(progress);
        }

        public override void Initialize(InteractableObjectConfig objectConfig)
        {
            base.Initialize(objectConfig);
            pointIncreaser.AddPoints(objectConfig.points);
            effects.Construct(objectConfig.FruitEffectSprite);
        }
        
        protected override void Interact()
        {
            effects.PlayEffects(_points);
            pointIncreaser.IncreasePoints();
            gameObject.SetActive(false);
            ClearState();
        }
    }
}