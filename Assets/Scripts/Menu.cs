using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject options;
    public GameObject main;

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }
    public void optionsmenu()
    {
        options.SetActive(true);
        main.SetActive(false);
    }
    public void mainmenu()
    {
        options.SetActive(false);
        main.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
