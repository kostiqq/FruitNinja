using System.Collections.Generic;
using StaticData;
using UnityEngine;
using Zenject;

public class InteractableObjectConfigInstaller : MonoInstaller
{
    [SerializeField] private List<InteractableObjectConfig> fruitConfigs;
    [SerializeField] private InteractableObjectConfig bombConfig;
    
    public override void InstallBindings()
    {
        Container.Bind<InteractableObjectConfigHandler>().FromNew().AsSingle().WithArguments(fruitConfigs.ToArray(), bombConfig);
    }
}