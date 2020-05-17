using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //this script based on Brackeys Tutorial https://www.youtube.com/watch?v=JivuXdrIHK0



    // Start is called before the first frame update
    public bool isGamePaused;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Debug.Log("main menu loader");
        Time.timeScale = 1f;
    }

    public void quitTheGame()
    {
        Application.Quit();
        Debug.Log("quit game here");
    }
}
