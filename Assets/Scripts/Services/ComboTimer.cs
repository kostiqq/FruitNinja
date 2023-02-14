using ScriptableObjects;
using UnityEngine;

namespace Services
{
    public class ComboTimer : IComboTimer
    {
        private float _timerInterval;
        private int _maxComboMultiplyer;
        private int _sliceCountToIncreaseCombo;

        private int _currentSlices;
        private int _curentCombo = 1;

        private float _currentTime;

        public ComboTimer(ComboTimerConfig timerConfig)
        {
            _timerInterval = timerConfig.TimerInterval;
            _maxComboMultiplyer = timerConfig.MaxCombo;
            _sliceCountToIncreaseCombo = timerConfig.SliceCountToIncreaseCombo;
            
            _currentTime = Time.time;
        }

        public int GetCombo()
        {
            CheckTime();
            
            _currentSlices++;

            UpdateCurrentCombo();
            
            return _curentCombo;
        }

        private void UpdateCurrentCombo()
        {
            if (_currentSlices >= _sliceCountToIncreaseCombo && _curentCombo < _maxComboMultiplyer)
            {
                _curentCombo++;
                _currentSlices = 0;
            }
        }

        private void CheckTime()
        {
            if (_currentTime + _timerInterval <= Time.time)
            {
                _currentTime = Time.time;
                _curentCombo = 1;
                _currentSlices = 0;
            }
            else
                _currentTime = Time.time;
        }
    }
}