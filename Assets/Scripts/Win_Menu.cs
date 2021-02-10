using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Menu : MonoBehaviour
{
    public GameObject WinMenuUI;

    public static bool GameIsWon = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsWon == true)
        {
            WinMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            WinMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        GameIsWon = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        WinMenuUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Menu");
        WinMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
