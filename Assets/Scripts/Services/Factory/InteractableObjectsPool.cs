using System;
using System.Collections.Generic;
using GameActor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Factory
{
    public class InteractableObjectsPool
    {
        public InteractableObject Prefab;
        public Transform Container { get; }

        private List<InteractableObject> pool;

        public InteractableObjectsPool(InteractableObject prefab, int count, Transform container)
        {
            Prefab = prefab;
            Container = container;
            
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            pool = new List<InteractableObject>();
            
            for (int i = 0; i < count; i++)
                pool.Add(CreateObject());
        }

        private InteractableObject CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(Prefab, Container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            return createdObject;
        }

        public bool HasFreeElement(out InteractableObject element)
        {
            foreach (InteractableObject interactableObject in pool)
            {
                if (!interactableObject.gameObject.activeInHierarchy)
                {
                    element = interactableObject;
                    interactableObject.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public InteractableObject GetFreeElement()
        {
            if (HasFreeElement(out var interactableObject))
                return interactableObject;
            
            throw new Exception("There is no free element in InteractableObject pool");
        }
    }
}