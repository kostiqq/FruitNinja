using GameActors.Spawner;
using Services.Progress;
using System.Collections;
using GameInput;
using UnityEngine;
using Zenject;

public class GameState : MonoBehaviour
{
    private const float showLoseScreenDelay = 1.5f;
    private SpawnerController _spawnController;
    [SerializeField] private GameView _gameView;
    [SerializeField] private ObjectContainer activeObjects;
    [SerializeField] private InputHandler input;
    
    [Inject] private ProgressService progress;

    private void Start()
    {
        _gameView.getLoseView.OnRestart += RestartGame;
        progress.OnHealthEmpty += OnPlayerLose;
    }

    private void OnDestroy()
    {
        _gameView.getLoseView.OnRestart -= RestartGame;
        progress.OnHealthEmpty -= OnPlayerLose;
    }

    private void OnPlayerLose()
    {
        SpawnerController.Instance.StopSpawn();
        input.DisableInput();
        input.enabled = false;
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitUntil(()=> activeObjects.getObjectsCount != 0);
        
        yield return new WaitForSeconds(showLoseScreenDelay);
        _gameView.ShowLoseView();
    }

    private void RestartGame()
    {
        input.enabled = true;
        SpawnerController.Instance.Restart();
        _gameView.ReInit();
    }
}
