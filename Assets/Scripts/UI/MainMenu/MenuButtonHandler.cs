using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button exitGame;
    [SerializeField] private SceneConfig sceneConfig;

    private void Awake()
    {
        startGame.onClick.AddListener(StartGame);
        exitGame.onClick.AddListener(ExitGame);
    }

    private void ExitGame()=>
        Application.Quit();

    private void StartGame()
    {
        DisableButtons();
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        RunAnimation();
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneConfig.GameSceneIndex);

        if (!load.isDone)
            yield return null;
        
    }

    private void RunAnimation()
    {
        
    }

    private void DisableButtons()
    {
        startGame.enabled = false;
        exitGame.enabled = false;
    }
}
