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
        [SerializeField] private ParticleSystem cutEffectPrefab;
        private Sprite _fruitSprite;
        public Sprite GetFruitSprite => _fruitSprite;
        private ParticleSystem _cutParticle;
        
        public Sprite GetSprite => spriteRenderer.sprite;

        private void OnValidate()
        {
            spriteRenderer ??= GetComponent<SpriteRenderer>();
        }
        
        public void Initialize(Sprite rendererSprite, Texture particleTexture)
        {
            _cutParticle = Instantiate(cutEffectPrefab, transform);
            _cutParticle.GetComponent<ParticleSystemRenderer>().material.mainTexture = particleTexture;
            SetSprite(rendererSprite);
            spriteRenderer.sprite = rendererSprite;
            spriteRenderer.sortingOrder = ObjectLayer;
            OnInitialized?.Invoke();
        }

        public void Clear()
        {
            //spriteRenderer.sprite = null;
            OnClean?.Invoke();
        }

        public void PlayEffect()
        {
            _cutParticle.transform.parent = null;
            _cutParticle.Play();
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}