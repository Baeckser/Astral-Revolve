using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_2 : MonoBehaviour
{
    [Header("Player Ship")]
    public GameObject player_2;
    public Transform Anchor;
    public Transform OneEighty;

    public static int Continues = 3;

    [Header("Player Stats")]
    public float speed = 5f;
    public float boost = 1.5f;
    public float throttle = 0.75f;

    [Header("Weaponry")]
    public Transform Weapon;
    public Transform Weapon_2;

    [Header("Player Projectiles")]
    public Projectile projectilePrefab;

    [Header("Projectile Stats")]
    public float timeBetweenBullets_1 = 0.1f;
    public float timeBetweenBulletsRecharge = 0.5f;
    public float timeTilNextShot;

    [Header("Energy Stats")]
    public float maxEnergy = 100;
    public float curEnergy;
    public float consumeRate = 1;
    public float refreshRate = 2;
    public float rechargeRate = 1;
    public enum EnergyState
    {
        IdleState, ConsumingState, RechargeState, RefreshState
    }
    public EnergyState state;

    [Header("Player Sounds")]
    public AudioSource Shot;

    Vector3 Startrotation;
    Quaternion Rotation;

    private void Start()
    {
        Continues = 3;
        curEnergy = maxEnergy;
        Rotation = OneEighty.rotation;
        Startrotation = OneEighty.rotation.eulerAngles;
        if(Startrotation.z < 180)
        {
            projectilePrefab.direction = -1;
        }
        if(Startrotation.z >= 180)
        {
            projectilePrefab.direction = 1;
        }
        Rotation = Anchor.rotation;
        Startrotation = Anchor.rotation.eulerAngles;
        timeTilNextShot = Time.realtimeSinceStartup;
    }
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            movement();
            if (Time.realtimeSinceStartup > timeTilNextShot)
                fireProjectile();
            oneEighty();
        }    
            Continue();        
    }

    //Moving the Player ship
    void movement()
    {
        if (state == EnergyState.IdleState || state == EnergyState.ConsumingState || state == EnergyState.RefreshState)
        {
            //Moving right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
                {
                    //Boosting(using Energy in the process)
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        Debug.Log("Boost");
                        state = EnergyState.ConsumingState;
                        Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * (speed * boost)));
                    }
                }
            }
            //Moving left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * -speed));
                {
                    //Boosting(using Energy in the process)
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        Debug.Log("Boost");
                        state = EnergyState.ConsumingState;
                        Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * (-speed * boost)));
                    }
                }
            }
        }
        else
        {
            //Moving right(throttled)
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * speed * throttle));
            }
            //Moving left(throttled)
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * -speed * throttle));
            }
        }

        //Energy usage while boosting
        if (state == EnergyState.ConsumingState)
        {
            curEnergy -= consumeRate;
        }

        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            if (curEnergy >= 100)
            {
                state = EnergyState.IdleState;
            }
            if (state != EnergyState.RechargeState && curEnergy < 100) 
            {
                state = EnergyState.RefreshState;
            }
        }

        if (curEnergy <= 0)
        {
            state = EnergyState.RechargeState;
            if (curEnergy >= 100)
            {
                state = EnergyState.IdleState;
            }
        }

        //Normal Recharge(fast)
        if (state == EnergyState.RefreshState)
        {
            curEnergy += refreshRate;
        }
       
        //Recharge after complete exhaustion of the Player-Ships Energy(slow)
        if(state == EnergyState.RechargeState && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            curEnergy += rechargeRate;            
        }
    }
    
    //Turning the player ship around
    void oneEighty()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OneEighty.Rotate(new Vector3(0, 0, 180));
            projectilePrefab.direction *= -1;
        }
    }

   
    //Using the Player weapon(s)
    void fireProjectile()
    {
        if (state == EnergyState.IdleState || state == EnergyState.ConsumingState || state == EnergyState.RefreshState)
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
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(projectilePrefab, Weapon.position, Anchor.rotation);
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBulletsRecharge;
                Instantiate(projectilePrefab, Weapon_2.position, Anchor.rotation);
                timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBulletsRecharge;
                Shot.Play();
            }
        }
    }

    //Respawn
    public void Respawn()
    {
        //pausing the game after being hit
        Time.timeScale = 0f;

        //Loosing a life
        Continues -= 1;

        //Resetting the Energy Bar upon respawning
        state = EnergyState.IdleState;
        curEnergy = maxEnergy;

        //Respawn location
        Debug.Log(Anchor.rotation);
        
        //Anchor.Rotate(Startrotation);
        Anchor.rotation = Rotation;
        
    }
    
    //Continue playing after respawn
    public void Continue()
    {
        if (Continues > 0)
        {
            if (Time.timeScale == 0f && PauseMenu.GameIsPaused == false)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.Space))))
                {
                    Time.timeScale = 1f;
                }
            }
        }
        else
        {
            GameOver.GameIsLost = true;
            Time.timeScale = 0f;
            return;
        }
    }

}

