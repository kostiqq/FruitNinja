using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ComboTimerConfig", menuName = "Configs/ComboTimer")]
    public class ComboTimerConfig : ScriptableObject
    {
        [Range(1,4)]
        public int MaxCombo;
        
        [Range(1, 10)]
        public float TimerInterval;
        
        [Range(1, 10)]
        public int SliceCountToIncreaseCombo;
    }
}