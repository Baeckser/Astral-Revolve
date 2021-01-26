using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    //Enemy "looks" towards the Player-Ship relative to its position and rotation
    void Update()
 
    {
        transform.up = target.transform.position - transform.position;
    }
}
