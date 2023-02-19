using UnityEngine;
using System.Collections;

namespace Services
{
    public class TimeScaler : MonoBehaviour
    {
        public float TimeScale;
        [SerializeField] private float _freezeCoef;
        [SerializeField] private float _freezeLength;
        private bool _isFreeze;

        public static TimeScaler Instance;

        public void Awake()
        {
            if(Instance == null)
                Instance = this;
            else 
                Destroy(gameObject);

            TimeScale = Time.deltaTime;
        }

        public void FreezeBoard()
        {
            if (_isFreeze)
                return;

            _isFreeze = true;
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