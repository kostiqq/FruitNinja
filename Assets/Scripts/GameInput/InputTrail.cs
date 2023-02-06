using GameInput;
using UnityEngine;

public class InputTrail : MonoBehaviour
{
    public InputHandler _inputHandler;
    private GameObject _trail;
    
    public void Construct(InputHandler inputHandler, GameObject trail)
    {
        _trail = trail;
        _inputHandler = inputHandler;
    }
    
    private void Start()
    {
        HideTrail();
        _inputHandler.OnSwipe += MoveTrail;
        _inputHandler.OnGetTouch += ShowTrail;
        _inputHandler.OnTouchFinish += HideTrail;
    }

    private void OnDestroy()
    {
        _inputHandler.OnSwipe -= MoveTrail;
        _inputHandler.OnGetTouch -= ShowTrail;
        _inputHandler.OnTouchFinish -= HideTrail;
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
