using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
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
            fireEnemyProjectile();
    }
    void fireEnemyProjectile()
    {
        if (Random.Range(0f, 50f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.6f, 0), enemy.transform.rotation) as GameObject;
        }
    }
}
