using System.Collections.Generic;
using GameActors.InteractableObjects;
using UnityEngine;

namespace Services.Factory
{
    public class InteractableObjectsPool
    {
        private Transform _container;
        private Sprite[] _objectSprites;
        private GameFactory _gameFactory;
        
        private List<InteractableObject> _pool;

        public InteractableObjectsPool(GameFactory factory, int count, Transform container)
        {
            _gameFactory = factory;
            _container = container;
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<InteractableObject>();
            
            for (int i = 0; i < count; i++)
                _pool.Add(_gameFactory.LoadInteractableObject(_container));
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
            {
                return interactableObject;
            }
            else
            {
                var newObject = _gameFactory.LoadInteractableObject(_container);
                _pool.Add(newObject);
                return newObject;
            }
        }
    }
}