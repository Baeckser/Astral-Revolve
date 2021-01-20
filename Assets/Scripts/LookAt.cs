using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    Vector3 Startrotation;
    Quaternion Rotation;

    // Start is called before the first frame update
    void Start()
    {

        transform.LookAt(target.transform.position, target.transform.up);
    }

    // Update is called once per frame
    void Update()
 
    {
        /*Vector3 targetPos = target.transform.rotation;
        targetPos.z = transform.rotation.z;
        transform.LookAt(targetPos);*/
    }
}
