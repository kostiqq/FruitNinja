using DG.Tweening;
using Services.Progress;
using UnityEngine;
using Zenject;

public class LoseView : MonoBehaviour
{
    [SerializeField] private ScoreText bestScore;
    [SerializeField] private ScoreText sessionScore;

    [Inject] private ProgressService _progress;
    private void OnEnable()
    {
        bestScore.Initialize(_progress.Score.HighScore);
        sessionScore.Initialize(_progress.Score.CurrentScore);
    }

    public void ShowAnimation()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOScale(Vector3.one, 1f);
    }
}
