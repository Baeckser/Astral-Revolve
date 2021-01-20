using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{
    public GameObject player_2;
    public Transform Anchor;
    public Transform OneEighty;
    
    public float speed = 5f;
    public float boost = 1.5f;

    public Transform Weapon;
    public Transform Weapon_2;

    public Projectile projectilePrefab;

    public float timeBetweenBullets_1 = 0.5f;
    public float timeTilNextShot;
    
    public enum EnergyState
    {
        IdleState, ConsumingState, RefreshState
    }
    public EnergyState state;
    
    Vector3 Startrotation;
    Quaternion Rotation;

    public AudioSource Shot;
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

    //Moving the Player ship
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
                        Energy_Bar.instance.UseEnergy(Time.deltaTime * 50);
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
                        Energy_Bar.instance.UseEnergy(Time.deltaTime * 50);
                    }
                    else
                    {
                        Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * (-speed + 25)));
                    }
                }

            }
        }
        
    }
    
    //Turning the player ship around
    void oneEighty()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OneEighty.Rotate(new Vector3(0, 0, 180));
        }
    }

   
    //Using the Player weapon(s)
    void fireProjectile()
    {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(projectilePrefab, Weapon.position, Anchor.rotation);
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets_1;
                Instantiate(projectilePrefab, Weapon_2.position, Anchor.rotation);
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets_1;
                Shot.Play();
            }
    }

    //Respawn location
    public void Respawn()
    {
        Debug.Log(Anchor.rotation);
        //Anchor.Rotate(Startrotation);
        Anchor.rotation = Rotation;
    }

}

