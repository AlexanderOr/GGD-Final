using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject options;
    public GameObject main;
    public GameObject Controls;

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void LoadMain(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void optionsmenu()
    {
        options.SetActive(true);
        main.SetActive(false);
        Controls.SetActive(false);
    }

    public void Controlsmenu()
    {
        Controls.SetActive(true);
        main.SetActive(false);
        options.SetActive(false);
    }

    public void mainmenu()
    {
        options.SetActive(false);
        main.SetActive(true);
        Controls.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
