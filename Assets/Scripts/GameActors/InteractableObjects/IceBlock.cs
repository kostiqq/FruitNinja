using GameActors.InteractableObjects;
using Services;
using StaticData;
using UnityEngine;

public class IceBlock : InteractableObject
{
    [SerializeField] private Effects effects;
    [SerializeField] private float forceMultiplyer = 1.5f;

    private TimeScaler _timeScaler;
    private int _points;
    
    public override void Initialize(InteractableObjectConfig objectConfig)
    {
        _timeScaler = TimeScaler.Instance;
        base.Initialize(objectConfig);
        effects.Construct(objectConfig.FruitEffectSprite, objectConfig.EffectColor);
        visability.IsEnbled = true;
    }
        
    protected override void Interact()
    {
        _timeScaler.FreezeBoard();
        effects.PlayEffects(_points);
        ClearState();
        gameObject.SetActive(false);
    }

    protected override void ClearState()
    {
        visability.IsEnbled = false;
        base.ClearState();
    }

    public override void StartMoving(Vector3 direction, float force)
    {
        base.StartMoving(direction, force + forceMultiplyer);
    }
}
