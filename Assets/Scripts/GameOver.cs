using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";

    public void Retry()
    {
        Time.timeScale = 1f;
        Debug.Log("Deneme");
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo("MainMenu");
    }

}
