using System;
using Data;
using StaticData;

namespace Services.Progress
{
    public class ProgressService : IService
    {
        private Player _playerData;
        private Score _score;

        public Action<int> OnScoreIncreased;
        public Action<int> OnNewHighScore;

        public Action<int> OnHealthChanged;
        public Action OnHealthEmpty;
        
        public ProgressService(ProgressConfig configsHandlerPlayerConfig)
        {
            _score = new Score(configsHandlerPlayerConfig.PlayerRecordPrefs);
            _playerData = new Player(configsHandlerPlayerConfig.StartHealth);
        }

        public void UpdateScore(int value)
        {
            _score.CurrentScore += value;
            OnScoreIncreased?.Invoke(_score.CurrentScore);

            if (_score.CurrentScore > _score.HighScore)
            {
                _score.HighScore = _score.CurrentScore;
                OnNewHighScore?.Invoke(_score.HighScore);
            }
        }

        public void UpdateHealth(int value)
        {
            _playerData.CurrentHealth += value;
            OnHealthChanged?.Invoke(_playerData.CurrentHealth);
            
            if (_playerData.CurrentHealth <= 0)
                OnHealthEmpty?.Invoke();
        }
    }
}