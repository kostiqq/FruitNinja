using GameInput;
using UnityEngine;

public class InputTrail : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private GameObject _trail;
    
    public void Start()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        _trail.transform.SetParent(transform);
        HideTrail();
        _inputHandler.OnGetTouch += ShowTrail;
        _inputHandler.OnTouchFinish += HideTrail;
    }

    private void OnDestroy()
    {
        _inputHandler.OnGetTouch -= ShowTrail;
        _inputHandler.OnTouchFinish -= HideTrail;
    }

    public void Update()
    {
        _trail.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void ShowTrail(Vector3 startPosition)
    {
        _trail.transform.position = startPosition;
        _trail.SetActive(true);
    }
    
    private void HideTrail()=>
        _trail.SetActive(false);

    private void MoveTrail(Vector3 touchPosition)=> 
        _trail.transform.position = touchPosition;
}
