using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "SpawnerSettings", menuName = "Config/SpawnerSettings", order = 0)]
    public class SpawnerSettings : ScriptableObject
    {
        public int StartFrequency;
        public float DifficultMultiplyer;
    }
}