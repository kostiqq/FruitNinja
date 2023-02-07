using StaticData;
using UnityEngine;

public class FruitBuilder
{
    private FruitConfig[] _fruitConfig;
    
    public FruitBuilder(FruitConfig[] configs)
    {
        _fruitConfig = configs;
    }

    public FruitConfig GetRandomConfig()
    {
        int configIndex = Random.Range(0, _fruitConfig.Length);
        return _fruitConfig[configIndex];
    }
}
