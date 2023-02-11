using UnityEngine;

public class PlayZone : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;

    private Vector2 _zoneSize;
    private Vector2 _leftBottom;
    private Vector2 _rightTop;
    private Vector2 _halfSize;

    private void Awake()
    {
        InitFieldSize();
    }

    public Vector2 PositionFromPercentage(Vector2 percentage)=> 
        new Vector2(_zoneSize.x * percentage.x - _halfSize.x, _zoneSize.y * percentage.y - _halfSize.y);
    
    private void InitFieldSize()
    {
        _leftBottom = gameCamera.ScreenToWorldPoint(Vector3.zero);
        _rightTop = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        _zoneSize = new Vector2(Mathf.Abs(_leftBottom.x) + Mathf.Abs(_rightTop.x),
            Mathf.Abs(_leftBottom.y) + Mathf.Abs(_rightTop.y));
            
        _halfSize = _zoneSize / 2;
    }
}
