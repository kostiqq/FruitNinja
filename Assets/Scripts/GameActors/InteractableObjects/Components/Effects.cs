using UI;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    public class Effects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem cutEffectPrefab;
        [SerializeField] private FruitPoints pointsViewPrefab;
        private ParticleSystem _cutParticle;
        private Texture _particleTexture;

        public void Construct(Texture particleTexture)
        {
            _particleTexture = particleTexture;
        }
        
        public void PlayEffects(int points)
        {
            CreateCutParticle();
            _cutParticle.Play();
            
            /*var pointsEffect = CreatePointsLabel(points);
            pointsEffect.Play();*/
        }
        
        private void CreateCutParticle()
        {
            _cutParticle = Instantiate(cutEffectPrefab);
            _cutParticle.transform.position = transform.position;
            _cutParticle.GetComponent<ParticleSystemRenderer>().material.mainTexture = _particleTexture;
        }
        
        private FruitPoints CreatePointsLabel(int points)
        {
            var pointsLabel = Instantiate(pointsViewPrefab);
            pointsLabel.Construct(points);
            return pointsLabel;
        }
    }
}