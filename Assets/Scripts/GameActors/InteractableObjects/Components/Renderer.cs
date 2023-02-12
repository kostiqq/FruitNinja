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
        private Sprite _fruitSprite;
        public Sprite GetFruitSprite => _fruitSprite;

        public Sprite GetSprite => spriteRenderer.sprite;

        public void Initialize(Sprite rendererSprite, bool isHaveShadow)
        {
            SetSprite(rendererSprite);
            spriteRenderer.sprite = rendererSprite;
            spriteRenderer.sortingOrder = ObjectLayer;
            
            if (isHaveShadow)
                CreateShadow();
            OnInitialized?.Invoke();
        }

        private void CreateShadow()
        {
            var shadow = gameObject.AddComponent<Shadow>();
            shadow.InitializeShadow(this);
        }

        public void Clear()=>
            OnClean?.Invoke();
        
        public void SetSprite(Sprite sprite)=>
            spriteRenderer.sprite = sprite;
    }
}