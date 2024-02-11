using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button continueButton;
    private void Start()
    {
        if (PlayerPrefs.GetInt("levelNumber", 1) == 1)
        {
            continueButton.enabled = false;
        }
    }

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
