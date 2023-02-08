using Services.Progress;
using UnityEngine;

public class GameView : MonoBehaviour
{
   [SerializeField] private HealthView health;
   [SerializeField] private ScoreView score;
   public void Construct(ProgressService progress)
   {
      score.Construct(progress);
      health.Construct(progress);
   }
}
