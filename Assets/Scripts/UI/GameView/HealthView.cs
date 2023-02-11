using System;
using System.Collections.Generic;
using Services.Progress;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Heart heartPrefab;

    private List<Heart> _currentHearts;
    private ProgressService _progress;

    public void Construct(ProgressService progress)
    {
        _progress = progress;
        _currentHearts = new List<Heart>();
        Initialize();
    }

    private void Initialize()
    {
        InstantiateHearts(_progress.PlayerData.MaxHealth);
        _progress.OnHealthChanged += UpdateHearts;
        _progress.OnHealthEmpty += ClearView;
    }

    private void ClearView()
    {
        _progress.OnHealthChanged -= UpdateHearts;
    }

    private void UpdateHearts(int hearts)
    {
        if (hearts > _currentHearts.Count)
            InstantiateHearts(hearts - _currentHearts.Count);
        else
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
}
