using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI;

    public static bool GameIsLost = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(GameIsLost == true)
       {
            GameOverUI.SetActive(true);
       }        
       else
       {
            GameOverUI.SetActive(false);
       }
    }

    public void Retry()
    {
        GameIsLost = false;
        Time.timeScale = 1f;
        Player_2.Continues = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverUI.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
