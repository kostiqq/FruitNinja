using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "ComplexityConfig", menuName = "Configs/Complexity", order = 0)]
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
    }
}