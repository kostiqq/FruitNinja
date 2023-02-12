using System;
using DG.Tweening;
using Services.Progress;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using UnityEngine.UI;

public class LoseView : MonoBehaviour
{
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private ScoreText bestScore;
    [SerializeField] private ScoreText sessionScore;
    
    [Inject] private ProgressService _progress;

    public Action OnRestart;
    
    private void Start()
    {
        bestScore.Initialize(_progress.Score.HighScore);
        sessionScore.Initialize(_progress.Score.CurrentScore);
        RestartButton.onClick.AddListener(Restart);
        menuButton.onClick.AddListener(LoadMenuScene);
    }

    private void LoadMenuScene()
    {
        _progress.ResetSessionData();
        SceneManager.LoadScene(0);
    }

    private void Restart()
    {
        HideWindow();
    }

    private void HideWindow()
    {
        _progress.ResetSessionData();
        transform.DOScale(Vector3.zero, 0.5f).OnComplete(()=>
        {
            OnRestart?.Invoke();
            gameObject.SetActive(false);
        });
    }

    public void ShowAnimation()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOScale(Vector3.one, 1f);
    }
    
    
}
