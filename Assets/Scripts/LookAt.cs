using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Center");
    }

    // Update is called once per frame
    void Update()
 
    {
        Vector3 targetPos = target.transform.position;
        targetPos.z = transform.position.z;
        transform.LookAt(targetPos);
    }
}
