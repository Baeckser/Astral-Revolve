using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    GameObject[] objs;
    public float speed = 5f;
    

    // Update is called once per frame
    void Update()
    {
        { transform.position -= (-speed * Time.deltaTime * transform.up); }
    }
    
    //Projectile behaviour
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Projectilie collision with the player
        if (collision.gameObject.tag == "Player")
        {
            Player_2 temp = collision.gameObject.GetComponent<Player_2>();
            if (temp != null)
            {
                temp.Respawn();
            }
            Destroy(enemyProjectile);
            objs = GameObject.FindGameObjectsWithTag("EnemyProjectile");

            foreach (GameObject enemy_projectiles in objs)
            {
                Destroy(enemy_projectiles);
            }
        }

        //Destroying out of bounce projectiles
        if(collision.gameObject.tag == "Finish")
        {
            Destroy(enemyProjectile);
        }
    }
}
