using System.Collections.Generic;
using GameActors.Spawner;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "SpawnerSettings", menuName = "Config/SpawnerSettings", order = 0)]
    public class SpawnerSettings : ScriptableObject
    {
        public List<SpawnerParameters> Spawners;
    }
}