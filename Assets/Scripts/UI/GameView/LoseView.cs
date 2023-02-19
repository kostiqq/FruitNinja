using System;
using DG.Tweening;
using Services.Progress;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using System.Collections;
using UnityEngine.EventSystems;

public class LoseView : MonoBehaviour
{
    [SerializeField] private ButtonAnimator RestartButton;
    [SerializeField] private ButtonAnimator menuButton;
    [SerializeField] private ScoreText bestScore;
    [SerializeField] private ScoreText sessionScore;
    [SerializeField] private CanvasGroup aspectRaito;
    [SerializeField] private EventSystem eventSystem;

    [Inject] private ProgressService _progress;

    public Action OnRestart;
    
    private void OnEnable()
    {
        eventSystem.enabled = true;
        bestScore.Initialize(_progress.Score.HighScore);
        sessionScore.Initialize(_progress.Score.CurrentScore);
        RestartButton.OnTouchPerformed += Restart;
        menuButton.OnTouchPerformed += LoadMenuScene;
    }

    private void OnDisable()
    {
        RestartButton.OnTouchPerformed -= Restart;
        menuButton.OnTouchPerformed -= LoadMenuScene;
    }

    private void LoadMenuScene()
    {
        _progress.ResetSessionData();
        SceneTranslation();
    }

    private void SceneTranslation()
    {
        aspectRaito.DOFade(1, 1f).OnComplete(()=>SceneManager.LoadScene(0));
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
