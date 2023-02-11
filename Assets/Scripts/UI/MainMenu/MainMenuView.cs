using Services.Progress;
using UnityEngine;
using Zenject;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private ScoreText bestScore;

    [Inject] private ProgressService progress;
    
    public void Start()
    {
        bestScore.Initialize(progress.Score.HighScore);   
    }
}
