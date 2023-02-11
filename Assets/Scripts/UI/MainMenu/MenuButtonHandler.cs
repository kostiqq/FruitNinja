using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button exitGame;
    [SerializeField] private SceneConfig sceneConfig;
    [SerializeField] private MainMenuAnimator animator;

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
        animator.StartAnimation();
        
        yield return new WaitForSeconds(animator.GetAnimationTime);
        
        SceneManager.LoadScene(sceneConfig.GameSceneIndex);
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
