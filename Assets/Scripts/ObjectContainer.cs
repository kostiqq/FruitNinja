using System.Collections.Generic;
using GameActors.InteractableObjects;
using GameInput;
using Services.Factory;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private CollisionTracker _collisionTracker;
    
    private List<InteractableObject> _objects = new List<InteractableObject>();
    public List<InteractableObject> _fruits = new List<InteractableObject>();

    public IEnumerator<InteractableObject> GetFruits => _fruits.GetEnumerator();
    
    public FruitPool Pool;
    
    public int getObjectsCount => _objects.Count;

    public void AddObject(InteractableObject newObj)
    {
        if(newObj is Fruit)
            _fruits.Add(newObj);
        
        newObj.OnObjectHide += RemoveFruit;
        _objects.Add(newObj);
        _collisionTracker.AddColliderObject(newObj);
        newObj.transform.SetParent(transform);
    }

    public void RemoveFruit(InteractableObject objToRemove)
    {
        objToRemove.OnObjectHide -= RemoveFruit;
        Pool.Return(objToRemove as Fruit);
        _objects.Remove(objToRemove);
    }
    
    
}
