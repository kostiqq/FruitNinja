using DG.Tweening;
using GameActors.InteractableObjects;
using Services.Factory.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Services.Factory.GameActors
{
    public class BlastWave : MonoBehaviour
    {
        [SerializeField] private ObjectContainer container;
        [SerializeField] private Camera gameCamera;
        [SerializeField] private GameObject boomTextPrefab;
        [SerializeField] private BlastConfig config;
        
        private float _blastStrength;
        private float _blastRadius;

        private void Start()
        {
            _blastStrength = config.blastStrength;
        }

        public void CreateBlast(Vector3 initPosition)
        {
            PlayBlastAnimation(initPosition);
            foreach (var fr  in container.Fruits)
                AddBlast(fr, initPosition);
        }

        private void PlayBlastAnimation(Vector3 initPosition)
        {
            gameCamera.DOShakePosition(0.1f,0.1f, 10);
            Instantiate(boomTextPrefab, initPosition, Quaternion.identity);
        }

        private void AddBlast(InteractableObject fruit, Vector3 initPosition)
        {
            Vector3 fruitPos = fruit.transform.position;
            Vector3 forceVector = fruitPos - initPosition;
            float force = _blastStrength / (fruitPos - initPosition).magnitude;
            fruit.AddForce(forceVector, force);
        }
    }
}