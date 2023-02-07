using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.ServiceLocator
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        protected Dictionary<Type, T> _services { get; }

        public ServiceLocator()
        {
            _services = new Dictionary<Type, T>();
        }
        
        public TP Register<TP>(TP newService) where TP : T
        {
            var type = newService.GetType();

            if (_services.ContainsKey(type))
                Debug.LogError($"Can't add service of type {type}, it already exist");

            _services[type] = newService;
            return newService;
        }

        public void Unregister<TP>(TP service) where TP : T
        {
            var type = service.GetType();

            if (_services.ContainsKey(type))
                _services.Remove(type);
        }

        public TP Get<TP>() where TP : T
        {
            var type = typeof(TP);

            if (!_services.ContainsKey(type))
                Debug.LogError($"There is no object with type {type}");

            return (TP)_services[type];
        }
    }
}