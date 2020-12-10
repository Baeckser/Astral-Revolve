using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{
    public GameObject player_2;
    public AudioSource Shot;
    public float speed = 5f;
    public Projectile projectilePrefab;
    public Transform Anchor;
    public Transform Weapon;
    Vector3 Startrotation;
    Quaternion Rotation;

    private void Start()
    {
        Rotation = Anchor.rotation;
        Startrotation = Anchor.rotation.eulerAngles;
    }
    void Update()
    {
        movement();
        fireProjectile();

    }

    void movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Anchor.Rotate(new Vector3(0, 0, Time.deltaTime * - speed));
        }

    }
    void fireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(new Vector3(this.transform.position.x, this.transform.position.y + 0.6f, 0));
            Instantiate(projectilePrefab, Weapon.position ,Anchor.rotation);
            Shot.Play();
        }
    }

    public void Respawn()
    {
        Debug.Log(Anchor.rotation);
        //Anchor.Rotate(Startrotation);
        Anchor.rotation = Rotation;
    }

}

