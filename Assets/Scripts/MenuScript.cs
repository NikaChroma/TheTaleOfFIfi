using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
