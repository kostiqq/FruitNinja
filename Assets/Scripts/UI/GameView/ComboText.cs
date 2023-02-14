using DG.Tweening;
using Services;
using TMPro;
using UnityEngine;
using Zenject;

public class ComboText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fruitsCount;
    [SerializeField] private string fruitText;
    [SerializeField] private TextMeshProUGUI multiplyer;
    [SerializeField] private float animationSpeed;
        
    [Inject] private IComboTimer _comboTimer;

    private void Start()
    {
        _comboTimer.OnComboIncrease += UpdateComboText;
        transform.localScale = Vector3.zero;
    }

    private void UpdateComboText(int combo, int fruits)
    {
        fruitsCount.text =  fruits + fruitText;
        multiplyer.text = $"{combo}X";
        ShowAnimation();
    }

    private void ShowAnimation()
    {
        transform.DOScale(Vector3.one, animationSpeed/2.1f);
        transform.DOScale(Vector3.zero, animationSpeed).SetDelay(animationSpeed/2);
    }
}
