using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "FruitConfig", menuName = "Configs/FruitConfig", order = 0)]
    public class FruitConfig : ScriptableObject
    {
        public Sprite FruitSprite;
        public Texture FruitEffectSprite;
    }
}