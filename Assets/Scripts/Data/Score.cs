using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class Score
    {
        private string _highScorePrefsKey; 
        public int CurrentScore;
        public int HighScore;

        public Score(string playerRecordPrefs)
        {
            _highScorePrefsKey = playerRecordPrefs;
            HighScore = PlayerPrefs.GetInt(_highScorePrefsKey, 0);
            CurrentScore = 0;
        }
    }
}