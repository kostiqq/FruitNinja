using Services;
using UnityEngine;
using Services.Progress;
using Zenject;

namespace GameActors.InteractableObjects
{
    public class PointerIncreaser : MonoBehaviour
    {
        private int _points;
        private ProgressService _progress;
        private IComboTimer _comboTimer;
        public int GetPoints => _points;

        public void Construct(ProgressService progress, IComboTimer comboTimer)
        {
            _progress = progress;
            _comboTimer = comboTimer;
        }

        public void AddPoints(int points)=>
            _points = points;

        public void IncreasePoints()
        {
            AddPoints(_points * _comboTimer.GetCombo());
            _progress.UpdateScore(_points);
        }

        public void RemoveHealth()
        {
            _progress.UpdateHealth(-1);
        }
    }
}