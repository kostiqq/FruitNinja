using Services.Progress;
using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreText bestScore;
    [SerializeField] private ScoreText currentScore;
    
    [Inject] private ProgressService _progress;
    
    public void Construct()
    {
        Initialize();
    }

    private void Initialize()
    {
       currentScore.Initialize(_progress.Score.CurrentScore);
       bestScore.Initialize(_progress.Score.HighScore);
    }

    private void OnEnable()
    {
        _progress.OnScoreIncreased += UpdateCurrentScore;
        _progress.OnNewHighScore += UpdateBestScore;
    }

    private void OnDisable()
    {
        _progress.OnScoreIncreased -= UpdateCurrentScore;
        _progress.OnNewHighScore -= UpdateBestScore;
    }

    private void UpdateBestScore(int newBestScore)=>
        bestScore.SetScore(newBestScore);
    
    private void UpdateCurrentScore(int score)=>
        currentScore.SetScore(score);
}
