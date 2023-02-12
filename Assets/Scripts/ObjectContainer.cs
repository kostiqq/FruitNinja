using System.Collections.Generic;
using GameActors.InteractableObjects;
using GameInput;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private InputHandler input;
    [SerializeField] private CollisionTracker _collisionTracker;
    
    private List<InteractableObject> _objects = new List<InteractableObject>();
    
    public IEnumerable<InteractableObject> GetObjects => _objects;
    public int GetObjectsCount => _objects.Count;

    private void Start()
    {

    }
    
    public void AddObject(InteractableObject newObj)
    {
        _objects.Add(newObj);
        _collisionTracker.AddColliderObject(newObj);
        newObj.transform.SetParent(transform);
    }

    public void RemoveObject(InteractableObject objToRemove)
    {
        _objects.Remove(objToRemove);
    }
}
