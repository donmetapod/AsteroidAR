using UnityEngine;

public class TitleScreenController : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneLoader.LoadScene("Game");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
