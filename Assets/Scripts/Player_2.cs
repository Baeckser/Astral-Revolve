using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{
    public GameObject player_2;
    public AudioSource Shot;
    public float speed = 5f;
    public float boost = 1.5f;
    public float timeBetweenBullets_1 = 0.5f;
    public float timeBetweenBullets_2 = 0.5f;
    public float timeBetweenBullets_3 = 0.5f;
    public float timeTilNextShot;
    public Projectile projectilePrefab;
    public Projectile LaserPrefab;
    public Transform OneEighty;
    public Transform Anchor;
    public Transform Weapon;
    public Transform Weapon_2;
    public Transform quad_Shot;
    public Transform Gun_2;
    public Transform Gun_3;
    public Transform Gun_4;
    public Transform Gun_5;
    public Transform Laser;
    Vector3 Startrotation;
    Quaternion Rotation;


    private void Start()
    {
        Rotation = OneEighty.rotation;
        Rotation = Anchor.rotation;
        Startrotation = Anchor.rotation.eulerAngles;
        timeTilNextShot = Time.realtimeSinceStartup;
    }
    void Update()
    {
        movement();
        if(Time.realtimeSinceStartup > timeTilNextShot)
            fireProjectile();
        oneEighty();
    }

    void movement()
    {
        //Moving right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
            {
                if (Energy_Bar.instance.currentEnergy >= 5)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * (speed * boost)));
                        Energy_Bar.instance.UseEnergy(Time.deltaTime * 20);
                    }
                    else
                    {
                        Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * (speed - 25)));
                    }
                }
            }
        }
        //Moving left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * -speed));
            {
                if (Energy_Bar.instance.currentEnergy >= 5)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * (-speed * boost)));
                        Energy_Bar.instance.UseEnergy(Time.deltaTime * 20);
                    }
                    else
                    {
                        Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * (-speed + 25)));
                    }
                }

            }
        }
        
    }
    void oneEighty()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OneEighty.Rotate(new Vector3(0, 0, 180));
        }
    }

   

    void fireProjectile()
    {
            if (Input.GetKey("a"))
            {
                Instantiate(projectilePrefab, Weapon.position, Anchor.rotation);
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets_1;
                Shot.Play();Instantiate(projectilePrefab, Weapon_2.position, Anchor.rotation);
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets_1;
                Shot.Play();
        }
            
            if (Input.GetKey("s"))
            {
                Instantiate(projectilePrefab, quad_Shot.position, Anchor.rotation);
                Instantiate(projectilePrefab, Gun_2.position, Anchor.rotation);
                Instantiate(projectilePrefab, Gun_3.position, Anchor.rotation);
                Instantiate(projectilePrefab, Gun_4.position, Anchor.rotation);
                Instantiate(projectilePrefab, Gun_5.position, Anchor.rotation);
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets_2;
                Energy_Bar.instance.UseEnergy(Time.deltaTime * 75);
                Shot.Play();
            }
            
            if (Input.GetKey("d"))
            {
                Instantiate(projectilePrefab, Weapon.position, Anchor.rotation);
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets_3; ;
                Energy_Bar.instance.UseEnergy(Time.deltaTime * 30);
                Shot.Play();
            }
        

    }

    public void Respawn()
    {
        Debug.Log(Anchor.rotation);
        //Anchor.Rotate(Startrotation);
        Anchor.rotation = Rotation;
    }

}

