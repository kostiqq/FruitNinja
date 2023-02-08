using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player config", order = 0)]
    public class ProgressConfig : ScriptableObject
    {
        public int StartHealth = 3;
        public string PlayerRecordPrefs = "High Score";
    }
}