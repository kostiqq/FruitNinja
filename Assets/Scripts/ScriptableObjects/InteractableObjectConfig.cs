using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "InteractableObjectConfig", menuName = "Configs/InteractableObjectConfig", order = 0)]
    public class InteractableObjectConfig : ScriptableObject
    {
        public Sprite FruitSprite;
        public Texture FruitEffectSprite;
        public bool isHaveShadow;
        public int points;
    }
}