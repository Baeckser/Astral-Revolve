using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt_Enemy : MonoBehaviour
{
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    //Enemy "looks" towards the Player-Ship relative to its position and rotation
    void Update()
 
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        transform.up = target.transform.position - transform.position;
    }
}
