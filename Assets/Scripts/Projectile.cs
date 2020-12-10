using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 3f;
    public AudioSource Explosion; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        { transform.position += (-speed * Time.deltaTime * transform.up); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(projectile);
            GameManager.playGame = true;
            Explosion.Play();
        }
        if(collision.gameObject.tag == "Finish")
        {
            Destroy(projectile);    
        }
    }

}
