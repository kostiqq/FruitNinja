using DG.Tweening;
using TMPro;
using UnityEngine;

public class FruitScore : MonoBehaviour
{
    [SerializeField] private TextMeshPro textLabel;
    [SerializeField] private float flySpeed = 5f;
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
        transform.DOMove(transform.position + Vector3.up * 7f, 2f);
        textLabel.DOColor(_zeroAlphaColor, 2f).OnComplete(()=> Destroy(gameObject));
    }
}
