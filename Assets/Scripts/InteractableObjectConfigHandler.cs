using StaticData;
using UnityEngine;

public class InteractableObjectConfigHandler
{
    private InteractableObjectConfig[] _fruitConfigs;
    private InteractableObjectConfig _bombConfig;
    public InteractableObjectConfig GetBombConfig() => _bombConfig;
    
    public InteractableObjectConfigHandler(InteractableObjectConfig[] fruitConfigs, InteractableObjectConfig bombConfig)
    {
        _fruitConfigs = fruitConfigs;
        _bombConfig = bombConfig;
    }

    public InteractableObjectConfig GetRandomFruitConfig()
    {
        int configIndex = Random.Range(0, _fruitConfigs.Length);
        return _fruitConfigs[configIndex];
    }
}
