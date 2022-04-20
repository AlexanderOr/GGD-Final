using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{
    public GameObject Pistol;
    public bool isFiring = false;
    public AudioSource PistolShot;
    public AudioSource Reload;
    public int CurrentAmmo;
    public int TotalAmmo;
    public Rigidbody bullet;
    public int speed = 20;
    

    private AmmoDisp AmmoDisplay;

    public GameObject ammoText;
    public GameObject totalAmmoText;
    public GameObject reloadText;


    void Start()
    {
        CurrentAmmo = 10;
        TotalAmmo = 30;
    }
    // Update is called once per frame
    void Update()
    {
        ammoText.GetComponent<Text>().text = "AMMO: " + CurrentAmmo + " / 10";
        totalAmmoText.GetComponent<Text>().text = "AMMO LEFT: " + TotalAmmo;

        if (CurrentAmmo == 0)
        {
            reloadText.SetActive(true);
        }
        else
        {
            reloadText.SetActive(false);
        }


    
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload.Play();
            TotalAmmo -= (10 - CurrentAmmo);
            CurrentAmmo += (10 - CurrentAmmo);
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (isFiring == false && CurrentAmmo > 0)
            {
                StartCoroutine(FirePistol());
                Rigidbody instantiatedProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;

            }
        }
    }

    IEnumerator FirePistol()
    {
        isFiring = true;
        //if animation Pistol.GetComponent<Animator>().Play("FirePistol");
        PistolShot.Play();
        yield return new WaitForSeconds(0.25f);
        CurrentAmmo--;
        isFiring = false;
    }
}
