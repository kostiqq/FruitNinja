using GameActors.InteractableObjects;
using UnityEngine;

namespace Services.CutterService
{
    public interface ICutterService
    {
        public void Cut(ColliderComponent colliderObject, Vector3 normalized);
    }
}