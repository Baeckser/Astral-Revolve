using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    Vector3 respawn = new Vector3(-9, -3, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -3 * Time.deltaTime, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = respawn;
            Destroy(enemyProjectile);
            GameManager.playGame = false;
        }
        if(collision.gameObject.tag == "Finish")
        {
            Destroy(enemyProjectile);
        }
    }
}
