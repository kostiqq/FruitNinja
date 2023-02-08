using TMPro;
using UnityEngine;

namespace UI
{
    public class FruitPoints : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointsCount;
        
        public void Construct(int points)
        {
            pointsCount.text = points.ToString();
        }

        public void Play()
        {
            //todo animation
        }
    }
}