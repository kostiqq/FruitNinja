using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField] private ButtonAnimator startGame;
    [SerializeField] private ButtonAnimator exitGame;
    [SerializeField] private SceneConfig sceneConfig;
    [SerializeField] private MainMenuAnimator animator;

    private void Awake()
    {
        startGame.OnTouchPerformed += StartGame;
        exitGame.OnTouchPerformed += ExitGame;
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
        if(animator != null) animator.StartAnimation();
        
        yield return new WaitForSeconds(animator.GetAnimationTime);
        
        SceneManager.LoadScene(sceneConfig.GameSceneIndex);
    }

    private void DisableButtons()
    {
        startGame.enabled = false;
        exitGame.enabled = false;
    }
}
