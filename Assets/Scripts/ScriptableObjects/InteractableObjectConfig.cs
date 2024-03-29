﻿using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "InteractableObjectConfig", menuName = "Configs/InteractableObjectConfig", order = 3)]
    public class InteractableObjectConfig : ScriptableObject
    {
        public Sprite FruitSprite;
        public Texture FruitEffectSprite;
        public ParticleSystem sliceEffect;
        public bool isHaveShadow;
        public int points;
        public Color EffectColor;
    }
}