using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "InputConfig", menuName = "Configs/InputConfig", order = 0)]
    public class InputConfig : ScriptableObject
    {
        public float minDistance = 20;
        public int MouseButtonIndex = 0;
    }
}