using System;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Renderer : MonoBehaviour
    {
        private const int ObjectLayer = 4;
        public event Action OnInitialized;
        public event Action OnClean;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private ParticleSystem cutEffect;
        [SerializeField] private ParticleSystemRenderer particleSystemRenderer;
        public Sprite GetSprite => spriteRenderer.sprite;

        private void OnValidate()
        {
            spriteRenderer ??= GetComponent<SpriteRenderer>();
        }
        
        public void Initialize(Sprite rendererSprite, Texture particleTexture)
        {
            particleSystemRenderer.material.mainTexture = particleTexture;
            spriteRenderer.sprite = rendererSprite;
            spriteRenderer.sortingOrder = ObjectLayer;
            OnInitialized?.Invoke();
        }

        public void Clear()
        {
            spriteRenderer.sprite = null;
            OnClean?.Invoke();
        }

        public void PlayEffect()
        {
            cutEffect.transform.parent = null;
            cutEffect.Play();
        }
    }
}