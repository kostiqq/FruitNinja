using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadScene(int sceneIndex)
    {
        if(SceneManager.GetActiveScene().buildIndex != sceneIndex)
            SceneManager.LoadScene(sceneIndex);
    }
}
