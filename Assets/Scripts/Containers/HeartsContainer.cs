using System.Collections;
using System.Collections.Generic;
using GameActors.InteractableObjects;
using GameInput;
using Services.Factory;
using UnityEngine;

public class HeartsContainer : MonoBehaviour
{
    [SerializeField] private CollisionTracker _collisionTracker;
    
    private List<InteractableObject> _objects = new List<InteractableObject>();
    public List<InteractableObject> Fruits = new List<InteractableObject>();
    
    public BonusLifePool BonusLifePool;
    
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
