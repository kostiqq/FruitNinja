using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameTextMeshPro : MonoBehaviour
{
    [SerializeField] private TextMeshPro textLabel;
    [SerializeField] private float flySpeed = 5f;
    [SerializeField] private float animationDuration = 2f;
    private Color _zeroAlphaColor;

    private void Awake()
    {
        _zeroAlphaColor = textLabel.color;
        _zeroAlphaColor.a = 0;
    }

    public void SetScore(int points)
    {
        textLabel.text = points.ToString();
    }

    public void StartAnimation()
    {
        transform.DOMove(transform.position + Vector3.up * flySpeed, animationDuration);
        textLabel.DOColor(_zeroAlphaColor, animationDuration).OnComplete(()=> Destroy(gameObject));
    }
}
