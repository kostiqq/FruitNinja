using Services.Progress;
using UnityEngine;
using Zenject;

public class GameView : MonoBehaviour
{
    [SerializeField] private HealthView health;
    [SerializeField] private ScoreView score;
    [SerializeField] private LoseView loseView;

    public LoseView getLoseView => loseView;
    [Inject] private ProgressService progress;

    private void Start()
    {
        score.Construct();
        health.Construct();
        loseView.gameObject.SetActive(false);
    }

    public void ShowLoseView()
    {
        loseView.ShowAnimation();
    }

    public void ReInit()
    {
        score.Construct();
        health.Construct();
    }
}