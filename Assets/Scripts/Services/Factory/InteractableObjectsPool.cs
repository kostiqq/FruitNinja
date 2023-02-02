using System;
using System.Collections.Generic;
using GameActors.InteractableObjects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Factory
{
    public class InteractableObjectsPool
    {
        private InteractableObject _prefab;
        private Transform _container;

        private List<InteractableObject> _pool;

        public InteractableObjectsPool(InteractableObject prefab, int count, Transform container)
        {
            _prefab = prefab;
            _container = container;
            
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<InteractableObject>();
            
            for (int i = 0; i < count; i++)
                _pool.Add(CreateObject());
        }

        private InteractableObject CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab, _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            return createdObject;
        }
        
        public bool HasFreeElement(out InteractableObject element)
        {
            foreach (InteractableObject interactableObject in _pool)
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