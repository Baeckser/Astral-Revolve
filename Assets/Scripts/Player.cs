using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public GameObject projectileClone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        fireProjectile();
    }
    
    void movement()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
        }

    }
    void fireProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space) && projectileClone == null)
        {
            Debug.Log(new Vector3(this.transform.position.x, this.transform.position.y + 0.6f, 0));
            projectileClone = Instantiate(projectile, new Vector3(this.transform.position.x, this.transform.position.y + 0.6f, 0), this.transform.rotation) as GameObject;
        }
    }
}
