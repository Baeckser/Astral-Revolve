using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite_Controller : MonoBehaviour
{
    [Header("Satellite Positions")]
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Transform position4;

    [Header("CurSatellitePosition")]
    public Transform curPosition;

    public float duration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        curPosition = position1;
    }

    // Update is called once per frame
    void Update()
    {
        sattellitePositionSwitch();
    }

    void sattellitePositionSwitch()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
           
        }
    }

}
