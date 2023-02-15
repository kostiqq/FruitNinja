using StaticData;
using UnityEngine;

public class InteractableObjectConfigHandler
{
    private InteractableObjectConfig[] _fruitConfigs;
    private InteractableObjectConfig _bombConfig;
    private InteractableObjectConfig _bonusLifeConfig;
    public InteractableObjectConfig GetBombConfig() => _bombConfig;
    public InteractableObjectConfig GetBonusLifeConfig() => _bonusLifeConfig;
    
    public InteractableObjectConfigHandler(InteractableObjectConfig[] fruitConfigs, InteractableObjectConfig bombConfig,
        InteractableObjectConfig bonusLifeConfig)
    {
        _fruitConfigs = fruitConfigs;
        _bombConfig = bombConfig;
        _bonusLifeConfig = bonusLifeConfig;
    }

    public InteractableObjectConfig GetRandomFruitConfig()
    {
        int configIndex = Random.Range(0, _fruitConfigs.Length);
        return _fruitConfigs[configIndex];
    }
}
