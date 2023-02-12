using System;
using Data;
using StaticData;

namespace Services.Progress
{
    public class ProgressService : IService
    {
        public Player PlayerData;
        public Score Score;

        public Action<int> OnScoreIncreased;
        public Action<int> OnNewHighScore;

        public Action<int> OnHealthChanged;
        public Action OnHealthEmpty;
        
        public ProgressService(ProgressConfig configsHandlerPlayerConfig)
        {
            Score = new Score(configsHandlerPlayerConfig.PlayerRecordPrefs);
            PlayerData = new Player(configsHandlerPlayerConfig.StartHealth);
        }

        public void UpdateScore(int value)
        {
            Score.CurrentScore += value;
            OnScoreIncreased?.Invoke(Score.CurrentScore);

            if (Score.CurrentScore > Score.HighScore)
            {
                Score.HighScore = Score.CurrentScore;
                Score.UpdateHighScore();
                OnNewHighScore?.Invoke(Score.HighScore);
            }
        }

        public void UpdateHealth(int value)
        {
            if (PlayerData.CurrentHealth < 0)
                return;
            
            PlayerData.CurrentHealth += value;
            OnHealthChanged?.Invoke(PlayerData.CurrentHealth);
            
            if (PlayerData.CurrentHealth == 0)
                OnHealthEmpty?.Invoke();
        }
    }
}