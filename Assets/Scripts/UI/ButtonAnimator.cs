using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image btnImage;
    [SerializeField] private Sprite buttonSprite;
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private EventSystem eventSystem;

    public Action OnTouchPerformed;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        btnImage.sprite = pressedSprite;
        transform.DOShakeScale(0.5f, 0.2f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        btnImage.sprite = buttonSprite;
        transform.DOScale(Vector3.one, 0.2f);
        OnTouchPerformed?.Invoke();
        eventSystem.enabled = false;
    }
}
