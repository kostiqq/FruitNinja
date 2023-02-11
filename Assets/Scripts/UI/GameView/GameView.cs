using Services.Progress;
using UnityEngine;

public class GameView : MonoBehaviour
{
   [SerializeField] private HealthView health;
   [SerializeField] private ScoreView score;
   [SerializeField] private LoseView loseView;
   
   public void Construct(ProgressService progress)
   {
      score.Construct(progress);
      health.Construct(progress);
   }

   public void Initialize()
   {
      loseView.gameObject.SetActive(false);
   }
   
   public void ShowLoseView()
   {
      loseView.ShowAnimation();
   }
}
