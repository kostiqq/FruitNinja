using System.Collections.Generic;
using StaticData;
using UnityEngine;

namespace Infrastructure
{
    public class ProjectConfig : MonoBehaviour
    {
        public GameComplexity ComplexityConfig;
        public List<InteractableObjectConfig> FruitConfigs;
        public InputConfig InputConfig;
        public ProgressConfig PlayerConfig;
    }
}