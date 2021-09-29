using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (gameIsOver)
        {
            return;
        }

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }    
    }

    void EndGame()
    {
        Time.timeScale = 0f;
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }

}
