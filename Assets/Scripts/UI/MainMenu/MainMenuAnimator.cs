using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAnimator : MonoBehaviour
{
    [SerializeField] private float animationTime;
    [SerializeField] private RectTransform canvasRect;
    
    [Header("Animated objects")]
    [SerializeField] private Image rightHouse;
    [SerializeField] private Image leftHouse;
    [SerializeField] private Image lights;
    [SerializeField] private Image backGround;
    [SerializeField] private Image logo;
    [SerializeField] private RectTransform scoreHandler;
    [SerializeField] private Image buttonStart;
    [SerializeField] private Image buttonExit;

    public float GetAnimationTime => animationTime;

    public void StartAnimation()
    {
        scoreHandler.DOScale(Vector2.zero, animationTime);
        buttonStart.transform.DOLocalMoveX(canvasRect.rect.min.x - buttonStart.sprite.rect.width, animationTime);
        buttonExit.transform.DOLocalMoveX(canvasRect.rect.max.x + buttonExit.sprite.rect.width, animationTime);

        rightHouse.transform.DOLocalMoveX(canvasRect.rect.max.x + rightHouse.sprite.rect.width, animationTime);
        leftHouse.transform.DOLocalMoveX(canvasRect.rect.min.x - leftHouse.sprite.rect.width, animationTime);
        
        lights.transform.DOLocalMoveY(canvasRect.rect.max.y + lights.sprite.rect.height, animationTime);
        
        logo.DOFade(0, animationTime);
        backGround.DOFade(0, animationTime);
    }
}
