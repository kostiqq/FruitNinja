using GameActors.InteractableObjects;
using Services.Factory;
using UnityEngine;
using Zenject;

public class GameFactoryInstaller : MonoInstaller<GameFactoryInstaller>
{
    [SerializeField] private Fruit fruitPrefab;
    [SerializeField] private Slice slicePrefab;
    [SerializeField] private Bomb bomb;
    [SerializeField] private BonusLife bonusLife;
    
    public override void InstallBindings()
    {
        Container.
            Bind<IGameFactory>().
            To<GameFactory>().
            AsSingle().
            WithArguments(fruitPrefab, slicePrefab, bomb, bonusLife).NonLazy();
    }
}