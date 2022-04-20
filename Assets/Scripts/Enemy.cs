using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 3;
    public GameObject enemyBullet;
    public GameObject eyes;
    public GameObject explosion;
    public int Speed;
    public Transform target;
    public float turnSpeed = 20;       

    [SerializeField] private float cooldown = 5;
    private float cooldownTimer;

    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        GameObject tempBullet = Instantiate(enemyBullet, eyes.gameObject.transform.position, eyes.gameObject.transform.rotation) as GameObject; //shoots from enemies eyes
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * Speed);
    }

    public void damage()
    {
        HP--;
        if (HP <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
