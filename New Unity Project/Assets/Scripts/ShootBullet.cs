using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.1f;
    public int fireDelay = 120;
    private bool isFiring = false;
    int frameTimer;
    

    void SetFiring()
    {
        isFiring = false;
    }

    void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                if (frameTimer >= fireDelay)
                {
                    Fire();
                }
            }
        }
        else
        {
            frameTimer = 0;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                frameTimer++;
            }
        }
    }
}
