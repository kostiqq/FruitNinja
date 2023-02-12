using GameActors.Spawner;
using Services.Progress;
using System.Collections;
using GameInput;
using UnityEngine;
using Zenject;

public class GameState : MonoBehaviour
{
    private const float showLoseScreenDelay = 2f;
    private SpawnerController _spawnController;
    [SerializeField] private GameView _gameView;
    [SerializeField] private ObjectContainer activeObjects;
    [SerializeField] private InputHandler input;

    [Inject] private ProgressService progress;

    private void Start()
    {
        _spawnController = SpawnerController.Instance;
        progress.OnHealthEmpty += OnPlayerLose;
    }

    private void OnPlayerLose()
    {
        _spawnController.StopSpawn();
        input.enabled = false;
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitUntil(()=> activeObjects.getObjectsCount != 0);
        
        yield return new WaitForSeconds(showLoseScreenDelay);
        _gameView.ShowLoseView();
    }
}
