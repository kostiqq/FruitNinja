using StaticData;
using UnityEngine;

public class GameComplicator : MonoBehaviour
{
    public float CurrentWaveComplexityCoefficient = 1;
    public int CurrentObjectComplexityCoefficient;

    public GameComplexity complexityConfig;

    private float _timeBetweenComplexityGrowth;
    private float _timeBetweenObjectComplexityGrowth;
    private float _complexityCoefficientGrowth;

    private float _timeSinceWaveComplexityGrowth;
    private float _timeSinceObjectComplexityGrowth;
        
    private void Awake()
    {
        _timeBetweenComplexityGrowth = complexityConfig.ComplexityCoefIncreaseTime;
        _complexityCoefficientGrowth = complexityConfig.ComplexityCoef;
        _timeBetweenObjectComplexityGrowth = complexityConfig.fruitComplexityGrowthTime;
    }
        
    private void Update()
    {
        _timeSinceWaveComplexityGrowth += Time.deltaTime;
        _timeSinceObjectComplexityGrowth += Time.deltaTime;
            
        if(_timeSinceWaveComplexityGrowth > _timeBetweenComplexityGrowth)
        {
            IncreaseWaveComplexity();
            _timeSinceWaveComplexityGrowth = 0f;
        }

        if (_timeSinceObjectComplexityGrowth > _timeBetweenObjectComplexityGrowth)
        {
            IncreaseObjectComplexity();
            _timeSinceObjectComplexityGrowth = 0;
        }
    }
        
    private void IncreaseWaveComplexity()=>
        CurrentWaveComplexityCoefficient += _complexityCoefficientGrowth;

    private void IncreaseObjectComplexity() =>
        CurrentObjectComplexityCoefficient++;
}
