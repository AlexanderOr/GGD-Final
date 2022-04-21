using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int points = 0;
    public AudioSource Score;

    public static GameManager instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (points == 3)
        {
            Destroy(GameObject.FindWithTag("Door"));
        }

    }

    public void score()
    {
        points++;
        //Score.Play();
    }
}
