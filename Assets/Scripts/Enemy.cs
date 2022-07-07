using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Base Stats")]
    public GameObject enemy;
    public Transform[] enemy_Guns;
    private int Guns = 0;
    
    [Header("Score")]
    public int enemy_Value = 100;

    [Header("Enemy Projectiles")]
    public GameObject enemyProjectile;
    public GameObject enemyProjectile_2;
    public GameObject enemyProjectileClone;

    [Header("Enemy Projectile Stats")]
    public float timeBetweenBullets = 1f;
    public float timeTilNextShot;
    public float startDelay = 2.5f;
    public float randomBulletRange = 3f;

    [Header("Enemy Health Stats")]
    public int maxEnemyHitPoints = 100;
    public int curEnemyHitPoints;

    //[Header("Enemy Sounds")]
    //public AudioSource Enemy_Shot;

    // Start is called before the first frame update
    void Start()
    {
        timeTilNextShot = Time.realtimeSinceStartup + startDelay;
        curEnemyHitPoints = maxEnemyHitPoints;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 1f)
        {
            if (Time.realtimeSinceStartup > timeTilNextShot)
                fireEnemyProjectile();
            EnemyDeath();
        }
    }

    //Enemy firing projectile(s)
    void fireEnemyProjectile()
    {
        Guns = 0;
        foreach(Transform i in enemy_Guns)
        {
            if (Random.Range(0f, randomBulletRange) < 1)
            {
                    //Firing projectile_2(random)
                    Transform _guns = enemy_Guns[Guns];
                    Instantiate(enemyProjectile_2, _guns.position, transform.rotation);
                    Guns++;
                    //Enemy_Shot.Play();
            }
            else
            {
                    //Firing projectile_1(timed)
                    Transform _guns = enemy_Guns[Guns];
                    Instantiate(enemyProjectile, _guns.position, transform.rotation);
                    Guns++;
                    //Enemy_Shot.Play();
            }
            timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets;
        }
    }

    //Checking if the enemie has any HitPoints left
    void EnemyDeath()
    {
        if (curEnemyHitPoints > 0)
        {
            return;
        }
        Destroy(enemy);
        UIManager.manager.score += enemy_Value;
    } 

    //Despawning out of range enemies and collision with the Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(enemy);
        }
        
        if (collision.gameObject.tag == "Player")
        {
            Destroy(enemy);

            Player_2 temp = collision.gameObject.GetComponent<Player_2>();
            if (temp != null)
            {
                temp.Respawn();
            }
        }
    }
}
