using StaticData;
using UnityEngine;

public class FruitBuilder
{
    private InteractableObjectConfig[] _fruitConfig;
    
    public FruitBuilder(InteractableObjectConfig[] configs)
    {
        _fruitConfig = configs;
    }

    public InteractableObjectConfig GetRandomConfig()
    {
        int configIndex = Random.Range(0, _fruitConfig.Length);
        return _fruitConfig[configIndex];
    }
}
