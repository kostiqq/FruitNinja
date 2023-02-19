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
        [SerializeField] private GameTextMeshPro boomTextPrefab;
        [SerializeField] private BlastConfig config;

        [Header("Camera shaking params")] 
        [SerializeField] private float duration;
        [SerializeField] private float strength;
        [SerializeField] private int vibrato;
        
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
            gameCamera.DOShakePosition(duration,strength, vibrato);
            var boomText = Instantiate(boomTextPrefab, initPosition, Quaternion.identity).GetComponent<GameTextMeshPro>();
            boomText.StartAnimation();
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