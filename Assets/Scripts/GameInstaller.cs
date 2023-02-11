using System.Collections;
using System.Collections.Generic;
using Services.Progress;
using StaticData;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private ProgressConfig progressConfig;
    [SerializeField] private SceneConfig sceneConfig;
    
    public override void InstallBindings()
    {
        Container.Bind<ProgressService>().FromNew().AsSingle().WithArguments(progressConfig);
    }
}
