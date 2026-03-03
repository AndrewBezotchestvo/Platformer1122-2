using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void NewGame()
    {
        
        PlayerPrefs.SetFloat("HP", 100);
        PlayerPrefs.SetFloat("Coins", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));
    }

    public void Exit()
    {
        Application.Quit();
    }
}
