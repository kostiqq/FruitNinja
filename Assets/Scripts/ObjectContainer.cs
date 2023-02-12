using System.Collections.Generic;
using GameActors.InteractableObjects;
using GameInput;
using Services.Factory;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private InputHandler input;
    [SerializeField] private CollisionTracker _collisionTracker;
    
    private List<InteractableObject> _objects = new List<InteractableObject>();
    public InteractableObjectsPool Pool;
    
    public IEnumerable<InteractableObject> GetObjects => _objects;
    public int GetObjectsCount => _objects.Count;

    public void AddObject(InteractableObject newObj)
    {
        _objects.Add(newObj);
        _collisionTracker.AddColliderObject(newObj);
        newObj.transform.SetParent(transform);
    }

    public void RemoveObject(InteractableObject objToRemove)
    {
        Pool.Return(objToRemove);
        _objects.Remove(objToRemove);
    }
}
