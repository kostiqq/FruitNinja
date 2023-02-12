using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.GameView
{
    public class LoseViewButtonsHandler : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;

        public Action OnRestart;
        private void Awake()
        {
            restartButton.onClick.AddListener(RestartGame);
            menuButton.onClick.AddListener(LoadMenuScene);
        }

        private void RestartGame()
        {
            OnRestart?.Invoke();
        }

        private void LoadMenuScene()
        {
            SceneManager.LoadScene(0);
        }
        
    }
}