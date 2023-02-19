using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private static readonly int Die = Animator.StringToHash("Die");
    
    [SerializeField] private Image leftPart;
    [SerializeField] private Image rightPart;
    [SerializeField] private Animator animator;

    public float sizeX() =>
        leftPart.sprite.rect.width * 2;
    
    public void DestroyAnimation()=>
        animator.SetTrigger(Die);
    
    private void OnDisable()=>
        Destroy(gameObject);
}
