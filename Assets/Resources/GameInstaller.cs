using System.Collections;
using System.Collections.Generic;
using Services.Progress;
using StaticData;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private ProgressConfig config;
    public override void InstallBindings()
    {
        Container.Bind<ProgressService>().FromNew().AsSingle().WithArguments(config).NonLazy();
        
    }
}
