using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseUI;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            togglePause();
        }

    }
    public void togglePause()
    {

        if (isPaused)
        {
            //unpause
            Time.timeScale = 1;
            isPaused = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseUI.SetActive(false);
        }
        else
        {
            //pause
            Time.timeScale = 0;
            isPaused = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseUI.SetActive(true);
        }

        //sets isPaused to its inverse value
        //isPaused = !isPaused;
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Restart(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseUI.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();


    }
}
