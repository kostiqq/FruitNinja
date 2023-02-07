using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystemRenderer))]
public class SortingOrderDecreaser : MonoBehaviour
{
    [SerializeField] private ParticleSystemRenderer renderer;
    [SerializeField] private int minOrder;
    [SerializeField] private float timeBetweenChange;
    private void OnValidate()
    {
        renderer = GetComponent<ParticleSystemRenderer>();
    }

    private void Start()
    {
        StartCoroutine(ChangeLayerAnimation());
    }

    private IEnumerator ChangeLayerAnimation()
    {
        while (renderer.sortingOrder > minOrder)
        {
            renderer.sortingOrder--;  
            yield return new WaitForSeconds(timeBetweenChange);
        }
    }
}
