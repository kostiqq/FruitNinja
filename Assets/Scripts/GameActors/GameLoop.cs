using GameActors.Spawner;
using Services.Progress;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SpawnerController _spawnController;
    private GameView _gameView;

    public void Construct(ProgressService progressService, GameView gameView)
    {
        _gameView = gameView;
        _spawnController = SpawnerController.Instance;
        progressService.OnHealthEmpty += OnPlayerLose;
    }
    
    private void OnPlayerLose()
    {
        _spawnController.StopSpawn();
        _gameView.ShowLoseView();
    }
}
