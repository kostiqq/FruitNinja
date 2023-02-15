using System.Collections.Generic;
using StaticData;
using UnityEngine;
using Zenject;

public class InteractableObjectConfigInstaller : MonoInstaller
{
    [SerializeField] private List<InteractableObjectConfig> fruitConfigs;
    [SerializeField] private InteractableObjectConfig bombConfig;
    [SerializeField] private InteractableObjectConfig bonusLifeConfig;
    
    public override void InstallBindings()
    {
        Container.
            Bind<InteractableObjectConfigHandler>().
            FromNew().
            AsSingle().
            WithArguments(fruitConfigs.ToArray(), bombConfig, bonusLifeConfig);
    }
}