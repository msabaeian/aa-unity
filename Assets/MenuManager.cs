using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void OpenLevelScene()
    {
        SceneManager.LoadScene("Level1");
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("levelNumber", 1);
        this.OpenLevelScene();
    }
    
    public void Continue()
    {
        this.OpenLevelScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
