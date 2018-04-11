using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03c_main : MonoBehaviour
{

    public float orbitSpeedRpm = 10f;  // rpm = number of revolutions per minute
    public float radius = 3.5f;

    void Update()
    {
        // Time.time   =  number of seconds elapsed since the game started
        // Time.time/60   =   number of minutes elapsed since the game started
        // orbitSpeedRpm*Time.time/60    =    number of revolutions since the game started
        // orbitSpeedRpm*Time.time/60*2*Mathf.PI    =    number of radians since the game started
        float t = orbitSpeedRpm * Time.time / 60 * 2 * Mathf.PI;
        float x = radius * Mathf.Cos(t);
        float z = radius * Mathf.Sin(t);
        float y = 0.5f;
        gameObject.transform.position = new Vector3(x, y, z);
    }
}
