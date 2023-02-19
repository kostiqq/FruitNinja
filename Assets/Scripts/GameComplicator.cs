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
    public float GetIceBlockProb { get; private set; }
    public float GetBonusLifeProb { get; private set; }
    public float GetBombProb { get; private set; }

    public void Start()
    {
        _timeBetweenComplexityGrowth = complexityConfig.ComplexityCoefIncreaseTime;
        _complexityCoefficientGrowth = complexityConfig.ComplexityCoef;

        _timeBetweenObjectComplexityGrowth = complexityConfig.fruitComplexityGrowthTime;
        GetBombProb = complexityConfig.BombsPerWavePerc;
        GetBonusLifeProb = complexityConfig.HeartPerWavePerc;
        GetIceBlockProb = complexityConfig.IceBlockProb;
    }
    
    public void Reset()
    {
        CurrentWaveComplexityCoefficient = 1;
        CurrentObjectComplexityCoefficient = 0;
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
