using System;
using UnityEngine;

namespace GameActors.Spawner
{
    [Serializable]
    public class SpawnerParameters
    {
        public SpawnerPosition Position;
        [Range(0,1)]
        public float LeftPoint;
        [Range(0,1)]
        public float RightPoint;
    }
}