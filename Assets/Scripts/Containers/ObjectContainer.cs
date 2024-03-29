using System.Collections.Generic;
using GameActors.InteractableObjects;
using GameInput;
using Services.Factory;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private CollisionTracker _collisionTracker;

    private List<InteractableObject> _objects = new List<InteractableObject>();
    public List<InteractableObject> Fruits = new List<InteractableObject>();

    public FruitPool FruitPool;
    public BombsPool BombsPool;
    public BonusLifePool BonusLifePool;

    public int getObjectsCount => _objects.Count;

    public void AddObject(InteractableObject newObj)
    {
        Fruits.Add(newObj);
        newObj.OnObjectHide += RemoveFruit;
        _objects.Add(newObj);
        _collisionTracker.AddColliderObject(newObj);
        newObj.transform.SetParent(transform);
    }

    public void RemoveFruit(InteractableObject objToRemove)
    {
        Fruits.Remove(objToRemove);
        
        objToRemove.OnObjectHide -= RemoveFruit;
        FruitPool.Return(objToRemove as Fruit);
        _objects.Remove(objToRemove);
    }

    //todo separate container for all object types
    public void AddBomb(Bomb bomb)
    {
        _objects.Add(bomb);
        _collisionTracker.AddColliderObject(bomb);
        bomb.OnObjectHide += RemoveBomb;
    }

    private void RemoveBomb(InteractableObject bomb)
    {
        _objects.Remove(bomb);
        BombsPool.Return(bomb as Bomb);
        bomb.OnObjectHide -= RemoveBomb;
    }

    public void AddBonusLife(InteractableObject bonusLife)
    {
        _objects.Add(bonusLife);
        
        _collisionTracker.AddColliderObject(bonusLife);
        bonusLife.OnObjectHide += RemoveBonusLife;
    }

    private void RemoveBonusLife(InteractableObject bonusLife)
    {
        _objects.Remove(bonusLife);
        BonusLifePool.Return(bonusLife as BonusLife);
        bonusLife.OnObjectHide -= RemoveBonusLife;
    }
}
