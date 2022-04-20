using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 20;
    Enemy enemy1;
    Enemy2 enemy2;
    GameManager sn;

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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Target")
        {
            //destroy target and add point
            sn.score();
            Destroy(col.gameObject);
            Destroy(gameObject);
            
        }

        if (col.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Enemy1" && col.gameObject.TryGetComponent<Enemy>(out enemy1))
        {            
            enemy1.damage();
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Enemy2" && col.gameObject.TryGetComponent<Enemy2>(out enemy2))
        {
            enemy2.damage();
            Destroy(gameObject);
        }
    }
}
