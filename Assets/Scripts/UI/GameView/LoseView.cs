using DG.Tweening;
using UnityEngine;

public class LoseView : MonoBehaviour
{
    
    public void ShowAnimation()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOScale(Vector3.one, 1f);
    }
}
