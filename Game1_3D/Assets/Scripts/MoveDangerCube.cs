using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDangerCube : MonoBehaviour {

    public float min;
    public float max;
    //Random rnd = new Random();
    
    // Use this for initialization
    /*void Start()
    {

        //min = transform.position.x;
        //max = transform.position.x + 3;

    }
    */
    // Update is called once per frame
    void Update()
    {
        //int num = rnd.Next(1,3);

        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

    }
}
