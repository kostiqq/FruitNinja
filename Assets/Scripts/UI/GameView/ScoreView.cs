using Services.Progress;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreText bestScore;
    [SerializeField] private ScoreText currentScore;
    private ProgressService _progress;
    
    public void Construct(ProgressService progress)
    {
        _progress = progress;
        Initialize();
        Subscribe();
    }

    private void Initialize()
    {
       currentScore.Initialize(_progress.Score.CurrentScore);
       bestScore.Initialize(_progress.Score.HighScore);
    }

    private void Subscribe()
    {
        _progress.OnScoreIncreased += UpdateCurrentScore;
        _progress.OnNewHighScore += UpdateBestScore;
    }

    private void UpdateBestScore(int newBestScore)=>
        bestScore.SetScore(newBestScore);
    
    private void UpdateCurrentScore(int score)=>
        currentScore.SetScore(score);
}
