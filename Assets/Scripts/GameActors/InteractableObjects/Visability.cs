using UnityEngine;

namespace GameActors.InteractableObjects
{
    public class Visability : MonoBehaviour
    {
        public InteractableObject obj;
        private bool _isShowed;

        private void OnBecameInvisible()
        {
            if (!_isShowed)
                return;

            obj.HideObject();
        }

        private void OnBecameVisible()
        {
            _isShowed = true;
        }
    }
}