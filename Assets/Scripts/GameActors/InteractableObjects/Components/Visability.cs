using System;
using System.Collections;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    public class Visability : MonoBehaviour
    {
        public Action OnFruitOutOfScreen;
        public bool IsEnbled;

        private void OnBecameInvisible()
        {
            if (!IsEnbled)
                return;
            
            OnFruitOutOfScreen?.Invoke();
        }
    }
}