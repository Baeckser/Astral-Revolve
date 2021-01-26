using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] enemy_Guns;
    private int Guns = 0;

    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;
    
    public float timeBetweenBullets = 1f;
    public float timeTilNextShot;
    public float startDelay = 2.5f;

    public int maxEnemyHitPoints = 100;
    public int curEnemyHitPoints;

    // Start is called before the first frame update
    void Start()
    {
        timeTilNextShot = Time.realtimeSinceStartup + startDelay;
        curEnemyHitPoints = maxEnemyHitPoints;
    }

    // Update is called once per frame
    private void Update()
    {
            if (Time.realtimeSinceStartup > timeTilNextShot)
                fireEnemyProjectile();
                EnemyDeath();
    }

    //Enemy firing projectile
    void fireEnemyProjectile()
    {
        Guns = 0;
        foreach(Transform i in enemy_Guns)
        {
            Transform _guns = enemy_Guns[Guns];
            Instantiate(enemyProjectile, _guns.position, transform.rotation);
            Guns++;
        }
        timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets;
    }

    //Checking if the enemie has any HitPoints left
    void EnemyDeath()
    {
        if (curEnemyHitPoints > 0)
        {
            return;
        }
        Debug.Log("Enemy was destroyed!");
        Destroy(enemy);
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

            GameManager.playGame = false;
        }
    }
}
