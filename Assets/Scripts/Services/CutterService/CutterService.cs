using GameActors.InteractableObjects;
using Services.Factory;
using UnityEngine;
using Zenject;

namespace Services.CutterService
{
    public class CutterService : MonoBehaviour, ICutterService
    {
        [Inject] private IGameFactory _gameFactory;

        public void Cut(ColliderComponent colliderObject, Vector3 normalized)
        {
           colliderObject.TryGetComponent(out InteractableObject fruit);
           
           var currentSpriteRect = fruit.GetSprite.rect;
            
           var leftPart = CreatePart(fruit,
               new Rect(currentSpriteRect.x, currentSpriteRect.y, currentSpriteRect.width / 2, currentSpriteRect.height),
               new Vector2(1f, 0.5f));
           var rightPart = CreatePart(fruit,
               new Rect(currentSpriteRect.x + currentSpriteRect.width / 2, currentSpriteRect.y, currentSpriteRect.width / 2, currentSpriteRect.height),
               new Vector2(0f, 0.5f));

           Vector2 normalizedBlade = normalized;
           leftPart.AddForce(Rotate(normalizedBlade, -90f) + fruit.GetVelocity.normalized);
           rightPart.AddForce(Rotate(normalizedBlade,90f) + fruit.GetVelocity.normalized);
        }

       private Slice CreatePart(InteractableObject block, Rect textureRect, Vector2 texturePivot)
       {
           var part = _gameFactory.CreateSlice(null);
           part.transform.position = block.transform.position;
           part.transform.localScale = block.transform.localScale;

           part.SetSprite(Sprite.Create(block.GetSprite.texture, textureRect, texturePivot));

           return part;
       }
       
       private Vector2 Rotate(Vector3 direction, float degree)
       {
           var cos = Mathf.Cos(-degree * Mathf.Deg2Rad);
           var sin = Mathf.Sin(-degree * Mathf.Deg2Rad);
           var rotatedVector = new Vector3(
               direction.x * cos - direction.y * sin,
               direction.x * sin + direction.y * cos
           );

           return rotatedVector;
       }
    }
}