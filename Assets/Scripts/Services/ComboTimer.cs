using System;
using ScriptableObjects;
using UnityEngine;

namespace Services
{
    public class ComboTimer : IComboTimer
    {
        private float _timerInterval;
        private int _maxComboMultiplyer;

        private int _currentSlices;
        private int _curentCombo = 0;

        private float _currentTime;

        public ComboTimer(ComboTimerConfig timerConfig)
        {
            _timerInterval = timerConfig.TimerInterval;
            _maxComboMultiplyer = timerConfig.MaxCombo;

            _currentTime = Time.time;
        }

        public Action<int, int> OnComboIncrease { get; set; }

        public int GetCombo()
        {
            CheckTime();
            _currentSlices++;
            UpdateCurrentCombo();
            return _curentCombo;
        }

        private void UpdateCurrentCombo()
        {
            if (_curentCombo < _maxComboMultiplyer && _currentSlices > 0)
            {
                _curentCombo++;                
                _currentSlices++;
                if(_curentCombo > 1)
                    OnComboIncrease?.Invoke(_curentCombo, _currentSlices);
            }
        }

        private void CheckTime()
        {
            if (_currentTime + _timerInterval <= Time.time)
            {
                _currentTime = Time.time;
                _curentCombo = 0;
                _currentSlices = 0;
            }
            else
                _currentTime = Time.time;
        }
    }
}