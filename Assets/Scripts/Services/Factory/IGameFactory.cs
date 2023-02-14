using System;
using GameActors.InteractableObjects;
using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory
    {
        Action<Fruit> OnInteractableObjectCreate { get; set; }
        
        public Fruit CreateFruit(Transform container);

        public Slice CreateSlice(Transform container);

        public Bomb CreateBomb(Transform container);

        public BonusLife CreateBonusLife(Transform container);
    }
}