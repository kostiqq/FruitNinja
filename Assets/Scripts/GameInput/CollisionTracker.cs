using System;
using System.Collections.Generic;
using GameActors.InteractableObjects;
using UnityEngine;

namespace GameInput
{
    public class CollisionTracker : MonoBehaviour
    {
        public InputHandler _inputHandler;

        public List<ColliderComponent> _colliderObjects = new List<ColliderComponent>();
        
        private void OnDestroy()
        {
            _inputHandler.OnSwipe -= TrackCollision;
        }

        private void Awake()
        {
            _inputHandler.OnSwipe += TrackCollision;
        }

        public void Construct(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _inputHandler.OnSwipe += TrackCollision;
        }

        public void AddColliderObject(ColliderComponent collider)
        {
            _colliderObjects.Add(collider);
        }
        
        private void TrackCollision(Vector3 touchPosition)
        {
            var collidersCount = _colliderObjects.Count;
            for (int i = 0; i < collidersCount; i++)
            {
                if (Vector3.Distance(touchPosition, _colliderObjects[i].Position) <= _colliderObjects[i].Radius 
                    && _colliderObjects[i].IsEnabled)
                    _colliderObjects[i].CollisionEnter();
            }
        }
    }
}
