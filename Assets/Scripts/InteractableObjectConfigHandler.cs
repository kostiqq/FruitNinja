using StaticData;
using UnityEngine;

public class InteractableObjectConfigHandler
{
    private InteractableObjectConfig[] _fruitConfigs;
    private InteractableObjectConfig _bombConfig;
    private InteractableObjectConfig _bonusLifeConfig;
    private InteractableObjectConfig _iceBlockCongig;
    public InteractableObjectConfig GetBombConfig() => _bombConfig;
    public InteractableObjectConfig GetBonusLifeConfig() => _bonusLifeConfig;
    public InteractableObjectConfig GetIceBlockConfig() => _iceBlockCongig;
    
    public InteractableObjectConfigHandler(InteractableObjectConfig[] fruitConfigs, InteractableObjectConfig bombConfig,
        InteractableObjectConfig bonusLifeConfig,  InteractableObjectConfig iceBlockConfig)
    {
        _fruitConfigs = fruitConfigs;
        _bombConfig = bombConfig;
        _bonusLifeConfig = bonusLifeConfig;
        _iceBlockCongig = iceBlockConfig;
    }

    public InteractableObjectConfig GetRandomFruitConfig()
    {
        int configIndex = Random.Range(0, _fruitConfigs.Length);
        return _fruitConfigs[configIndex];
    }
}
