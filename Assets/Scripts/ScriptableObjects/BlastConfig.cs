using UnityEngine;

namespace Services.Factory.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BlastConfig", menuName = "Configs/Blast Config", order = 6)]
    public class BlastConfig : ScriptableObject
    {
        public float blastStrength;
        public float blastRadius;
    }
}