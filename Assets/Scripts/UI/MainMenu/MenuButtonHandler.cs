using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button exitGame;

    private void Awake()
    {
        startGame.onClick.AddListener(StartGame);
        exitGame.onClick.AddListener(ExitGame);
    }

    private void ExitGame()=>
        Application.Quit();

    private void StartGame()
    {

    }
    
}
