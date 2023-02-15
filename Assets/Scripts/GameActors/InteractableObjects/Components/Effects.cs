using UnityEngine;

namespace GameActors.InteractableObjects
{
    public class Effects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem cutEffectPrefab;
        [SerializeField] private FruitScore pointsViewPrefab;
        [SerializeField] private ParticleSystem sliceEffectPrefab;
        
        private ParticleSystem _cutParticle;
        private Texture _particleTexture;
        private Color _effectColor;

        public void Construct(Texture particleTexture, Color effectColor, ParticleSystem objectConfigSliceEffect = null)
        {
            _effectColor = effectColor;
            _particleTexture = particleTexture;
            sliceEffectPrefab = objectConfigSliceEffect;
        }
        
        public void PlayEffects(int points)
        {
            CreateCutParticle();
            _cutParticle.Play();

            if (sliceEffectPrefab != null)
            {
                var effect = Instantiate(sliceEffectPrefab);
                effect.transform.position = transform.position;
            }
            
            if(points != 0)
                CreatePointsLabel(points);
        }
        
        private void CreateCutParticle()
        {
            _cutParticle = Instantiate(cutEffectPrefab);
            _cutParticle.transform.position = transform.position;
            _cutParticle.GetComponent<ParticleSystemRenderer>().material.mainTexture = _particleTexture;
        }
        
        private void CreatePointsLabel(int points)
        {
            var pointsLabel = Instantiate(pointsViewPrefab);
            pointsLabel.SetScore(points);
            Vector2 offset = Random.insideUnitCircle;
            pointsLabel.transform.position = transform.position + new Vector3(offset.x,offset.y, 0);
            pointsLabel.StartAnimation();
        }
    }
}