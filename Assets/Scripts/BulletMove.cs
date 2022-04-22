using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 20;
    Enemy enemy1;
    Enemy2 enemy2;
    GameManager sn;
    HP hp;

    public void Awake()
    {
        hp = HP.instance;
    }

    private void Start()
    {
        enemy1 = gameObject.GetComponent("PA_Drone") as Enemy;
        enemy2 = gameObject.GetComponent("PA_Warrior") as Enemy2;
        sn = GameManager.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject);

        if (col.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit target");
            //destroy target and add point
            sn.score();
            Destroy(col.gameObject);
        }

        else if (col.gameObject.CompareTag("Border"))
        {
            Debug.Log("Hit wall");
            Destroy(this.gameObject);
        }

        else if (col.gameObject.tag == "Enemy1" && col.gameObject.TryGetComponent<Enemy>(out enemy1))
        {
            Debug.Log("Hit drone");
            enemy1.damage();
        }

        else if (col.gameObject.tag == "Enemy2" && col.gameObject.TryGetComponent<Enemy2>(out enemy2))
        {

            Debug.Log("Hit warrior");
            enemy2.damage();
        }

        else if(col.gameObject.tag != "Gun" && col.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

        else if(col.gameObject.tag == "Player")
        {
            hp.Damage1();
            Destroy(this.gameObject);
        }
    }
}
