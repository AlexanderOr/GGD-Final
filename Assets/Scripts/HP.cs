using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public GameObject HPText;
    public int hp = 5;
    public AudioSource Hurt;
    public bool CanHurt = true;

    public static HP instance;
    
    public void Start()
    {
        CanHurt = true;
        instance = this;
    }

    void Update()
    {
        HPText.GetComponent<Text>().text = "HEALTH: " + hp + " / 5";

        if(hp <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        CanHurt = true;
    }
    

    public void Damage1()
    {
        if (CanHurt)
        {
            hp--;
            CanHurt = false;
            Hurt.Play();
            StartCoroutine(Cooldown());
        }
    }

    public void Damage2()
    {
        if(CanHurt == true)
        {
            hp -= 2;
            CanHurt = false;
            Hurt.Play();
            StartCoroutine(Cooldown());
        }
    }
}
