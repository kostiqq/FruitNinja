using GameActors.InteractableObjects;
using Services.Factory;
using StaticData;
using UnityEngine;

public class FruitBuilder
{
    private IGameFactory _gameFactory;

    private FruitConfig[] _fruitConfig;
    
    public FruitBuilder(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;
        Initialize();
    }

    private void Initialize()
    {
        _fruitConfig = _gameFactory.LoadFruitConfigs();
    }

    public void GetRandomFruit(InteractableObject emptyObject)
    {
        int configIndex = Random.Range(0, _fruitConfig.Length);
        emptyObject.BuildFruit(_fruitConfig[configIndex]);
    }
}
