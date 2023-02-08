using Physics;
using StaticData;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(ColliderComponent))]
    [RequireComponent(typeof(Shadow))]
	[RequireComponent(typeof(Effects))]
    public class Fruit : InteractableObject
    {
        [SerializeField] private Shadow shadow;
        [SerializeField] private Effects effects;
        private int _points;
        public int GetPoints => _points;
        private void OnValidate()
        {
            shadow = GetComponent<Shadow>();
            physicComponent = GetComponent<Physic>();
            renderer = GetComponent<Renderer>();
            collider = GetComponent<ColliderComponent>();
            effects = GetComponent<Effects>();
        }

        public override void Construct(InteractableObjectConfig objectConfig)
        {
            base.Construct(objectConfig);
            _points = objectConfig.points;
            effects.Construct(objectConfig.FruitEffectSprite);
        }
        
        protected override void Interact()
        {
            effects.PlayEffects(_points);
            gameObject.SetActive(false);
        }
    }
}