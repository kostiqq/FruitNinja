using System.Collections.Generic;
using GameActors.InteractableObjects;
using GameInput;
using Services.Factory;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private CollisionTracker _collisionTracker;
    
    private List<InteractableObject> _objects = new List<InteractableObject>();
    public InteractableObjectsPool Pool;
    
    public int getObjectsCount => _objects.Count;

    public void AddObject(InteractableObject newObj)
    {
        newObj.OnObjectHide += RemoveObject;
        _objects.Add(newObj);
        _collisionTracker.AddColliderObject(newObj);
        newObj.transform.SetParent(transform);
    }

    public void RemoveObject(InteractableObject objToRemove)
    {
        objToRemove.OnObjectHide -= RemoveObject;
        Pool.Return(objToRemove);
        _objects.Remove(objToRemove);
    }
}
