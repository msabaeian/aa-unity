using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private bool gameOver = false;
    private Spinner spinner;
    private Spawn spawn;
    private TextMeshProUGUI levelLabel;
    public Animator animator;
    private int levelNumber = 1;
    
    public static GameManager Instance
    {
        get
        {
            // If no instance yet, try finding it in the scene
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate > 60 ? 60 : Screen.currentResolution.refreshRate ;
        spinner = FindFirstObjectByType<Spinner>();
        spawn = FindFirstObjectByType<Spawn>();
        levelLabel = FindFirstObjectByType<TextMeshProUGUI>();
        LoadLevel(1);
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            spinner.enabled = false;
            spawn.enabled = false;
            animator.SetTrigger("gameOver");
            StartCoroutine(this.ReloadLevel());
        }
    }
    

    private IEnumerator ReloadLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        this.LoadLevel(levelNumber);
    }
    
    public void Win()
    {
        if (!gameOver)
        {
            spinner.enabled = false;
            spawn.enabled = false;
            animator.SetTrigger("levelWin");
            StartCoroutine(this.LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        this.LoadLevel(levelNumber + 1);
    }

    private void LoadLevel(int level)
    {
        gameOver = false;
        levelNumber = level;
        levelLabel.text = $"Level: {level}";
        
        int pins;
        int defaultPinsOnSpinner;
        switch (level)
        {
            case 2:
                pins = 8;
                defaultPinsOnSpinner = 0;
                break;
            case 3:
                pins = 6;
                defaultPinsOnSpinner = 2;
                break;
            case 4:
                pins = 8;
                defaultPinsOnSpinner = 4;
                break;
            case 5:
                pins = 12;
                defaultPinsOnSpinner = 6;
                break;
            default:
                pins = 4;
                defaultPinsOnSpinner = 0;
                break;
        }

        
        spawn.SetLevelPins(pins);
        spinner.SetDefaultPins(defaultPinsOnSpinner);
        
        spinner.enabled = true;
        spawn.enabled = true;
    }
}
