using GameActors.Spawner;
using Services.Progress;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private SpawnerController spawnController;

    public void Construct(ProgressService progressService)
    {
        progressService.OnHealthEmpty += OnPlayerLose;
    }
    
    private void OnPlayerLose()
    {
        spawnController.StopSpawn();
    }
}
