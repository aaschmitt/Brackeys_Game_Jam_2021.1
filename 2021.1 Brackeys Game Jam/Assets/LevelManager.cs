using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen = null;
    [SerializeField] private GameObject gamePreScreen = null;
    [SerializeField] private List<GameObject> objectsToDisable = null;
    [SerializeField] private Timer timer = null;

    private void Start()
    {
        // Configure game objects
        DisableObjects();
        Time.timeScale = 0;
        ConfigurePreScreen();
    }

    /*
    private void OnEnable()
    {
        EnableObjects();
        StartLevel();
    }
    */

    public void StartLevel()
    {
        gamePreScreen.SetActive(false);
        EnableObjects();
        Time.timeScale = 1;
    }
    
    public void EndLevel()
    {
        // Enable game over screen
        gameOverScreen.SetActive(true);

        // Set time to zero
        Time.timeScale = 0;

        DisableObjects();

        // Display finishing time
        timer.DisplayTime();
    }

    public void EnableObjects()
    {
        foreach (var objectToEnable in objectsToDisable)
        {
            objectToEnable.SetActive(true);
        }
    }

    private void DisableObjects()
    {
        foreach (var objectToDisable in objectsToDisable)
        {
            objectToDisable.SetActive(false);
        }
    }

    private void ConfigurePreScreen()
    {
        // Disable game over screen
        gameOverScreen.SetActive(false);
        gamePreScreen.SetActive(true);
    }
}
