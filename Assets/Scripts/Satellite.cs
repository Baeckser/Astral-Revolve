using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    public Transform satellite;

    [Header("Weaponry")]
    public Transform[] Weapons;
    private int weapons = 0;

    [Header("Player Projectiles")]
    public ProjectileSatellite projectilePrefab;

    [Header("Projectile Stats")]
    public float timeBetweenBullets = 0.1f;
    public float timeBetweenBulletsRecharge = 0.5f;
    public float timeTilNextShot;

    // Start is called before the first frame update
    void Start()
    {
        timeTilNextShot = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > timeTilNextShot)
        {
            fireProjectile();
        }
    }

    void fireProjectile()
    {
        weapons = 0;
        foreach (Transform i in Weapons)
        {

                if (Input.GetKey(KeyCode.Space))
                {
                    Transform _weapons = Weapons[weapons];
                    Instantiate(projectilePrefab, _weapons.position, satellite.rotation);
                    weapons++;
                    timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets;
                    //Shot.Play();
                }
            
            else

            if (Input.GetKey(KeyCode.Space))
            {
                Transform _weapons = Weapons[weapons];
                Instantiate(projectilePrefab, _weapons.position, satellite.rotation);
                weapons++;
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBulletsRecharge;
                //Shot.Play();
            }
            
        }
    }
}
