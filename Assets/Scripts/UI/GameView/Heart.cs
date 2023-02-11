using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Image leftPart;
    [SerializeField] private Image rightPart;

    public void DestroyAnimation()
    {
        Destroy(gameObject);
    }
}
