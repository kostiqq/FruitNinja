using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "ComplexityConfig", menuName = "Configs/Complexity", order = 1)]
    public class GameComplexity : ScriptableObject
    {
        [Header("Waves params")]
        public float ComplexityCoef;
        public float ComplexityCoefIncreaseTime;
        public float TimeBetweenWaves;
        public float TimeBetweenFruitSpawn;
        
        [Space(5)]
        [Header("Fruit params")]
        public int MinFruitsCount;
        public int MaxFruitsCount;
        public float fruitComplexityGrowthTime;

        [Space(5)] 
        [Header("Bonuses")] 
        [Range(0, 1)]
        public float BombsPerWavePerc;
        [Range(0,1)]
        public float HeartPerWavePerc;
    }
}