using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private Camera _mainCamera;
    
    private void Awake()
    {
        ScaleBgWithCameraSize();
    }

    private void ScaleBgWithCameraSize()
    {
        Transform backgroundTransform = transform;
        Vector2 spriteSize = _background.sprite.bounds.size;
        
        float cameraHeight = _mainCamera.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(_mainCamera.aspect * cameraHeight, cameraHeight);
        Vector2 scale = backgroundTransform.localScale;
        
        scale.x *= cameraSize.x / spriteSize.x;
        scale.y *= cameraSize.y / spriteSize.y;
        
        backgroundTransform.position = _mainCamera.transform.position;
        backgroundTransform.localScale = scale;
    }
}
