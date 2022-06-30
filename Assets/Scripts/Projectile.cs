using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 3f;
    public float lifetime = 3f;
    public float currentTime;

    public int damage = 1;
    public int direction = 1;

    public AudioSource Explosion; 

    // Start is called before the first frame update
    void Start()
    {
        currentTime = lifetime;
    }

    // Update is called once per frame
    //Projectile firing direction and speed
    void Update()
    {
        if (direction >= 0)
        {
            transform.position -= (+speed * Time.deltaTime * transform.up);
        }
        else
        {
            transform.position += (+speed * Time.deltaTime * transform.up);
        }

        currentTime -= 1 * Time.deltaTime;
    
        {
            if (currentTime <= 0f)
            {
                Destroy(projectile);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Projectile collision with enemies
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().curEnemyHitPoints -= damage;//Dealing damage to enemies
            Destroy(projectile);
            Explosion.Play();
        }
        //Destroying out of bound projectiles
        if(collision.gameObject.tag == "Finish")
        {
            Destroy(projectile);    
        }

        if (collision.gameObject.name == "Enemy_Projectile_2(Clone)")
        {
            Destroy(projectile);
            Destroy(collision.gameObject);
            UIManager.manager.score += 10;
        }

    }

}
