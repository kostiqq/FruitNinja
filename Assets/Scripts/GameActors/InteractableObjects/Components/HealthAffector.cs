using Services.Progress;
using UnityEngine;

namespace GameActors.InteractableObjects.Components
{
    public class HealthAffector : MonoBehaviour
    {
        [SerializeField] private int healthToRestore = 1;
        
        private ProgressService _progress;
        public void Construct(ProgressService progress)
        {
            _progress = progress;
        }

        public void UpdateHealth()=>
            _progress.UpdateHealth(healthToRestore);
    }
}