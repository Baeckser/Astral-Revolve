using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    public float speed = 5f;
    

    // Update is called once per frame
    void Update()
    {
        { transform.position -= (-speed * Time.deltaTime * transform.up); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Player_2 temp = collision.gameObject.GetComponent<Player_2>();
            if (temp != null)
            {
                temp.Respawn();
            }

           
            Destroy(enemyProjectile);
            GameManager.playGame = false;
        }
        if(collision.gameObject.tag == "Finish")
        {
            Destroy(enemyProjectile);
        }
    }
}
