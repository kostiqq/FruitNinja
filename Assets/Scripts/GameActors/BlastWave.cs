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
        
        public void CreateBlast(Vector3 initPosition)
        {
            while(container.GetFruits.MoveNext())
                AddBlast(container.GetFruits.Current, initPosition);
        }

        private void AddBlast(InteractableObject fruit, Vector3 initPosition)
        {
            Vector3 fruitTram = fruit.transform.position;
            Vector3 forceVector = fruitTram - initPosition;
            float force = _blastStrength / (fruitTram - initPosition).magnitude;
            fruit.AddForce(forceVector, force);
        }
    }
}