using UnityEngine;
using Services.Progress;

namespace GameActors.InteractableObjects
{
    public class PointerIncreaser : MonoBehaviour
    {
        private int _points;
        private ProgressService _progress;

        public void Construct(ProgressService progress)
        {
            _progress = progress;
        }

        public void AddPoints(int points)=>
            _points = points;

        public void IncreasePoints()=>
            _progress.UpdateScore(_points);

        public void RemoveHealth()
        {
            _progress.UpdateHealth(-1);
        }
    }
}