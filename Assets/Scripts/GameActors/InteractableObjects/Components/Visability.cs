using System;
using System.Collections;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    public class Visability : MonoBehaviour
    {
        private bool _isShowed;
        public Action OnFruitOutOfScreen;
        public bool IsEnbled;

        private void OnBecameInvisible()
        {
            if (!IsEnbled)
                return;
            
            OnFruitOutOfScreen?.Invoke();
        }

        private void OnBecameVisible()
        {
            _isShowed = true;
        }
    }
}