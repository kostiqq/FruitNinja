using UnityEngine;
using System.Collections;

namespace Services
{
    public class TimeScaler : MonoBehaviour, ITimeScaler
    {
        public float TimeScale { get; private set; }
        private float _freezeCoef;
        private float _freezeLength;
        private bool _isFreeze;
        
        public TimeScaler(float freezeCoef, float freezeLength)
        {
            _freezeCoef = freezeCoef;
            _freezeLength = freezeLength;
            TimeScale = Time.deltaTime;
        }
        
        public void FreezeBoard()
        {
            if (_isFreeze)
                return;
            
            TimeScale *= _freezeCoef;
            StartCoroutine(FreezeTimer());
        }

        private IEnumerator FreezeTimer()
        {
            yield return new WaitForSeconds(_freezeLength);
            _isFreeze = false;
            TimeScale = Time.deltaTime;
        }
    }
}