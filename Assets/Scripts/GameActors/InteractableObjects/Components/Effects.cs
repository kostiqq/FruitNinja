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
        private int _points;

        public void Construct(Texture particleTexture, Color effectColor, int points)
        {
            _points = points;
            _effectColor = effectColor;
            _particleTexture = particleTexture;
        }
        
        public void PlayEffects(int points)
        {
            CreateCutParticle();
            _cutParticle.Play();

            var effect = Instantiate(sliceEffectPrefab);
            effect.startColor = _effectColor;
            effect.transform.position = transform.position;
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
            pointsLabel.SetScore(_points);
            Vector2 offset = Random.insideUnitCircle;
            pointsLabel.transform.position = transform.position + new Vector3(offset.x,offset.y, 0);
            pointsLabel.StartAnimation();
        }
    }
}