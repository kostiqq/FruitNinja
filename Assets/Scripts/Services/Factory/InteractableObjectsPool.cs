using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Factory
{
    public class InteractableObjectsPool
    {
        public GameObject Prefab;
        public Transform Container { get; }

        private List<GameObject> pool;

        public InteractableObjectsPool(GameObject prefab, int count, Transform container)
        {
            Prefab = prefab;
            Container = container;
            
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            pool = new List<GameObject>();
            
            for (int i = 0; i < count; i++)
                pool.Add(CreateObject());
        }

        private GameObject CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(Prefab, Container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            return createdObject;
        }

        public bool HasFreeElement(out GameObject element)
        {
            foreach (GameObject interactableObject in pool)
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

        public GameObject GetFreeElement()
        {
            if (HasFreeElement(out var interactableObject))
                return interactableObject;
            
            throw new Exception("There is no free element in InteractableObject pool");
        }
    }
}