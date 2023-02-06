using System.Collections.Generic;
using GameActors.InteractableObjects;
using GameInput;
using UnityEngine;

namespace GameInput
{
    public class CollisionTracker : MonoBehaviour
    {
        public InputHandler _inputHandler;
        
        
        public List<ColliderComponent> _colliderObjects = new List<ColliderComponent>();

        private void Start()
        {
            _inputHandler.OnSwipe += TrackCollision;
        }
        
        private void OnDestroy()
        {
            _inputHandler.OnSwipe -= TrackCollision;
        }

        public void Construct(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void AddColliderObject(ColliderComponent collider)
        {
            _colliderObjects.Add(collider);
        }

        private void RemoveColliderObject(ColliderComponent collider)
        {
            _colliderObjects.Remove(collider);
        }

        private void TrackCollision(Vector3 touchPosition)
        {
            var collidersCount = _colliderObjects.Count;
            for (int i = 0; i < collidersCount; i++)
            {
                if (Vector3.Distance(touchPosition, _colliderObjects[i].Position) <= _colliderObjects[i].Radius)
                {
                    _colliderObjects[i].CollisionEnter();
                    RemoveColliderObject(_colliderObjects[i]);
                }
            }
        }
    }
}
