using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    float timeToMove = 0.5f;
    int numOfMovements = 0;
    float speed = 0.25f;

    public GameObject enemy;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move sideways on timed interval
        if (GameManager.playGame)
        { 

            timer += Time.deltaTime;
            if(timer > timeToMove && numOfMovements < 14)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;
            numOfMovements++;
        }

            //move down after 14 movements in one direction
            if (numOfMovements == 14)
            {
                transform.Translate(new Vector3(0, -1, 0));
                numOfMovements = -1;
                speed = -speed;
                timer = 0;
            }

            fireEnemyProjectile();
        }

    }
    void fireEnemyProjectile()
    {
        if (Random.Range(0f, 750f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.6f, 0), enemy.transform.rotation) as GameObject;
        }
    }
}
