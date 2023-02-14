using GameActors.InteractableObjects.Components;
using UnityEngine;

namespace GameActors.InteractableObjects
{
    [RequireComponent(typeof(Effects))]
    [RequireComponent(typeof(Physic))]
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(ColliderComponent))]    
    [RequireComponent(typeof(Visability))]
    public class Bomb : InteractableObject
    {
        
    }
}