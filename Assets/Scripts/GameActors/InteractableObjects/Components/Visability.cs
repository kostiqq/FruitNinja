using System;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    public class Visability : MonoBehaviour
    {
        private bool _isShowed;
        public Action OnFruitOutOfScreen;

        private void OnBecameInvisible()
        {
            if (!_isShowed)
                return;
            
            OnFruitOutOfScreen?.Invoke();
        }

        private void OnBecameVisible()
        {
            _isShowed = true;
        }
    }
}