using GameActors.InteractableObjects;
using Services.Factory.ScriptableObjects;
using UnityEngine;

namespace Services.Factory.GameActors
{
    public class BlastWave : MonoBehaviour
    {
        [SerializeField] private ObjectContainer container;
        [SerializeField] private BlastConfig config;
        
        private float _blastStrength;
        private float _blastRadius;

        private void Start()
        {
            _blastStrength = config.blastStrength;
        }

        public void CreateBlast(Vector3 initPosition)
        {
            foreach (var fr  in container.Fruits)
                AddBlast(fr, initPosition);
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