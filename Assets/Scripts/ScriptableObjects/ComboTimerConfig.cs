using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ComboTimerConfig", menuName = "Configs/ComboTimer")]
    public class ComboTimerConfig : ScriptableObject
    {
        [Range(1,4)]
        public int MaxCombo;
        
        [Range(0f, 1f)]
        public float TimerInterval;
    }
}