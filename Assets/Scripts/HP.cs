using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public GameObject HPText;
    public int hp = 5;
    public AudioSource Hurt;

    public static HP instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        HPText.GetComponent<Text>().text = "HEALTH: " + hp + " / 5";
    }

   
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "EnemyBullet")
        {
            StartCoroutine(Damage());
        }
        if (col.gameObject.tag == "Enemy2")
        {
            Damage2();
        }
    }


    IEnumerator Damage()
    {
        hp--;
        Hurt.Play();
        yield return new WaitForSeconds(1f);
    }

    public void Damage2()
    {
        hp = hp - 2;
        Hurt.Play();

    }
}
