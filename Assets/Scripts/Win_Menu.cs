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
        }
        else
        {
            WinMenuUI.SetActive(false);
        }
    }

    public void Continue()
    {
        GameIsWon = false;
        Time.timeScale = 1f;
        if ((SceneManager.GetActiveScene().buildIndex + 1) > 2)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        WinMenuUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        WinMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
