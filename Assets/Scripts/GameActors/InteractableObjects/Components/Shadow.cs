using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Renderer))]
    public class Shadow : MonoBehaviour
    {
        private const int ShadowLayer = 3;
        [SerializeField] private Renderer render;
        [SerializeField] private Vector2 offset;

        private Transform _shadow;

        private void OnValidate()
        {
            render ??= GetComponent<Renderer>();
        }

        private void Awake()
        {
            render.OnInitialized += InitializeShadow;
            render.OnClean += RemoveShadow;
        }
        
        private void InitializeShadow()
        {
            var sprite = render.GetSprite;
            var shadowObject = new GameObject("Shadow");
            _shadow = shadowObject.transform;
            _shadow.localScale = Vector3.one;
            _shadow.SetParent(transform);
            _shadow.position = transform.position + (Vector3)offset;
            var shadowRender = shadowObject.AddComponent<SpriteRenderer>();
            shadowRender.color = new Color(0,0,0,0.5f);
            shadowRender.sprite = sprite;
            shadowRender.sortingOrder = ShadowLayer;
        }
        
        private void RemoveShadow()
        {
            if(_shadow != null) 
                Destroy(_shadow.gameObject);
        }


        private void LateUpdate()
        {
            if (_shadow == null)
                return;
            
            _shadow.position = transform.position + (Vector3)offset;
            _shadow.rotation = transform.rotation;
        }
    }
}