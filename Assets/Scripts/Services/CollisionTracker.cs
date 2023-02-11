using System.Collections.Generic;
using GameActors.InteractableObjects;
using Services.CutterService;
using Services.Factory;
using UnityEngine;

namespace GameInput
{
    public class CollisionTracker
    {
        private InputHandler _inputHandler;

        private List<ColliderComponent> _colliderObjects = new List<ColliderComponent>();
        private CutterService _cutter;

        public CollisionTracker(InputHandler inputHandler, GameFactory factory, CutterService cutter)
        {
            _inputHandler = inputHandler;
            factory.OnInteractableObjectCreate += AddColliderObject;
            _cutter = cutter;
            _inputHandler.OnSwipe += TrackCollision;
        }

        private void AddColliderObject(InteractableObject interactableObject)
        {
            interactableObject.TryGetComponent(out ColliderComponent collider);

            if(!_colliderObjects.Contains(collider))
                _colliderObjects.Add(collider);
        }
        
        private void TrackCollision(Vector3 touchPosition)
        {
            var collidersCount = _colliderObjects.Count;
            for (int i = 0; i < collidersCount; i++)
            {
                if(!_colliderObjects[i].IsEnabled)
                    continue;

                if (Vector3.Distance(touchPosition, _colliderObjects[i].Position) <= _colliderObjects[i].Radius)
                {
                    _colliderObjects[i].CollisionEnter();
                    _cutter.Cut(_colliderObjects[i], _inputHandler.InputVector().normalized);
                }
                    
            }
        }
    }
}
