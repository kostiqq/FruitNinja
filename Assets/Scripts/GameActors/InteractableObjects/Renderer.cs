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
        public Sprite GetSprite => spriteRenderer.sprite;

        private void OnValidate()
        {
            spriteRenderer ??= GetComponent<SpriteRenderer>();
        }
        
        public void Initialize(Sprite rendererSprite)
        {
            spriteRenderer.sprite = rendererSprite;
            spriteRenderer.sortingOrder = ObjectLayer;
            OnInitialized?.Invoke();
        }

        public void Clear()
        {
            spriteRenderer.sprite = null;
            OnClean?.Invoke();
        }
    }
}