using GameActors.InteractableObjects;
using Services.Factory;
using UnityEngine;
using Zenject;

public class GameFactoryInstaller : MonoInstaller
{
    [SerializeField] private Fruit fruitPrefab;
    [SerializeField] private Slice slicePrefab;
    
    public override void InstallBindings()
    {
        Container.
            Bind<IGameFactory>().
            To<GameFactory>().
            AsSingle().
            WithArguments(fruitPrefab, slicePrefab);
    }
}