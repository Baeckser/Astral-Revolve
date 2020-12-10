using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    public string sceneToLoad;

    public void button_Load_Scene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void button_exit_Game()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
