using System.Collections.Generic;
using DG.Tweening;
using GameActors.InteractableObjects;
using Services.Progress;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Heart heartPrefab;
    [SerializeField] private Camera gameCamera;
    [SerializeField] private Transform canvasTr;
    [SerializeField] private HorizontalLayoutGroup layoutGroup;
    
    private List<Heart> _currentHearts;
    private float _spaceBetweenHearts;
    
    [Inject]private ProgressService _progress;

    public void Construct()
    {
        _currentHearts = new List<Heart>();
        Initialize();
    }

    private void Initialize()
    {
        _spaceBetweenHearts = layoutGroup.spacing;
        InstantiateHearts(_progress.PlayerData.MaxHealth);
        _progress.OnHealthChanged += UpdateHearts;
        _progress.OnHealthEmpty += ClearView;
    }
    
    private void ClearView()
    {
        _progress.OnHealthChanged -= UpdateHearts;
        _progress.OnHealthEmpty -= ClearView;
    }

    private void UpdateHearts(int hearts)
    {
        if (hearts < _currentHearts.Count)
            RemoveHearts(hearts);
    }

    private void RemoveHearts(int hearts)
    {
        for (int i = _currentHearts.Count-1; i >= hearts; i--)
        {
            Heart heartToRemove = _currentHearts[i];
            _currentHearts.Remove(heartToRemove);
            heartToRemove.DestroyAnimation();
        }
    }

    private void InstantiateHearts(int count)
    {
        for (int i = 0; i < count; i++)
            _currentHearts.Add(Instantiate(heartPrefab, transform));
    }
    
    public void EarnAnimation(BonusLife life, Vector3 position)
    {
        life.OnLifeEarned -= EarnAnimation;
        
        Vector2 spawnPosition = gameCamera.WorldToScreenPoint(position);
        var heart = Instantiate(heartPrefab, spawnPosition, Quaternion.identity, canvasTr);
        Vector2 movePosition = GetHeartMovePoint();
        
        heart.transform.DOMove(movePosition, 1f).OnComplete(() =>
        {
            heart.transform.SetParent(transform);
            _currentHearts.Add(heart);
        });
    }

    private Vector2 GetHeartMovePoint()=>
        new Vector2(_currentHearts[_currentHearts.Count-1].transform.position.x - 
                    _currentHearts[_currentHearts.Count-1].sizeX() - _spaceBetweenHearts, transform.position.y);
}
